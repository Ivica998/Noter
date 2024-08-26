using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Noter.Models.ISaveTXTs.ISaveElements
{
    public class UIEEUnion
    {
        public string ElementString;
        public Type UIElementType;
        public UIEEUnion(string elemString, Type uiElemType)
        {
            ElementString = elemString;
            UIElementType = uiElemType;
        }
    }
}
