using Noter.Models.ISaveTXTs;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noter.Models
{
    public class Source : SaveTXTBase
    {
        public string Path { get; set; } = "";
        public Source() { }
        public Source(string name = "")
        {
            Name = name;
        }

        public override string FormatSave(FileSaver fs, int depth)
        {
            return "";
        }

        public override void ParseLoad(string body , int depth)
        {
        }

        public override void PreValChange(object owner)
        {
            (owner as SourceViewModel).FileSaveSource();
        }
        public override void PostValChange(object owner)
        {
            (owner as SourceViewModel).FileLoadSource();
        }
    }
}
