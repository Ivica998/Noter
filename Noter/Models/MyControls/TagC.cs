using Noter.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Noter.Models.MyControls
{
    public class TagC : ClosableC
    {
        public Tag TagLink { get; set; }
        static TagC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TagC), new FrameworkPropertyMetadata(typeof(TagC)));
        }

        public TagC()
        {

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
