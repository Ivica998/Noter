using Noter.Models.Commands;
using Noter.Utils;
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
    /// Interaction logic for TagDestroyer.xaml
    /// </summary>
    public partial class TagDestroyer : Window
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
        public TagDestroyer(SourceViewModel owner)
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
            string key = toDelete.Trim();
            if (!reqText.Text.Equals("agree"))
            {
                l1.Content = $"Type \"agree\" to confirm.";
                return;
            }
            if (!owner.Tags.ContainsKey(toDelete))
            {
                l1.Content = $"Select existing tag.";
                return;
            }
            if(GuidManager.SpecialTags.ContainsKey(key))
            {
                l1.Content = $"Can't delete special tag.";
                return;
            }
            int index = owner.Tags.IndexOf(key);
            owner.Tags.Remove(key);
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
