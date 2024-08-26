using Noter.Utils;
using Noter.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Noter.UserControls {
    /// <summary>
    /// Interaction logic for TextBoxCon.xaml
    /// </summary>
    public partial class TextBoxCon : BaseConC {

        public static Brush DefaultBackground;
        public static Brush DefaultForeground;
        public static Brush DefaultBorderBrush;
        static TextBoxCon() {
            Style style = new FrameworkElement().FindResource(typeof(TextBox)) as Style;
            TextBox obj = new TextBox { Style = style };
            DefaultBackground = obj.Background ?? Brushes.Transparent;
            DefaultForeground = obj.Foreground ?? Brushes.Transparent;
            DefaultBorderBrush = obj.BorderBrush ?? Brushes.Transparent;
        }
        public TextBoxCon() {
            InitializeComponent();
            dragger.Tag = this;
            Loaded += TextBoxCon_Loaded;
            SetDefaults();
        }

        private void TextBoxCon_Loaded(object sender, RoutedEventArgs e) {
            /*
             */
            Background ??= DefaultBackground;
            Foreground ??= DefaultForeground;
            BorderBrush ??= DefaultBorderBrush;
        }

        private void settings_Click(object sender, RoutedEventArgs e) {
            new TextSettingsWindow(this).ShowDialog();
        }

        public static void LoadPreferenes(string input) {
            string[] parts = input.Split("##|");
            int counter = 0;
            DefaultBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(parts[counter++].Unescape()));
            DefaultForeground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(parts[counter++].Unescape()));
            DefaultBorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(parts[counter++].Unescape()));
        }

        public static string SavePreferences() {
            StringBuilder sb = new StringBuilder();
            string term = "##|";
            sb.Append(DefaultBackground.Cast<SolidColorBrush>().Color.ToString().Escape() + term);
            sb.Append(DefaultForeground.Cast<SolidColorBrush>().Color.ToString().Escape() + term);
            sb.Append(DefaultBorderBrush.Cast<SolidColorBrush>().Color.ToString().Escape() + term);
            sb.Append("##\n");
            return sb.ToString();
        }

        public void SetDefaults() {
            SetCurrentValue(BackgroundProperty, DefaultBackground);
            SetCurrentValue(ForegroundProperty, DefaultForeground);
            SetCurrentValue(BorderBrushProperty, DefaultBorderBrush);
        }
    }
}
