using Noter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Noter.Utils
{
    public static class GuidManager
    {
        public static Dictionary<Guid, ISaveTXT> collection { get; set; } = new Dictionary<Guid, ISaveTXT>();
        public static Dictionary<string,Tag> SpecialTags { get; set; } = new Dictionary<string, Tag>();
        public static Tag NONETag = MakeNoneTag();
        public static Tag MakeNoneTag()
        {
            NONETag = new Tag("NONE");
            NONETag.Id = Guid.Parse("d94608a9-6684-4ce3-ae2e-523989d77d4b");
            collection.Add(NONETag.Id, NONETag);
            SpecialTags.Add(NONETag.Name, NONETag);
            return NONETag;
        }

        public static Tag ALLTag = MakeALLTag();
        public static Tag MakeALLTag()
        {
            ALLTag = new Tag("ALL");
            ALLTag.BrushBG.Value = new SolidColorBrush(Color.FromRgb(32,  0, 16));
            ALLTag.BrushFG.Value = new SolidColorBrush(Color.FromRgb(255, 0, 127));
            ALLTag.BrushBorder.Value = new SolidColorBrush(Color.FromRgb(255, 0, 127));
            ALLTag.Id = Guid.Parse("00000000-6684-4ce3-ae2e-523989d77d4b");
            collection.Add(ALLTag.Id, ALLTag);
            SpecialTags.Add(ALLTag.Name, ALLTag);
            return ALLTag;
        }
        public static bool Store(ISaveTXT item)
        {
            if (collection.ContainsKey(item.Id))
                return false;
            if(item.Id == default)
                item.Id = Guid.NewGuid();
            collection.Add(item.Id, item);
            return true;
        }

        public static ISaveTXT Find(Guid id)
        {
            if (collection.ContainsKey(id))
                return collection[id];
            return null;
        }

        public static bool ContainsGuid(Guid key)
        {
            return collection.ContainsKey(key);
        }

        public static ISaveTXT GetOrMake<T>(Guid id) where T: class, ISaveTXT, new()
        {
            if (collection.ContainsKey(id))
                return collection[id];
            T ret = new T();
            ret.Id = id;
            collection.Add(ret.Id, ret);
            return ret;
        }

        public static void Init(ManagedCollection<Tag> tags)
        {
            tags.Add(NONETag.Name, NONETag);
            tags.Add(ALLTag.Name, ALLTag);
        }

    }
}
