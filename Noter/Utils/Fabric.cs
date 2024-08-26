using Noter.Models.MyControls;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Noter.Utils
{
    public class Fabric
    {

        private static Button xButton;
        public static void MakeNONEInstance(TagSearchViewModel VModel)
        {
            VModel.UIE_NONE = new TagC() { KeyName = "NONE", BorderBrush = Brushes.Gold, Background = Brushes.DarkRed, IsEnabled = false, FontSize = 16, IsTabStop = false, TagLink = GuidManager.NONETag };
        }

        public static Button GetXButton()
        {
            if (xButton == null)
            {
                Button but = new Button();
                Image img = new Image();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"..\..\..\Images\iks.png", UriKind.Relative);
                bitmap.EndInit();
                img.Source = bitmap;
                but.Style = but.FindResource("ImgButton") as Style;
                but.Height = 12;
                but.Width = 12;
                but.Opacity = 1;
                but.Content = img;
                but.HorizontalAlignment = HorizontalAlignment.Right;
                but.VerticalAlignment = VerticalAlignment.Top;
                but.Click += X_Click;
                xButton = but;
            }
            return xButton;
        }

        public static void X_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            ClosableC closableC = (b.Parent as Grid).TemplatedParent as ClosableC;
            Panel panel = closableC.Parent as Panel;
            panel.Children.Remove(closableC);
            closableC.Close();
        }
    }
}
