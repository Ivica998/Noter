using Noter.Models.Attachments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Noter.Models.MyControls
{
    [DesignTimeVisible]
    public class Resizer : Thumb
    {
        static Resizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Resizer), new FrameworkPropertyMetadata(typeof(Resizer)));
        }

        public Resizer()
        {
            DragStarted += onDragStarted;
            DragCompleted += onDragCompleted;
            DragDelta += onDragDelta;
        }

        public RDEnum ResizeDirection
        {
            get { return (RDEnum)GetValue(ResizeDirectionProperty); }
            set { SetValue(ResizeDirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResizeDirection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResizeDirectionProperty =
            DependencyProperty.Register("ResizeDirection", typeof(RDEnum), typeof(Resizer), new PropertyMetadata(OnResizeDirectionChanged));

        private static void OnResizeDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Resizer resizer = d as Resizer;
            if (!(e.NewValue is RDEnum rde))
                return;
            switch(rde)
            {
                case RDEnum.N:
                case RDEnum.S:
                    resizer.Cursor = Cursors.SizeNS;
                    break;
                case RDEnum.W:
                case RDEnum.E:
                    resizer.Cursor = Cursors.SizeWE;
                    break;
                case RDEnum.NW:
                case RDEnum.SE:
                    resizer.Cursor = Cursors.SizeNWSE;
                    break;
                case RDEnum.NE:
                case RDEnum.SW:
                    resizer.Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        public DependencyObject Object
        {
            get { return (DependencyObject)GetValue(ObjectProperty); }
            set { SetValue(ObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Object.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectProperty =
            DependencyProperty.Register("Object", typeof(DependencyObject), typeof(Resizer), new PropertyMetadata(null,OnObjectChanged));

        private static void OnObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public enum RDEnum
        {
            W = 0x1,
            E = 0x2,
            N = 0x4,
            S = 0x8,
            NW = 0x5,
            NE = 0x6,
            SW = 0x9,
            SE = 0xA,
        }

        private void onDragStarted(object sender, DragStartedEventArgs e)
        {
            MyAttachments.SetActive(this, true);
        }

        private void onDragCompleted(object sender, DragCompletedEventArgs e)
        {
            MyAttachments.SetActive(this, false);
        }

        private void onDragDelta(object sender, DragDeltaEventArgs e)
        {
            
            if (Object == null)
                return;
            DependencyObject dp = Object;
            switch(ResizeDirection)
            {
                case RDEnum.W:
                    ResizeW(dp, e);
                    break;
                case RDEnum.NW:
                    ResizeN(dp, e);
                    ResizeW(dp, e);
                    break;
                case RDEnum.N:
                    ResizeN(dp, e);
                    break;
                case RDEnum.NE:
                    ResizeN(dp, e);
                    ResizeE(dp, e);
                    break;
                case RDEnum.E:
                    ResizeE(dp, e);
                    break;
                case RDEnum.SE:
                    ResizeS(dp, e);
                    ResizeE(dp, e);
                    break;
                case RDEnum.S:
                    ResizeS(dp, e);
                    break;
                case RDEnum.SW:
                    ResizeS(dp, e);
                    ResizeW(dp, e);
                    break;
            }
        }


        public static object ResizeN(DependencyObject dp, DragDeltaEventArgs e)
        {
            double yadjust = (double)dp.GetValue(ActualHeightProperty) - e.VerticalChange;
            if (yadjust >= 0)
            {
                dp.SetValue(HeightProperty, yadjust);
            }
            return dp;
        }

        public static object ResizeS(DependencyObject dp, DragDeltaEventArgs e)
        {
            double yadjust = (double)dp.GetValue(ActualHeightProperty) + e.VerticalChange;
            if (yadjust >= 0)
            {
                dp.SetValue(HeightProperty, yadjust);
            }
            return dp;
        }
        public static object ResizeE(DependencyObject dp, DragDeltaEventArgs e)
        {
            double xadjust = (double)dp.GetValue(ActualWidthProperty) + e.HorizontalChange;
            if (xadjust >= 0)
            {
                dp.SetValue(WidthProperty, xadjust);
            }
            return dp;
        }
        public static object ResizeW(DependencyObject dp, DragDeltaEventArgs e)
        {
            double xadjust = (double)dp.GetValue(ActualWidthProperty) - e.HorizontalChange;
            if (xadjust >= 0)
            {
                dp.SetValue(WidthProperty, xadjust);
            }
            return dp;
        }

    }
}
