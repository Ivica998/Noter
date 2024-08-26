using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Noter.Models.Attachments
{
    public class NavA : DependencyObject
    {

        public enum NavAEnum
        {
            NONE,
            SKIP,
            PASS,
            TRAP
        }
        public static NavAEnum GetPanelNav(DependencyObject obj)
        {
            return (NavAEnum)obj.GetValue(PanelNavProperty);
        }

        public static void SetPanelNav(DependencyObject obj, NavAEnum value)
        {
            obj.SetValue(PanelNavProperty, value);
        }

        // Using a DependencyProperty as the backing store for PanelNav.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PanelNavProperty =
            DependencyProperty.RegisterAttached("PanelNav", typeof(NavAEnum), typeof(NavA), new PropertyMetadata(NavAEnum.NONE,PanelNavChanged));

        private static void PanelNavChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is UIElement cast))
                return;
            if (!(e.NewValue is NavAEnum val))
                return;
            switch(val)
            {
                case NavAEnum.PASS:
                    cast.Focusable = true;
                    KeyboardNavigation.SetTabNavigation(cast, KeyboardNavigationMode.None);
                    KeyboardNavigation.SetControlTabNavigation(cast, KeyboardNavigationMode.Cycle);
                    KeyboardNavigation.SetDirectionalNavigation(cast, KeyboardNavigationMode.Cycle);
                    KeyboardNavigation.SetIsTabStop(cast, true);
                    break;
                case NavAEnum.TRAP:
                    cast.Focusable = true;
                    KeyboardNavigation.SetTabNavigation(cast, KeyboardNavigationMode.Cycle);
                    KeyboardNavigation.SetControlTabNavigation(cast, KeyboardNavigationMode.None);
                    KeyboardNavigation.SetDirectionalNavigation(cast, KeyboardNavigationMode.Cycle);
                    KeyboardNavigation.SetIsTabStop(cast, true);
                    break;
                case NavAEnum.SKIP:
                    cast.Focusable = false;
                    KeyboardNavigation.SetTabNavigation(cast, KeyboardNavigationMode.None);
                    KeyboardNavigation.SetControlTabNavigation(cast, KeyboardNavigationMode.None);
                    KeyboardNavigation.SetDirectionalNavigation(cast, KeyboardNavigationMode.None);
                    KeyboardNavigation.SetIsTabStop(cast, false);
                    break;

            }
        }
    }
}
