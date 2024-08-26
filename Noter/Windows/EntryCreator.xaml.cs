using Noter.Models;
using Noter.Models.Attachments;
using Noter.Models.Commands;
using Noter.UserControls;
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
    /// Interaction logic for EntryCreator.xaml
    /// </summary>
    public partial class EntryCreator : Window
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
        public SourceViewModel owner;
        public EntryCreator(SourceViewModel owner)
        {
            Style = FindResource(typeof(Window)) as Style;

            this.owner = owner;
            InitializeComponent();
            objName.Focus();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            string key = objName.Text.Trim();
            if(key == "")
            {
                l1.Content = $"Name can't be empty.";
                return;
            }
            if (owner.PrevEntries.ContainsKey(key))
            {
                l1.Content = $"Entry \"{key}\" already exists.";
                return;
            }
            Entry obj = new Entry(key);
            GuidManager.Store(obj);

            owner.TagsData.Add(new List<int>().Fill(0,owner.Tags.Count));
            owner.PrevEntries.Add(obj.Name, new PreviewEntry(obj.Name));

            owner.CreateActiveEntry(obj);

            if((bool)chbCopy.IsChecked)
            {
                foreach(var tag in owner.SearchTags.Map.Values)
                {
                    obj.EControl.Tags.Add(tag.Name,tag);
                }
            }
            if (obj.EControl.Tags.Count == 1 && obj.EControl.Tags.List[0] == GuidManager.NONETag)
                obj.EControl.Tags.PreCollectionChanged += Noter.Models.Tag.RemoveEmptyState;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void objName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Create_Button_Click(sender, new RoutedEventArgs());
        }
    }
}
