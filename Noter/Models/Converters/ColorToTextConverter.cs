using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Noter.Models.Converters
{
    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color cast))
                return null;
            return cast.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string cast))
                return null;
            Color color;
            try {
                color = (Color)ColorConverter.ConvertFromString(cast);
            }
            catch (Exception) { }
            return color;
        }
    }
}
