using Noter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Noter.Utils.SavingHelper;

namespace Noter.Utils
{
    public static class Extentions
    {
        private static Dictionary<char, string> fileNameInvalidToValid = new Dictionary<char, string>();
        static Extentions()
        {
            var invalid = Path.GetInvalidFileNameChars();
            for (int i = 0; i < invalid.Length; i++)
            {
                fileNameInvalidToValid.Add(invalid[i], i + "#");
            }
        }

        public static string MakeFileName(this string str)
        {
            StringBuilder sb = new StringBuilder();
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '#')
                    sb.Append("##");
                else if (fileNameInvalidToValid.ContainsKey(arr[i]))
                    sb.Append(fileNameInvalidToValid[arr[i]]);
                else
                    sb.Append(arr[i]);
            }
            return sb.ToString();
        }
        public static Panel GetDropPanel(this object obj)
        {
            if (obj is Panel p)
                return p;
            if (obj is FrameworkElement fe)
            {
                return fe.Tag as Panel;
            }
            return null;
        }
        public static StringBuilder RemoveTerminator(this StringBuilder sb,int depth)
        {
            int toRemove = (depth + 1).ToString().Length + 3;
            sb.Remove(sb.Length - toRemove, toRemove);
            return sb;

        }
        public static StringBuilder FixTerminator(this StringBuilder sb, int depth)
        {
            int toRemove = (depth + 1).ToString().Length + 3;
            sb.Remove(sb.Length - toRemove, toRemove);
            sb.Append($" {depth}#\n");
            return sb;

        }
        public static string AfterFirst(this string str, char chr)
        {
            string temp = str.TrimStart();
            return temp.Substring(temp.IndexOf(chr) + 1).Trim();
        }
        public static string UntilFirst(this string str, char chr)
        {
            return str.Substring(0,str.IndexOf(chr)).Trim();
        }

        public static string DirOnly(this string str)
        {
            return str.Substring(0, str.LastIndexOf("\\", str.Length - 2)).Trim();
        }

        public static string Escape(this string str)
        {
            return str.Replace("#", "\\#");
        }
        public static string Unescape(this string str)
        {
            return str.Replace("\\#", "#");
        }
        public static List<T> Fill<T>(this List<T> list,T value,int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(value);
            }
            return list;
        }

        public static List<int> FillIntAsc(this List<int> list, int value, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(value++);
            }
            return list;
        }

        public static DependencyObject Parent(this DependencyObject child)
        {
            return VisualTreeHelper.GetParent(child);
        }

        public static T Cast<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
