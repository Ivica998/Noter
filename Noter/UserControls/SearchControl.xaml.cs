using Noter.Models.Commands;
using Noter.ViewModel;
using Noter.Windows;
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

namespace Noter.UserControls
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public string Path { get; set; }
        

        public SearchControl()
        {
            InitializeComponent();
            //Loaded += (s, e) => Keyboard.Focus(this);
        }

        public void New_Entry_Click(object sender, RoutedEventArgs e)
        {
            new EntryCreator(DataContext as SourceViewModel).ShowDialog();
        }
        public void Delete_Entry_Click(object sender, RoutedEventArgs e)
        {
            new EntryDestroyer(DataContext as SourceViewModel).ShowDialog();
        }
        public void New_Tag_Click(object sender, RoutedEventArgs e)
        {
            new TagCreator(DataContext as SourceViewModel).ShowDialog();
        }
        public void Delete_Tag_Click(object sender, RoutedEventArgs e)
        {
            new TagDestroyer(DataContext as SourceViewModel).ShowDialog();
        }

        private void sc_Loaded(object sender, RoutedEventArgs e)
        {
            SourceViewModel svm = DataContext as SourceViewModel;
            svm.TSVM1.Panel = STH;
            svm.TSVM1.ErrorHandler += TSErrorHandler;
            svm.TSVM1.Init?.Invoke(svm.TSVM1);

        }

        private void TSErrorHandler(int code)
        {
            switch (code)
            {
                case 0: l1.Content = ""; break;
                case 1: l1.Content = "Tag already placed."; break;
                case 2: l1.Content = "Error occured."; break;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SourceViewModel svm = DataContext as SourceViewModel;
            svm.TSVM1.AfterTagsChangeHandler?.Invoke(1);
        }

    }
}
