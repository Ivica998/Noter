using Noter.Models.Commands;
using Noter.UserControls;
using Noter.ViewModel;
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
using System.Windows.Shapes;

namespace Noter.Windows
{
    /// <summary>
    /// Interaction logic for EntryDestroyer.xaml
    /// </summary>
    public partial class EntryDestroyer : Window
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
        private string toDelete;
        public SourceViewModel owner;
        public EntryDestroyer(SourceViewModel owner)
        {
            Style = FindResource(typeof(Window)) as Style;
            DataContext = owner;
            this.owner = owner;
            DataContext = this.owner;
            InitializeComponent();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.DataContext;
            if (!reqText.Text.Equals("agree"))
            {
                l1.Content = $"Type \"agree\" to confirm.";
                return;
            }
            if (!owner.PrevEntries.ContainsKey(toDelete))
            {
                l1.Content = $"Select existing entry.";
                return;
            }
            owner.PrevEntries.Remove(toDelete); //updates combobox -> changes toDelete
            l1.Content = "";
            reqText.Text = "";
            toDelete = null;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbObj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string key = (sender as ComboBox).SelectedValue as string;
            toDelete = key;
        }
    }
}
