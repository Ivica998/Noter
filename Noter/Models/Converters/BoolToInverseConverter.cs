using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Noter.Models.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public sealed class BoolToInverseConverter : IValueConverter
    {

        public BoolToInverseConverter()
        {
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (!(value is bool cast))
                return null;
            return !cast;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (!(value is bool cast))
                return null;
            return !cast;
        }
    }
}
