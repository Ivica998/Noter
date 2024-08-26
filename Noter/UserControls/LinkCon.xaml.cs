using Noter.Windows;
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

namespace Noter.UserControls
{
    /// <summary>
    /// Interaction logic for LinkCon.xaml
    /// </summary>
    public partial class LinkCon : BaseConC
    {
        private static Brush DefaultBackground;
        private static Brush DefaultForeground;
        private static Brush DefaultBorderBrush;

        static LinkCon()
        {
            Style style = new FrameworkElement().FindResource(typeof(TextBox)) as Style;
            TextBox obj = new TextBox { Style = style };
            DefaultBackground = obj.Background ?? Brushes.Transparent;
            DefaultForeground = obj.Foreground ?? Brushes.Transparent;
            DefaultBorderBrush = obj.BorderBrush ?? Brushes.Transparent;
        }
        public LinkCon()
        {
            InitializeComponent();
            dragger.Tag = this;
            Loaded += TextBoxCon_Loaded;
        }

        private void TextBoxCon_Loaded(object sender, RoutedEventArgs e)
        {
            Background ??= DefaultBackground;
            Foreground ??= DefaultForeground;
            BorderBrush ??= DefaultBorderBrush;
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            //new TextSettingsWindow(this).ShowDialog();
        }
    }
}
