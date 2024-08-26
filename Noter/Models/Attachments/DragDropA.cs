using Noter.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Noter.Models.Attachments
{
    public class DragDropA : DependencyObject
    {
        /*
         */
        public static DependencyProperty AllowCDragProperty = DependencyProperty.RegisterAttached(
           "AllowCDrag", typeof(bool), typeof(DragDropA), new PropertyMetadata(default(bool), OnAllowCDragLoaded));

        public static DependencyProperty AllowCDropProperty = DependencyProperty.RegisterAttached(
           "AllowCDrop", typeof(bool), typeof(DragDropA), new PropertyMetadata(default(bool), OnAllowCDropLoaded));

        private static void OnAllowCDragLoaded(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var obj = sender as UIElement;
            if (obj == null || !(e.NewValue is bool))
                return;
            if ((bool)e.NewValue)
            {
                obj.PreviewMouseDown += Draggable_PrevMouseDown;
                obj.QueryContinueDrag += Draggable_QueryContinueDrag;
            }
            else
            {
                obj.QueryContinueDrag -= Draggable_QueryContinueDrag;
            }
        }
        private static void OnAllowCDropLoaded(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var obj = sender as UIElement;
            if (obj == null || !(e.NewValue is bool))
                return;
            if ((bool)e.NewValue)
            {
                prewImages.Add(obj, new Image() { IsHitTestVisible = false, Opacity = 0.7 });
                offsets.Add(obj, new Point());
                obj.AllowDrop = true;
                obj.Drop += Panel_Drop;
                obj.DragOver += Panel_DragOver;
                obj.DragEnter += Panel_DragEnter;
                obj.DragLeave += Panel_DragLeave;
            }
            else
            {
                prewImages.Remove(obj);
                offsets.Remove(obj);
                obj.Drop -= Panel_Drop;
                obj.DragOver -= Panel_DragOver;
                obj.DragEnter -= Panel_DragEnter;
                obj.DragLeave -= Panel_DragLeave;
            }

        }
        private static void Draggable_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
            }
        }
        private static void Draggable_PrevMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point offset;
            Button but = sender as Button;
            Control control = but.Tag as Control;
            //icon.Focus();
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                dummyUIE.Width = double.NaN;
                dummyUIE.Height = control.ActualHeight;

                offset = e.GetPosition(control);
                DataObject data = new DataObject();
                data.SetData("offset", offset);
                data.SetData("control", control);
                control.IsHitTestVisible = false;
                DragDrop.DoDragDrop(control, data, DragDropEffects.Move);
                control.IsHitTestVisible = true;
                foreach (var item in active)
                {
                    MyAttachments.SetActive(item, false);
                }
            }
        }



        private static Dictionary<object, Image> prewImages = new Dictionary<object, Image>() { };
        private static Dictionary<object, Point> offsets = new Dictionary<object, Point>() { };
        private static Control dummyUIE = new Control() { Style = Application.Current.FindResource("DragDropDummyStyle") as Style, IsHitTestVisible=false };
        public static HashSet<UIElement> active = new HashSet<UIElement>();
        //private static Image prewImg;

        private static void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Handled)
                return;
            e.Effects = DragDropEffects.Move;
            Panel panel = sender.GetDropPanel();
            if (panel == null)
                return;
            MyAttachments.SetActive(sender as UIElement, true);
            active.Add(sender as UIElement);
            panel.Children.Add(dummyUIE);
            Control item = e.Data.GetData("control") as Control;
            e.Handled = true;

            RenderTargetBitmap bmp = new RenderTargetBitmap(180, 180, 120, 96, PixelFormats.Pbgra32);
            bmp.Render(item);
            Image img = new Image() { Width = item.Width * 0.3, Height = item.Height * 0.3};
            img.Source = bmp;
            prewImages[sender].Source = img.Source;
        }
        private static void Panel_DragLeave(object sender, DragEventArgs e)
        {
            Panel panel = sender.GetDropPanel();
            if (panel == null)
                return;
            MyAttachments.SetActive(sender as UIElement, false);

            panel.Children.Remove(dummyUIE);
            //(sender as Panel).Children.Remove(prewImages[sender]);
        }
        public static int count = 0;
        private static void Panel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Handled)
                return;
            Panel panel = sender.GetDropPanel();
            if (panel == null)
                return;
            UserControl control = sender as UserControl;

            if (control is UserControl cont)
            {
                count++;
                e.Handled = true;
                if (cont.Equals(dummyUIE))
                    return;
                int index = panel.Children.IndexOf(cont);
                int dIndex = panel.Children.IndexOf(dummyUIE);
                if (dIndex < index)
                    index--;
                Point pos = e.GetPosition(cont);
                Point test = cont.TranslatePoint(pos, panel);
                if (pos.Y < (cont.Height * 0.2))
                {
                    if (dIndex == index)
                        return;
                    panel.Children.RemoveAt(dIndex);
                    panel.Children.Insert(index, dummyUIE);
                }
                else if (pos.Y > (cont.Height * 0.8))
                {
                    if (dIndex == index + 1)
                        return;
                    panel.Children.RemoveAt(dIndex);
                    panel.Children.Insert(index + 1, dummyUIE);
                }
            }
            
        }
        private static void Panel_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled)
                return;
            Panel panel = sender.GetDropPanel();
            if (panel == null)
                return;
            Control item = e.Data.GetData("control") as Control;
            Panel oldPanel = item.Parent as Panel;
            oldPanel.Children.Remove(item);
            int index = panel.Children.IndexOf(dummyUIE);
            panel.Children.RemoveAt(index);
            panel.Children.Insert(index, item);
            MyAttachments.SetActive(sender as UIElement, false);
            e.Handled = true;
            /*
            Point position = e.GetPosition(newPanel);
            Canvas.SetLeft(item, position.X - offsets[sender].X);
            Canvas.SetTop(item, position.Y - offsets[sender].Y);
            */
        }

        public static void SetAllowCDrag(DependencyObject element, bool value)
        {
            element.SetValue(AllowCDragProperty, value);
        }
        public static bool GetAllowCDrag(DependencyObject element)
        {
            return (bool)element.GetValue(AllowCDragProperty);
        }
        public static void SetAllowCDrop(DependencyObject element, bool value)
        {
            element.SetValue(AllowCDropProperty, value);
        }
        public static bool GetAllowCDrop(DependencyObject element)
        {
            return (bool)element.GetValue(AllowCDropProperty);
        }
    }
}
