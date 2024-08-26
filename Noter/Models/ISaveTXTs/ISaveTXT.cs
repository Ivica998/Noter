using System;
using System.Collections.Generic;
using System.Text;

namespace Noter.Models
{
    public interface ISaveTXT
    {
        public int FileId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FormatSave(FileSaver fs, int depth);

        public void ParseLoad(string body, int depth);
        public void PreValChange(object owner);
        public void PostValChange(object owner);
        void Delete();
    }
}
