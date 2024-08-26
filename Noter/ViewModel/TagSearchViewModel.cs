using Noter.Models;
using Noter.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Noter.ViewModel
{
    public class TagSearchViewModel
    {
        public ManagedCollection<Tag> Tags { get; set; }
        public Panel Panel { get; set; }
        public Action<int> ErrorHandler { get; set; }
        public Action<int> AfterTagsChangeHandler { get; set; }
        public UIElement UIE_NONE { get; set; }
        public Action<TagSearchViewModel> Init { get; set; }
    }
}
