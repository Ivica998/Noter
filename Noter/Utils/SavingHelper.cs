using Noter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Noter.Utils
{
    public static class SavingHelper
    {
        public static string Indent(int amount = 1)
        {
            return new string(' ', 2 * amount);
        }
        public static string CC(this string str, string extra,int amount = 1)
        {
            return str += Indent(amount) + extra;
        }
        public static void LoadStrings(string path, IList<string> collection)
        {
            if (File.Exists(path))
                using (FileStream fs = File.OpenRead(path))
                {
                    StreamReader sr = new StreamReader(fs);
                    string output = sr.ReadToEnd();
                    output = output.Replace("\r", "");
                    string[] members = output.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in members)
                    {
                        collection.Add(item);
                    }
                    sr.Close();
                }
        }
        public static void SaveStrings(string path, IList<string> collection)
        {
            using (FileStream fs = File.Create(path))
            {
                if (collection != null)
                {
                    fs.SetLength(0);
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (var item in collection)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                }
            }
        }
        internal static int GetCode(object obj)
        {
            switch (obj)
            {
                case Entry _: return 0;
                case Tag _: return 1;
                case PreviewEntry _:return 2;
                /*
            case Tag t: return 1;
            case Tag t: return 1;
                 */
                default: return 0;
            }
        }
        internal static Type GetType(int code)
        {
            switch (code)
            {
                case 0: return typeof(Entry);
                case 1: return typeof(Tag);
                case 2: return typeof(PreviewEntry);
                /*
            case Tag t: return 1;
                 */
                default: return default;
            }
        }
        public static void Save<T>(string path, T obj) where T : class, new()
        {
            if (obj != null)
            {
                using (FileStream fs = File.Create(path))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    StringBuilder sb = new StringBuilder();
                    GenerateSave(obj, sb);
                    sw.Close();
                }
            }

        }
        private static void GenerateSave<T>(T obj, StringBuilder sb, int depth = 0) where T : class, new()
        {
            var props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var prop in props)
            {
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type itemType = prop.PropertyType.GetGenericArguments()[0];
                    dynamic list = (dynamic)prop.GetValue(obj);
                    sb.AppendLine(Indent(depth) + "<" + prop.Name + ":" + prop.PropertyType + ">");
                    foreach (var item in list)
                    {
                        GenerateSave(item, sb, depth + 1);
                    }
                    sb.AppendLine(Indent(depth) + "</" + prop.Name + ">");
                }
                else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    dynamic list = (dynamic)prop.GetValue(obj);
                    if (list is null)
                        continue;
                    sb.AppendLine(Indent(depth) + "<" + prop.Name + ":" + prop.PropertyType + ">");
                    foreach (var item in list)
                    {
                        sb.AppendLine(Indent(depth) + "<" + prop.Name + ":" + "KEY" + ">" + prop.GetValue(obj) + "</" + prop.Name + ">");
                        GenerateSave(item.Value, sb, depth + 1);
                    }
                    sb.AppendLine(Indent(depth) + "</" + prop.Name + ">");

                }
                else if (prop.PropertyType.IsEnum == true)
                    sb.AppendLine(Indent(depth) + "<" + prop.Name + ">" + prop.GetValue(obj) + "</" + prop.Name + ">");
                else
                    sb.AppendLine(Indent(depth) + "<" + prop.Name + ">" + prop.GetValue(obj) + "</" + prop.Name + ">");
            }
        }

        public static FileSaver MakeFileSaver(string path)
        {
            return new FileSaver(path);
        }

    }
}
