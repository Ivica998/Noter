using Noter.Models;
using Noter.Models.Commands;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    /// Interaction logic for FolderBrowser.xaml
    /// </summary>
    public partial class FolderBrowser : Window
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
        private GridLength folderHeigth = new GridLength(1, GridUnitType.Auto);
        private GridLength folderWidth = new GridLength(1, GridUnitType.Star);
        private int rows = 10;
        private string defaultPath = "C:\\";
        private string currentPath;
        public string DefaultPath { get => defaultPath; set => defaultPath = value; }

        public FolderBrowser()
        {
            InitializeComponent();
            SetUp();
        }

        private void SetUp()
        {
            dirGrid.RowDefinitions.Add(new RowDefinition() { Height = folderHeigth });
            for (int i = 0; i < rows; i++)
            {
                dirGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = folderWidth });
            }
            tbPath.Text = DefaultPath;
            currentPath = tbPath.Text;
            LoadDir(currentPath);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tbPath.Text[tbPath.Text.Length - 1] != '\\')
                    tbPath.Text = tbPath.Text + "\\";
                LoadDir(tbPath.Text);
            }
        }

        private void LoadDir(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo top = new DirectoryInfo(path);
                DirectoryInfo[] dirs;
                try
                {
                    dirs = top.GetDirectories();
                }
                catch (Exception)
                {
                    return;
                }
                //if (top.GetAccessControl().)
                //    return;
                currentPath = path;
                tbPath.Text = path;
                dirGrid.Children.Clear();
                int curRow = 0;
                int curCol = 0;
                foreach (var dirinfo in dirs)
                {
                    if (dirinfo.Attributes.HasFlag(FileAttributes.Hidden) || dirinfo.Attributes.HasFlag(FileAttributes.System))
                        continue;
                    StackPanel sp = new StackPanel();
                    Label l1 = new Label();
                    l1.Content = dirinfo.Name;
                    l1.Height = double.NaN;
                    l1.HorizontalAlignment = HorizontalAlignment.Center;
                    l1.VerticalAlignment = VerticalAlignment.Top;
                    l1.Margin = new Thickness(0, 0, 0, 0);
                    Image img = new Image();
                    img.Margin = new Thickness(0, 0, 0, 0);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"..\..\..\Images\Folder.png", UriKind.Relative);
                    bitmap.EndInit();
                    img.Source = bitmap;
                    img.Width = double.NaN;
                    img.Height = 40;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    sp.Children.Add(img);
                    sp.Children.Add(l1);
                    sp.MouseDown += Sp_MouseDown;
                    dirGrid.Children.Add(sp);
                    Grid.SetRow(sp, curRow);
                    Grid.SetColumn(sp, curCol);
                    curCol++;
                    if (curCol == rows)
                    {
                        curCol = 0;
                        curRow++;
                        dirGrid.RowDefinitions.Add(new RowDefinition() { Height = folderHeigth });
                    }
                }
            }
        }

        private void Sp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadDir(currentPath + (((sender as StackPanel).Children[1] as Label).Content as string) + "\\");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char[] temp = currentPath.ToCharArray();
            int holder = 0;
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                if(temp[i] == '\\')
                {
                    if(holder == 1)
                    {
                        holder = i + 1;
                        break;
                    }
                    holder++;
                }
            }
            string ret = new string(temp, 0, holder);
            LoadDir(ret);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (tbPath.Text[tbPath.Text.Length - 1] != '\\')
                tbPath.Text = tbPath.Text + "\\";
            currentPath = tbPath.Text;

            //GuidManager.Store(temp);
            SourceViewModel item = new SourceViewModel(currentPath);
            ((MainWindow)Application.Current.MainWindow).Sources.Add(item);
            //((MainWindow)Application.Current.MainWindow).cbSource.SelectedItem = item;

            this.Close();
        }
    }
}
