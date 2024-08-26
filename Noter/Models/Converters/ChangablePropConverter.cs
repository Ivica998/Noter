using Noter.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Noter.Models.Converters
{
    [ValueConversion(typeof(object), typeof(object))]
    public class ChangablePropConverter<T> : DependencyObject, IValueConverter where T : new()
    {
        public object OldValue
        {
            get { return (object)GetValue(OldValueProperty); }
            set { SetValue(OldValueProperty, value); }
        }
        public static readonly DependencyProperty OldValueProperty =
            DependencyProperty.Register("OldValue", typeof(object), typeof(ChangablePropConverter<T>), new FrameworkPropertyMetadata(null, OldValueChanged)
            {
                //BindsTwoWayByDefault = false,
                //DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
        private static void OldValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChangablePropConverter<T> obj = (ChangablePropConverter<T>)d;
            return;
        }
        public ChangablePropConverter() { }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] para;
            if (parameter != null)
                para = (parameter as string).Split('|');

            return (T)OldValue ?? value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is T cast))
                return null;
            return cast;
        }
    }
}
