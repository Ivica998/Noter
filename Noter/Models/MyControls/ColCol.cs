using Noter.UserControls;
using Noter.Windows;
using System;
using System.Collections.Generic;
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

namespace Noter.Models.MyControls
{
   [ContentProperty("Items")]
    public partial class ColCol : ListBox
    {


        public ScrollViewer ContainerHolder
        {
            get { return (ScrollViewer)GetValue(ContainerHolderProperty); }
            set { SetValue(ContainerHolderProperty, value); }
        }
        public static readonly DependencyProperty ContainerHolderProperty =
            DependencyProperty.Register("ContainerHolder", typeof(ScrollViewer), typeof(ColCol), new PropertyMetadata(null));
        public StackPanel Container
        {
            get { return (StackPanel)GetValue(ContainerProperty); }
            set { SetValue(ContainerProperty, value); }
        }
        public static readonly DependencyProperty ContainerProperty =
            DependencyProperty.Register("Container", typeof(StackPanel), typeof(ColCol), new PropertyMetadata(null));


        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }
        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(UIElementCollection), typeof(ColCol), new PropertyMetadata(null));


        // public UIElementCollection Children { get { return Container.Children; } }
        static ColCol()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColCol), new FrameworkPropertyMetadata(typeof(ColCol)));
        }

        public override void OnApplyTemplate()
        {
            Button dragger = GetTemplateChild("dragger") as Button;
            dragger.Tag = this;
            Container = GetTemplateChild("container") as StackPanel;
            ContainerHolder = GetTemplateChild("containerHolder") as ScrollViewer;
            Grid g = GetTemplateChild("g2") as Grid;
            g.MouseDown += Button_Click;
            Button b = GetTemplateChild("b1") as Button;
            b.MouseDown += Button_Click;
            Button b2 = GetTemplateChild("b2") as Button;
            b2.MouseDown += Add_Button_Click;
            ContainerHolder.Visibility = Visibility.Collapsed;
            Tag = Container;
            Binding bind = new Binding("Children") { Source = Container };
            SetBinding(ItemsSourceProperty, bind);


            base.OnApplyTemplate();
        }
        public ColCol()
        {
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContainerHolder.Visibility == Visibility.Visible)
                ContainerHolder.Visibility = Visibility.Collapsed;
            else
                ContainerHolder.Visibility = Visibility.Visible;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new ElementCreator(Container).ShowDialog();
        }
    }


    /*
    public class ColCol : Panel
    {
        public static readonly DependencyProperty CollapsedProperty = DependencyProperty.Register(
            name: "Collapsed",
            propertyType: typeof(bool),
            ownerType: typeof(ColCol),
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: false,
                flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                propertyChangedCallback: new PropertyChangedCallback(OnCollapsedChanged))
    // { BindsTwoWayByDefault = true,DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged }
    );
        public bool Collapsed
        {
            get => (bool)GetValue(CollapsedProperty);
            set => SetValue(CollapsedProperty, value);
        }
        private static void OnCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ColCol), new PropertyMetadata(""));
        static ColCol()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColCol), new FrameworkPropertyMetadata(typeof(ColCol)));
        }
        public ColCol()
        {
            Button b = new Button();
            b.Style = FindResource(typeof(Button)) as Style;
            Children.Add(b);
            Collapsed = true;
        }
        private void B_Click(object sender, RoutedEventArgs e)
        {
            Collapsed = !Collapsed;
            UpdateLayout();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size maxSize = new Size();

            foreach (UIElement child in Children)
            {
                child.Measure(availableSize);
                maxSize.Height = Math.Max(child.DesiredSize.Height, maxSize.Height);
                maxSize.Width = Math.Max(child.DesiredSize.Width, maxSize.Width);
            }
            return maxSize;
        }

        // Arrange the child elements to their final position
        protected override Size ArrangeOverride(Size finalSize)
        {
            if(!Collapsed)
            {
                double y =0;
                foreach (UIElement child in Children)
                {
                    child.Arrange(new Rect(0,y,child.DesiredSize.Width,child.DesiredSize.Height));
                    y += child.DesiredSize.Height;
                }
                return finalSize;
            }
            return finalSize;
        }
    }
     */
}
