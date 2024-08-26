using Noter.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Noter.Models
{
    public class FileSaver
    {
        public string path;

        public Dictionary<Guid, int> map = new Dictionary<Guid, int>();

        public int fileId = 1;

        public FileSaver(string path)
        {
            this.path = path;
            Directory.CreateDirectory(path.DirOnly());
        }

        public T ReadOne<T>() where T : class, ISaveTXT, new()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string[] elements = sr.ReadToEnd().Replace("\r", "").Split("--- ", 2, StringSplitOptions.RemoveEmptyEntries);
                var elem = elements[0];
                string[] parts = elem.Split("1#\n", 2);

                string ccode = parts[0].Substring(3, parts[0].IndexOf(" ") - 3);
                int code = int.Parse(ccode);
                Type type = SavingHelper.GetType(code);
                if (type == default)
                    return null;
                T obj = (T)Activator.CreateInstance(type); // typeof(T)
                obj.FileId = int.Parse(parts[0].AfterFirst('&'));
                obj.ParseLoad(parts[1],1);
                GuidManager.Store(obj);
                return obj;
            }
        }

        public List<T> Read<T>() where T: class, ISaveTXT, new()
        {
            List<T> list = new List<T>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string[] elements = sr.ReadToEnd().Replace("\r","").Split("--- ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var elem in elements)
                {
                    string[] parts = elem.Split("1#\n", 2);

                    string ccode = parts[0].Substring(3, parts[0].IndexOf(" ") - 3);
                    int code = int.Parse(ccode);
                    Type type = SavingHelper.GetType(code);
                    if (type == default)
                        continue;
                    T obj = (T)Activator.CreateInstance(type); // typeof(T)
                    obj.FileId = int.Parse(parts[0].AfterFirst('&'));
                    obj.ParseLoad(parts[1],1);
                    GuidManager.Store(obj);
                    list.Add(obj);
                }
            }
            return list;
        }

        public List<T> ReadSimple<T>() where T : class, ISaveTXT, new()
        {
            List<T> list = new List<T>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string[] elements = sr.ReadToEnd().Replace("\r","").Split("2#\n", StringSplitOptions.RemoveEmptyEntries);
                foreach (var elem in elements)
                {
                    T obj = new T();
                    obj.ParseLoad(elem, 1);
                    GuidManager.Store(obj);
                    list.Add(obj);
                }
            }
            return list;
        }

        public void Write<T>(T item) where T : class, ISaveTXT, new()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                fs.SetLength(0);
                string toWrite = item.FormatSave(this, 1);
                sw.Write(toWrite);
            }
        }
        public void Write<T>(List<T> list) where T : class, ISaveTXT, new()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                fs.SetLength(0);
                foreach (var item in list)
                {
                    string toWrite = item.FormatSave(this, 1);
                    sw.Write(toWrite);
                }
            }
        }

        public int Next() => fileId++;

        public int getFileId(Guid id)
        {
            if (map.ContainsKey(id))
                return map[id];
            return 0;
        }

    }
}
