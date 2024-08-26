using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Noter.Models.Converters
{
    [ValueConversion(typeof(double), typeof(int))]
    public class UGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int step = 50;
            if (parameter != null)
                int.TryParse(parameter as string, out step);
            double length = (double)value;
            int dimNum = (int)(length / step);
            return dimNum;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
