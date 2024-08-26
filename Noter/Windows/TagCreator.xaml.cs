using Noter.Models;
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
    /// Interaction logic for TagCreator.xaml
    /// </summary>
    public partial class TagCreator : Window
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
        public TagCreator(SourceViewModel owner)
        {
            Style = FindResource(typeof(Window)) as Style;

            this.owner = owner;
            InitializeComponent();
            objName.Focus();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            string key = objName.Text.ToUpper().Trim();
            if (key == "")
            {
                l1.Content = $"Name can't be empty.";
                return;
            }
            if (owner.Entries.ContainsKey(key))
            {
                l1.Content = $"Tag \"{key}\" already exists.";
                return;
            }
            Tag obj = new Tag();
            obj.Name = key;
            GuidManager.Store(obj);
            owner.Tags.Add(key, obj);
            foreach (var entity in owner.TagsData)
            {
                entity.Add(0);
            }


            /*
            owner.Schemes.Add(shName.Text, schema);

            var old = owner.Schemes;
            owner.Schemes = new Dictionary<string, Models.OrderSchema>();
            owner.Schemes = old;
             */

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
