using Noter.Models.ISaveTXTs;
using Noter.Models.MyControls;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Noter.Models
{
    public class PreviewEntry : SaveTXTBase
    {

        public ObservedType<bool> IsActive { get; set; } = new ObservedType<bool>();
        public string Path { get; set; }
        public ClosableC Element { get; set; }
        public bool Deleted { get; set; }

        public PreviewEntry()
        {
        }

        public PreviewEntry(string name)
        {
            Name = name;
        }

        public override string FormatSave(FileSaver fs,int depth)
        {
            return "";
        }

        public override void ParseLoad(string body, int depth)
        {

        }
    }
}
