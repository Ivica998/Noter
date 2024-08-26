using Noter.Models.Attachments;
using Noter.Models.Converters;
using Noter.Utils;
using Noter.ViewModel;
using Noter.Windows;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Noter.UserControls {
    /// <summary>
    /// Interaction logic for ColColC.xaml
    /// </summary>
    [ContentProperty("Children")]
    public partial class ColColC : BaseConC {
        public static Brush DefaultBackground;
        public static Brush DefaultForeground;
        public static Brush DefaultBorderBrush;

        public ChangBrushConv BorderFixer = new ChangBrushConv();
        public ChangBrushConv BackgroundFixer = new ChangBrushConv();
        public ChangBrushConv ForegroundFixer = new ChangBrushConv();

        static ColColC() {
            Style style = new FrameworkElement().FindResource(typeof(ColColC)) as Style;
            ColColC obj = new ColColC() { Style = style };
            DefaultBackground = obj.Background ?? Brushes.Transparent;
            DefaultForeground = obj.Foreground ?? Brushes.Transparent;
            DefaultBorderBrush = obj.BorderBrush ?? Brushes.Transparent;
        }


        public bool IsCollapsed {
            get { return (bool)GetValue(IsCollapsedProperty); }
            set { SetValue(IsCollapsedProperty, value); }
        }
        public static readonly DependencyProperty IsCollapsedProperty =
            DependencyProperty.Register("IsCollapsed", typeof(bool), typeof(ColColC), new PropertyMetadata(true, IsCollapsedChanged));
        private static void IsCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            Visibility temp;
            ColColC obj = d as ColColC;
            if (!(e.NewValue is bool cast))
                return;
            if (cast)
                temp = Visibility.Collapsed;
            else
                temp = Visibility.Visible;
            obj.Loaded += (object sender, RoutedEventArgs e) => {
                obj.containerHolder.Visibility = temp;
            };
        }

        public string Header {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ColColC), new PropertyMetadata("", OnHeaderChanged));
        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ColColC obj = d as ColColC;
            if (e.NewValue is null)
                obj.Header = "";
            return;
        }
        public Brush ProxyBorderBrush {
            get { return (Brush)GetValue(ProxyBorderBrushProperty); }
            set { SetValue(ProxyBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty ProxyBorderBrushProperty =
            DependencyProperty.Register("ProxyBorderBrush", typeof(Brush), typeof(ColColC), new PropertyMetadata(Brushes.Transparent, ProxyBorderBrushChanged));
        private static void ProxyBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ColColC obj = d as ColColC;
            if (!(e.NewValue is SolidColorBrush cast))
                return;
            obj.BorderFixer.OldValue = cast;
            obj.SetCurrentValue(BorderBrushProperty, e.NewValue);
        }
        public Brush ProxyBackground {
            get { return (Brush)GetValue(ProxyBackgroundProperty); }
            set { SetValue(ProxyBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ProxyBackgroundProperty =
            DependencyProperty.Register("ProxyBackground", typeof(Brush), typeof(ColColC), new PropertyMetadata(Brushes.Transparent, ProxyBackgorundChanged));
        private static void ProxyBackgorundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ColColC obj = d as ColColC;
            if (!(e.NewValue is SolidColorBrush cast))
                return;
            obj.BackgroundFixer.OldValue = cast;
            obj.SetCurrentValue(BackgroundProperty, e.NewValue);
        }
        public Brush ProxyForeground {
            get { return (Brush)GetValue(ProxyForegroundProperty); }
            set { SetValue(ProxyForegroundProperty, value); }
        }
        public static readonly DependencyProperty ProxyForegroundProperty =
            DependencyProperty.Register("ProxyForeground", typeof(Brush), typeof(ColColC), new PropertyMetadata(Brushes.Transparent, ProxyForegroundChanged));
        private static void ProxyForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ColColC obj = d as ColColC;
            if (!(e.NewValue is SolidColorBrush cast))
                return;
            obj.ForegroundFixer.OldValue = cast;
            obj.SetCurrentValue(ForegroundProperty, e.NewValue);
        }

        public UIElementCollection Children { get { return container.Children; } }
        public ColColC() {
            InitializeComponent();
            containerHolder.Visibility = Visibility.Collapsed;
            Tag = container;
            Loaded += ColColC_Loaded;
            dragger.Tag = this;
            SetDefaults();
        }

        private void ColColC_Loaded(object sender, RoutedEventArgs e) {
            Loaded -= ColColC_Loaded;
            ProxyBorderBrush = BorderBrush ??= DefaultBorderBrush;
            ProxyBackground = Background ??= DefaultBackground;
            ProxyForeground = Foreground ??= DefaultForeground;
            Style stil = new Style(typeof(ColColC), FindResource(typeof(ColColC)) as Style);
            Setter sett = new Setter() {
                Property = Control.BorderBrushProperty,
                Value = new Binding() { RelativeSource = RelativeSource.Self, Path = new PropertyPath(ColColC.ProxyBorderBrushProperty), Mode = BindingMode.OneWay, }//Converter = BorderFixer }
            };
            Setter sett2 = new Setter() {
                Property = Control.BackgroundProperty,
                Value = new Binding() { RelativeSource = RelativeSource.Self, Path = new PropertyPath(ColColC.ProxyBackgroundProperty), Mode = BindingMode.OneWay, }//Converter = BackgroundFixer }
            };
            Setter sett3 = new Setter() {
                Property = Control.ForegroundProperty,
                Value = new Binding() { RelativeSource = RelativeSource.Self, Path = new PropertyPath(ColColC.ProxyForegroundProperty), Mode = BindingMode.OneWay, }//Converter = ForegroundFixer }
            };
            Trigger trigg = new Trigger() {
                Property = MyAttachments.ActiveProperty,
                Value = false,
            };
            Trigger ihtvt = FindResource("IsHitTestVisibleTrigger") as Trigger;
            trigg.Setters.Add(sett);
            trigg.Setters.Add(sett2);
            trigg.Setters.Add(sett3);
            stil.Triggers.Add(trigg);
            stil.Triggers.Add(ihtvt);
            this.Style = stil;


            /*
            ChangBrushConv cbc = this.Style.Triggers[1].Cast<Trigger>().Setters[0].Cast<Setter>().Value.Cast<Binding>().Converter as ChangBrushConv;
            stil.Triggers[0].Cast<Trigger>().Setters.Add(sett);
            Binding bind2 = new Binding()
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ColColC), 1),
                Mode = BindingMode.OneWay
            };
            BindingOperations.SetBinding(this, ChangBrushConv.OwnerProperty, bind2);
             */
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (containerHolder.Visibility == Visibility.Visible)
                containerHolder.Visibility = Visibility.Collapsed;
            else
                containerHolder.Visibility = Visibility.Visible;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e) {
            new ElementCreator(container).ShowDialog();
        }

        private void settings_Click(object sender, RoutedEventArgs e) {
            new SettingsWindow(this).ShowDialog();
        }

        private void Grid_Click(object sender, MouseButtonEventArgs e) {
            Button_Click(sender, e);
        }

        public static void LoadPreferenes(string input) {
            string[] parts = input.Split("##|");
            int counter = 0;
            DefaultBackground= new SolidColorBrush((Color)ColorConverter.ConvertFromString(parts[counter++].Unescape()));
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
