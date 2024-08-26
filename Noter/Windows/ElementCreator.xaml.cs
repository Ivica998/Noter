using Noter.Models;
using Noter.Models.Attachments;
using Noter.Models.ISaveTXTs.ISaveElements;
using Noter.UserControls;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using Noter.Models.Commands;

namespace Noter.Windows
{
    /// <summary>
    /// Interaction logic for ElementCreator.xaml
    /// </summary>
    public partial class ElementCreator : Window
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
        public ObservableCollection<string> elementChoices { get; set; } = new ObservableCollection<string>()
        {
            "ElementCollection",
            "TextBoxElement"
        };

        public Panel panel;
        public ElementCreator(Panel panel)
        {
            Style = FindResource(typeof(Window)) as Style;

            this.panel = panel;
            InitializeComponent();
            cbElementChoice.Focus();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            switch(cbElementChoice.SelectedValue as string)
            {
                case "ElementCollection":
                    ColColC ccc = new ColColC();
                    ccc.Loaded += (object s, RoutedEventArgs e) => ccc.SetDefaults();
                    panel.Children.Add(ccc);
                    break;
                case "TextBoxElement":
                    TextBoxCon tbc = new TextBoxCon();
                    tbc.Loaded += (object s, RoutedEventArgs e) => {
                        tbc.SetDefaults();
                    };
                    tbc.HorizontalAlignment = HorizontalAlignment.Stretch;
                    panel.Children.Add(tbc);
                    break;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbElementChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //createButton.Focus();
        }
    }
}
