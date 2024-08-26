using System;
using System.Collections.Generic;
using System.Text;

namespace Noter.Models.ISaveTXTs
{
    public abstract class SaveTXTBase : ISaveTXT
    {
        public bool ToDelete { get; set; }
        public int FileId { get; set; } = 0;
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        public void Delete()
        {
            ToDelete = true;
        }

        public abstract string FormatSave(FileSaver fs, int depth);

        public abstract void ParseLoad(string body, int depth);

        public virtual void PostValChange(object owner) { }

        public virtual void PreValChange(object owner) { }
    }
}
