using System;
using System.Collections.Generic;
using System.Text;

namespace Noter.Models.Extra
{
    public class CollectionChangedEventArgs : EventArgs
    {
        public string Key { get; set; }
        public object Item { get; set; }
        public ManagedCollectionCommand Command { get; set; }
    }
}
