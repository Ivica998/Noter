using Noter.Utils;
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

namespace Noter.Models.MyControls
{
    public class ClosableC : Control
    {
        public string KeyName
        {
            get { return (string)GetValue(KeyNameProperty); }
            set { SetValue(KeyNameProperty, value); }
        }
        public static readonly DependencyProperty KeyNameProperty =
            DependencyProperty.Register("KeyName", typeof(string), typeof(ClosableC), new PropertyMetadata(""));
        public bool ButtonIsEnabled
        {
            get { return (bool)GetValue(ButtonIsEnabledProperty); }
            set { SetValue(ButtonIsEnabledProperty, value); }
        }
        public static readonly DependencyProperty ButtonIsEnabledProperty =
            DependencyProperty.Register("ButtonIsEnabled", typeof(bool), typeof(ClosableC), new PropertyMetadata(true));

        public Button InnerButton { get; set; } = new Button();

        static ClosableC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClosableC), new FrameworkPropertyMetadata(typeof(ClosableC)));
        }

        public event EventHandler<RoutedEventArgs> Click;
        public event EventHandler<EventArgs> Closed;

        public ClosableC()
        {
        }
        public void Close()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Grid g = GetTemplateChild("grid") as Grid;
            g.MouseEnter += itemGrid_Enter;
            g.MouseLeave += itemGrid_Leave;
            Button b = GetTemplateChild("button") as Button;
            InnerButton = b;
            Binding bind = new Binding("ButtonIsEnabled") { Source = this };
            b.SetBinding(IsEnabledProperty, bind);
            b.Click += B_Click;
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Click(sender, e);
        }

        private static void itemGrid_Enter(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            Border item = grid.Parent as Border;
            var list = grid.Children;
            list.Add(Fabric.GetXButton());
            item.BorderBrush = item.FindResource("Button_Hovered_FG") as SolidColorBrush;
        }
        private static void itemGrid_Leave(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            Border item = grid.Parent as Border;
            var list = grid.Children;
            list.RemoveAt(1);
            item.BorderBrush = Brushes.Transparent;
        }
    }
}
