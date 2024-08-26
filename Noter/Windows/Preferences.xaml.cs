using Noter.Models;
using Noter.Models.Commands;
using Noter.Models.Converters;
using Noter.Models.MyControls;
using Noter.UserControls;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Noter.Windows {
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class Preferences : Window {
        private ICommand esccmd;
        public ICommand ESCCMD {
            get {
                return esccmd
                    ?? (esccmd = new EmptyCommand(() => {
                        Close();
                    }));
            }
        }
        public Preferences() {
            InitializeComponent();
            Loaded += TagSettings_Loaded;
        }
        public ColorPrefData cpd1 = new ColorPrefData();
        public ColorPrefData cpd2 = new ColorPrefData();

        private void TagSettings_Loaded(object sender, RoutedEventArgs e) {
            Loaded -= TagSettings_Loaded;
            UIElementCollection Collection = start.container.Children[0].Cast<ColColC>().Children;
            Grid colorGrid1 = Collection[0].Cast<GroupBox>().Content as Grid;
            ColorSetup(colorGrid1, typeof(ColColC), cpd1);
            Grid colorGrid2 = Collection[1].Cast<GroupBox>().Content as Grid;
            ColorSetup(colorGrid2, typeof(TextBoxCon), cpd2);

        }

        private void ColorSetup(Grid colorGrid, Type type, ColorPrefData cpd) {
            BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;
            FieldInfo BGFI = type.GetField("DefaultBackground", flags);
            FieldInfo FGFI = type.GetField("DefaultForeground", flags);
            FieldInfo BBFI = type.GetField("DefaultBorderBrush", flags);

            cpd.htb1.Value = colorGrid.Children[3] as HexTextBox;
            cpd.htb3.Value = colorGrid.Children[4] as HexTextBox;
            cpd.htb5.Value = colorGrid.Children[5] as HexTextBox;
            cpd.r1 = colorGrid.Children[6] as Rectangle;
            cpd.r2 = colorGrid.Children[7] as Rectangle;
            cpd.r3 = colorGrid.Children[8] as Rectangle;
            cpd.r4 = colorGrid.Children[9] as Rectangle;
            cpd.r5 = colorGrid.Children[10] as Rectangle;
            cpd.r6 = colorGrid.Children[11] as Rectangle;
            string val1, val2, val3;
            val1 = BGFI.GetValue(null).Cast<SolidColorBrush>().Color.ToString();
            val2 = FGFI.GetValue(null).Cast<SolidColorBrush>().Color.ToString();
            val3 = BBFI.GetValue(null).Cast<SolidColorBrush>().Color.ToString();
            cpd.r1.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(val1));
            cpd.r3.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(val2));
            cpd.r5.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(val3));
            cpd.r2.Fill = BGFI.GetValue(null).Cast<SolidColorBrush>();
            cpd.r4.Fill = FGFI.GetValue(null).Cast<SolidColorBrush>();
            cpd.r6.Fill = BBFI.GetValue(null).Cast<SolidColorBrush>();
            var temp = ColColC.DefaultForeground;
            var temp2 = TextBoxCon.DefaultForeground;
            Binding bind1 = new Binding() { Source = cpd.r1.Fill, Mode = BindingMode.OneWayToSource, Path = new PropertyPath(SolidColorBrush.ColorProperty), Converter = new ColorToTextConverter(), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            cpd.htb1.Value.SetBinding(HexTextBox.TextProperty, bind1);
            Binding bind2 = new Binding() { Source = cpd.r3.Fill, Mode = BindingMode.OneWayToSource, Path = new PropertyPath(SolidColorBrush.ColorProperty), Converter = new ColorToTextConverter(), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            cpd.htb3.Value.SetBinding(HexTextBox.TextProperty, bind2);
            Binding bind3 = new Binding() { Source = cpd.r5.Fill, Mode = BindingMode.OneWayToSource, Path = new PropertyPath(SolidColorBrush.ColorProperty), Converter = new ColorToTextConverter(), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            cpd.htb5.Value.SetBinding(HexTextBox.TextProperty, bind3);

            cpd.htb1.Value.Text = val1;
            cpd.htb3.Value.Text = val2;
            cpd.htb5.Value.Text = val3;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            cpd1.r2.Fill = cpd1.r1.Fill.Clone() as SolidColorBrush;
            cpd1.r4.Fill = cpd1.r3.Fill.Clone() as SolidColorBrush;
            cpd1.r6.Fill = cpd1.r5.Fill.Clone() as SolidColorBrush;
            ColColC.DefaultBackground = cpd1.r2.Fill as SolidColorBrush;
            ColColC.DefaultForeground = cpd1.r4.Fill as SolidColorBrush;
            ColColC.DefaultBorderBrush = cpd1.r6.Fill as SolidColorBrush;
        }

        private void Button_Click2(object sender, RoutedEventArgs e) {
            cpd2.r2.Fill = cpd2.r1.Fill.Clone() as SolidColorBrush;
            cpd2.r4.Fill = cpd2.r3.Fill.Clone() as SolidColorBrush;
            cpd2.r6.Fill = cpd2.r5.Fill.Clone() as SolidColorBrush;
            TextBoxCon.DefaultBackground = cpd2.r2.Fill as SolidColorBrush;
            TextBoxCon.DefaultForeground = cpd2.r4.Fill as SolidColorBrush;
            TextBoxCon.DefaultBorderBrush = cpd2.r6.Fill as SolidColorBrush;
        }
    }
}

public class ColorPrefData {
    public Rectangle r1, r2, r3, r4, r5, r6;
    public ObservedType<HexTextBox> htb1 = new ObservedType<HexTextBox>();
    public ObservedType<HexTextBox> htb3 = new ObservedType<HexTextBox>();
    public ObservedType<HexTextBox> htb5 = new ObservedType<HexTextBox>();
}