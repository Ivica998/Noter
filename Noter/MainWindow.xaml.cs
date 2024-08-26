using Microsoft.Win32;
using Noter.Utils;
using Noter.Models;
using Noter.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using Noter.UserControls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Noter.ViewModel;
using Noter.Models.Attachments;
using Noter.Models.Commands;

namespace Noter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ICommand eccmd;
        public ICommand ECCMD { get { return eccmd ?? (eccmd = new ActionCommand((object obj) => { new EntryCreator(obj as SourceViewModel).ShowDialog(); }, Bank.NullCheck)); } }
        private ICommand edcmd;
        public ICommand EDCMD { get { return edcmd ?? (edcmd = new ActionCommand((object obj) => { new EntryDestroyer(obj as SourceViewModel).ShowDialog(); }, Bank.NullCheck)); } }
        private ICommand tccmd;
        public ICommand TCCMD { get { return tccmd ?? (tccmd = new ActionCommand((object obj) => { new TagCreator(obj as SourceViewModel).ShowDialog(); }, Bank.NullCheck)); } }
        private ICommand tdcmd;
        public ICommand TDCMD { get { return tdcmd ?? (tdcmd = new ActionCommand((object obj) => { new TagDestroyer(obj as SourceViewModel).ShowDialog(); }, Bank.NullCheck)); } }
        public ObservableCollection<SourceViewModel> Sources { get; set; } = new ObservableCollection<SourceViewModel>();
        public Dictionary<SourceViewModel, SourceControl> SMap { get; set; } = new Dictionary<SourceViewModel, SourceControl>();
        public MainWindow() {
            FileLoadState();
            InitializeComponent();
            mainGrid.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight - 50;
            cbSource.SelectedItem = Sources.FirstOrDefault();
            //webBrowser.Navigate(@"https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.webbrowser?redirectedfrom=MSDN&view=windowsdesktop-7.0");

        }
        private void Browse_Source_Path_Click(object sender, RoutedEventArgs e) {
            new FolderBrowser().ShowDialog();
        }
        private void Window_Closed(object sender, EventArgs e) {
            foreach (var item in Sources) {
                item.FileSaveSource();
            }
            FileSaveState();
        }
        public void FileLoadState() {
            string path = Environment.CurrentDirectory + "\\State.txt";
            List<string> retVal = new List<string>();
            SavingHelper.LoadStrings(path, retVal);
            foreach (var item in retVal) {
                Sources.Add(new SourceViewModel(item));
            }
        }
        public void FileSaveState() {
            string path = Environment.CurrentDirectory + "\\State.txt";
            SavingHelper.SaveStrings(path, Sources.Select(item => item.Path).ToList());
        }

        private void cbSource_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            SourceViewModel svm = cbSource.SelectedItem as SourceViewModel;
            TagManageA.CurS = svm;
            if (!SMap.ContainsKey(svm)) {
                SourceControl sc = new SourceControl();
                SMap.Add(svm, sc);
                sHolder.Child = sc;
                svm.Init();
                svm.TSVM1.Init?.Invoke(svm.TSVM1);
            }
            else {
                sHolder.Child = SMap[svm];
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            SourceViewModel svm = cbSource.SelectedItem as SourceViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            new TestZone().ShowDialog();
        }

        private void Button2_Click(object sender, RoutedEventArgs e) {
            new Preferences().ShowDialog();
        }
    }
}
