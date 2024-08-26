using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Noter.Models.Attachments
{
    public class GridA : DependencyObject
    {

        private static HashSet<char> chars = new HashSet<char>()
        {
            '*','0','1','2','3','4','5','6','7','8','9'
        };
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.RegisterAttached("Rows", typeof(string), typeof(GridA), new PropertyMetadata("",OnRowsChanged));
        private static void OnRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Grid cast))
                return;
            cast.RowDefinitions.Clear();
            if (e.NewValue is string str)
            {
                string[] parts = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                char[] arr;
                int num = 0;
                char chr;
                for (int i = 0; i < parts.Length; i++)
                {
                    string temp = parts[i].Replace(" ", "");
                    arr = temp.ToCharArray();
                    if (arr.Length == 1)
                    {
                        if (arr[0] == '*')
                        {
                            cast.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Star) });
                            continue;
                        }
                        else if ((arr[0] | 0x20) == 'a')
                        {
                            cast.RowDefinitions.Add(new RowDefinition());
                            continue;
                        }
                    }
                    num = 0;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        chr = arr[j];
                        if (!chars.Contains(chr))
                            return;
                        if (chr != '*')
                        {
                            num = num * 10 + chr - '0';
                            continue;
                        }

                        if (j == arr.Length - 1)
                        {
                            cast.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(num, GridUnitType.Star) });
                            break;
                        }
                        else
                            return;
                    }
                    cast.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(num, GridUnitType.Pixel) });
                }
            }
        }
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.RegisterAttached("Cols", typeof(string), typeof(GridA), new PropertyMetadata("", OnColsChanged));
        private static void OnColsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            {
                if (!(d is Grid cast))
                    return;
                cast.ColumnDefinitions.Clear();
                if (e.NewValue is string str)
                {
                    string[] parts = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    char[] arr;
                    int num = 0;
                    char chr;
                    for (int i = 0; i < parts.Length; i++)
                    {
                        string temp = parts[i].Replace(" ", "");
                        arr = temp.ToCharArray();
                        if (arr.Length == 1)
                        {
                            if (arr[0] == '*')
                            {
                                cast.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Star) });
                                continue;
                            }
                            else if ((arr[0] | 0x20) == 'a')
                            {
                                cast.ColumnDefinitions.Add(new ColumnDefinition());
                                continue;
                            }
                        }
                        num = 0;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            chr = arr[j];
                            if (!chars.Contains(chr))
                                return;
                            if (chr != '*')
                            {
                                num = num * 10 + chr - '0';
                                continue;
                            }

                            if (j == arr.Length - 1)
                            {
                                cast.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(num, GridUnitType.Star) });
                                break;
                            }
                            else
                                return;
                        }
                        cast.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(num, GridUnitType.Pixel) });
                    }
                }
            }
        }

        public static string GetRows(DependencyObject obj)
        {
            return (string)obj.GetValue(RowsProperty);
        }
        public static void SetRows(DependencyObject obj, string value)
        {
            obj.SetValue(RowsProperty, value);
        }
        public static string GetCols(DependencyObject obj)
        {
            return (string)obj.GetValue(ColsProperty);
        }
        public static void SetCols(DependencyObject obj, string value)
        {
            obj.SetValue(ColsProperty, value);
        }
    }
}
