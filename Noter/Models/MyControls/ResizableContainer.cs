using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Noter.Models.MyControls
{
    [ContentProperty("Content")]
    public class ResizableContainer : ContentControl
    {
        public object MainContent
        {
            get { return GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }

        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register("MainContent", typeof(object), typeof(ResizableContainer), null);
        static ResizableContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizableContainer), new FrameworkPropertyMetadata(typeof(ResizableContainer)));
        }

        public ResizableContainer()
        {
            Loaded += ResizableContainer_Loaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        private void ResizableContainer_Loaded(object sender, RoutedEventArgs e)
        {

            switch (HorizontalResize)
            {
                case HRE.Left:
                    SetLeft(this);
                    break;
                case HRE.Right:
                    SetRight(this);
                    break;
                case HRE.Both:
                    SetTop(this);
                    SetBottom(this);
                    break;
                default: break;
            }
            switch (VerticalResize)
            {
                case VRE.Top:
                    SetTop(this);
                    break;
                case VRE.Bottom:
                    SetBottom(this);
                    break;
                case VRE.Both:
                    SetLeft(this);
                    SetRight(this);
                    break;
                default: break;
            }
            CheckSetDiagonals(this);
        }

        public enum VRE
        {
            None = 0x0, Top = 0x1, Bottom = 0x2, Both = 0x3
        }
        public enum HRE
        {
            None = 0x0, Left = 0x4, Right = 0x8, Both = 0xC
        }

        public HRE HorizontalResize
        {
            get { return (HRE)GetValue(HorizontalResizeProperty); }
            set { SetValue(HorizontalResizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HorizontalResize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalResizeProperty =
            DependencyProperty.Register("HorizontalResize", typeof(HRE), typeof(ResizableContainer), new PropertyMetadata(default(HRE), OnHorizontalResizeChanged));

        private static void OnHorizontalResizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is HRE cast))
                return;
            ResizableContainer rc = d as ResizableContainer;
        }

        public VRE VerticalResize
        {
            get { return (VRE)GetValue(VerticalResizeProperty); }
            set { SetValue(VerticalResizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VerticalResize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalResizeProperty =
            DependencyProperty.Register("VerticalResize", typeof(VRE), typeof(ResizableContainer), new PropertyMetadata(default(VRE), OnVerticalResizeChanged));

        private static void OnVerticalResizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is VRE cast))
                return;
            ResizableContainer rc = d as ResizableContainer;
            
        }

        private static void SetTop(ResizableContainer rc)
        {
            Resizer r = new Resizer() { Object = rc, ResizeDirection = Resizer.RDEnum.N };
            Grid g = rc.GetTemplateChild("g1") as Grid;
            g.Children.Add(r);
            Grid.SetRow(r, 0);
            Grid.SetColumn(r, 1);
        }
        private static void SetBottom(ResizableContainer rc)
        {
            Resizer r = new Resizer() { Object = rc, ResizeDirection = Resizer.RDEnum.S };
            Grid g = rc.GetTemplateChild("g1") as Grid;
            g.Children.Add(r);
            Grid.SetRow(r, 2);
            Grid.SetColumn(r, 1);
        }
        private static void SetLeft(ResizableContainer rc)
        {
            Resizer r = new Resizer() { Object = rc, ResizeDirection = Resizer.RDEnum.W};
            Binding binding = new Binding();
            Grid g = rc.GetTemplateChild("g1") as Grid;
            g.Children.Add(r);
            Grid.SetRow(r, 1);
            Grid.SetColumn(r, 0);
        }
        private static void SetRight(ResizableContainer rc)
        {
            Resizer r = new Resizer() { Object = rc, ResizeDirection = Resizer.RDEnum.E };
            Grid g = rc.GetTemplateChild("g1") as Grid;
            g.Children.Add(r);
            Grid.SetRow(r, 1);
            Grid.SetColumn(r, 2);
        }

        private static void CheckSetDiagonals(ResizableContainer rc)
        {
            byte HR = (byte)rc.HorizontalResize;
            byte VR = (byte)rc.VerticalResize;
            if (HR == 0 || VR == 0)
                return;
            byte flags = (byte)(HR | VR);
            byte check;
            check = (byte)HRE.Left | (byte)VRE.Top;
            if ((flags & check) == check)
                SetDiagonal(rc, check);
            check = (byte)HRE.Right | (byte)VRE.Top;
            if ((flags & check) == check)
                SetDiagonal(rc, check);
            check = (byte)HRE.Left | (byte)VRE.Bottom;
            if ((flags & check) == check)
                SetDiagonal(rc, check);
            check = (byte)HRE.Right | (byte)VRE.Bottom;
            if ((flags & check) == check)
                SetDiagonal(rc, check);
        }

        private static void SetDiagonal(ResizableContainer rc, byte check)
        {
            Resizer r = new Resizer() { Object = rc, ResizeDirection = (Resizer.RDEnum)check };
            Grid g = rc.GetTemplateChild("g1") as Grid;
            g.Children.Add(r);
            Grid.SetRow(r, ((1 & check) == 1) ? 0 : 2);
            Grid.SetColumn(r, ((4 & check) == 4) ? 0 : 2);
        }

    }
}
