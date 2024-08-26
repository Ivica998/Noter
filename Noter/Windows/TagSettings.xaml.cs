using Noter.Models;
using Noter.Models.Commands;
using Noter.Models.Converters;
using Noter.Models.MyControls;
using Noter.UserControls;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Noter.Windows
{
    /// <summary>
    /// Interaction logic for ownerSettings.xaml
    /// </summary>
    public partial class TagSettings : Window
    {
        private ICommand esccmd;
        public ICommand ESCCMD
        {
            get
            {
                return esccmd
                    ?? (esccmd = new EmptyCommand(() =>
                    {
                        Close();
                    }));
            }
        }
        private Tag owner;
        public TagSettings(Tag owner)
        {
            this.owner = owner;
            InitializeComponent();
            Loaded += TagSettings_Loaded;
        }
        public Rectangle r1, r2, r3, r4,r5,r6;
        public ObservedType<HexTextBox> htb1 = new ObservedType<HexTextBox>();
        public ObservedType<HexTextBox> htb3 = new ObservedType<HexTextBox>();
        public ObservedType<HexTextBox> htb5 = new ObservedType<HexTextBox>();
        private void TagSettings_Loaded(object sender, RoutedEventArgs e)
        {
            UIElementCollection Collection = start.container.Children[0].Cast<ColColC>().Children;
            Grid colorGrid = Collection[0].Cast<GroupBox>().Content as Grid;
            ColorSetup(colorGrid);

        }

        private void ColorSetup(Grid colorGrid)
        {
            htb1.Value = colorGrid.Children[3] as HexTextBox;
            htb3.Value = colorGrid.Children[4] as HexTextBox;
            htb5.Value = colorGrid.Children[5] as HexTextBox;
            r1 = colorGrid.Children[6] as Rectangle;
            r2 = colorGrid.Children[7] as Rectangle;
            r3 = colorGrid.Children[8] as Rectangle;
            r4 = colorGrid.Children[9] as Rectangle;
            r5 = colorGrid.Children[10] as Rectangle;
            r6 = colorGrid.Children[11] as Rectangle;
            string val1, val2, val3;
            val1 = owner.BrushBG.Value.Cast<SolidColorBrush>().Color.ToString();
            val2 = owner.BrushFG.Value.Cast<SolidColorBrush>().Color.ToString();
            val3 = owner.BrushBorder.Value.Cast<SolidColorBrush>().Color.ToString();
            r1.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(val1));
            r3.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(val2));
            r5.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(val3));
            r2.Fill = owner.BrushBG.Value;
            r4.Fill = owner.BrushFG.Value;
            r6.Fill = owner.BrushBorder.Value;
            Binding bind1 = new Binding() { Source = r1.Fill, Mode = BindingMode.OneWayToSource, Path = new PropertyPath(SolidColorBrush.ColorProperty), Converter = new ColorToTextConverter(), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            htb1.Value.SetBinding(HexTextBox.TextProperty, bind1);
            Binding bind2 = new Binding() { Source = r3.Fill, Mode = BindingMode.OneWayToSource, Path = new PropertyPath(SolidColorBrush.ColorProperty), Converter = new ColorToTextConverter(), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            htb3.Value.SetBinding(HexTextBox.TextProperty, bind2);
            Binding bind3 = new Binding() { Source = r5.Fill, Mode = BindingMode.OneWayToSource, Path = new PropertyPath(SolidColorBrush.ColorProperty), Converter = new ColorToTextConverter(), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            htb5.Value.SetBinding(HexTextBox.TextProperty, bind3);

            htb1.Value.Text = val1;
            htb3.Value.Text = val2;
            htb5.Value.Text = val3;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            r2.Fill = r1.Fill.Clone() as SolidColorBrush;
            r4.Fill = r3.Fill.Clone() as SolidColorBrush;
            r6.Fill = r5.Fill.Clone() as SolidColorBrush;
            owner.BrushBG.Value = r2.Fill as SolidColorBrush;
            owner.BrushFG.Value= r4.Fill as SolidColorBrush;
            owner.BrushBorder.Value = r6.Fill as SolidColorBrush;
        } 
    }
}
