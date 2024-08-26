using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Noter.Utils
{
    public class ColorHelper
    {
        public LinearGradientBrush MakeLGBrush(Color color, Point start, Point end, int stops = 10)
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            for (int i = 0; i <= stops; i++)
            {
                brush.GradientStops.Add(new GradientStop(color, (double)i / stops));
            }
            return brush;
        }
    }
}
