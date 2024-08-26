using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Noter.Models.Converters
{
    [ValueConversion(typeof(Color), typeof(Color))]
    class ColorTemplateCreator : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<object> list = parameter as List<object>;
            Color color = (Color)value;
            LinearGradientBrush newColor = new LinearGradientBrush();
            double points = 10;
            for (int i = 0; i < points; i++)
            {
                newColor.GradientStops.Add(new GradientStop(color, i / points));
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
