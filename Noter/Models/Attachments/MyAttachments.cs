using Noter.Models;
using Noter.Models.Commands;
using Noter.Models.Extra;
using Noter.Models.MyControls;
using Noter.UserControls;
using Noter.Utils;
using Noter.ViewModel;
using Noter.Windows;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Noter.Models.Attachments
{
    public class MyAttachments : DependencyObject
    {
        public static DependencyProperty SelectOnEntryProperty = DependencyProperty.RegisterAttached("SelectOnEntry", typeof(bool), typeof(MyAttachments),
           new PropertyMetadata(default(bool), SelectOnEntryChanged));
        public static void SetSelectOnEntry(DependencyObject element, bool value)
        {
            element.SetValue(SelectOnEntryProperty, value);
        }
        public static bool GetSelectOnEntry(DependencyObject element)
        {
            return (bool)element.GetValue(SelectOnEntryProperty);
        }
        private static void SelectOnEntryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue) return;
            var tb = d as TextBox;
            if (tb == null) return;
            tb.PreviewMouseUp += (s, e) =>
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            };
        }

        public static DependencyProperty PressedProperty = DependencyProperty.RegisterAttached("Pressed", typeof(bool), typeof(MyAttachments),
           new PropertyMetadata(default(bool)));
        public static void SetPressed(DependencyObject element, bool value)
        {
            element.SetValue(PressedProperty, value);
        }
        public static bool GetPressed(DependencyObject element)
        {
            return (bool)element.GetValue(PressedProperty);
        }

        public static DependencyProperty ActiveProperty = DependencyProperty.RegisterAttached("Active", typeof(bool),typeof(MyAttachments),
           new PropertyMetadata(default(bool)));
        public static void SetActive(DependencyObject element, bool value)
        {
            element.SetValue(ActiveProperty, value);
        }
        public static bool GetActive(DependencyObject element)
        {
            return (bool)element.GetValue(ActiveProperty);
        }

    }
}
