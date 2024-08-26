using System;
using System.Collections.Generic;
using System.Text;

namespace Noter.Models.Extra
{
    public class CollectionClearedEventArgs : EventArgs
    {
        public new static readonly CollectionClearedEventArgs Empty = new CollectionClearedEventArgs();
    }
}
