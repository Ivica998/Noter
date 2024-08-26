using Noter.Models.ISaveTXTs.ISaveElements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Noter.Utils
{
    public class UIEEMapper
    {
        public IElement Element;
        public UIElement UIElement;
        public UIEEMapper(IElement elem, UIElement uiElem)
        {
            Element = elem;
            UIElement = uiElem;
        }

    }
}
