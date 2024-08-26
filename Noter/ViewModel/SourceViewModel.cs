using System.IO;
using Noter.Models.Extra;
using Noter.Models;
using Noter.UserControls;
using Noter.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Noter.Models.Attachments;
using Noter.Models.ISaveTXTs.ISaveElements;
using Noter.Models.MyControls;
using System.Windows.Media;

namespace Noter.ViewModel {
    public class SourceViewModel {
        #region Fields
        public string Path { get; set; }
        public TagSearchViewModel TSVM1 { get; set; }
        public ObservedType<int> matchCount;
        public ManagedCollection<Tag> SearchTags { get; set; }
        public ManagedCollection<Entry> Entries { get; set; }
        //public ManagedCollection<Source> Sources { get; set; }
        public ManagedCollection<PreviewEntry> PrevEntries { get; set; }
        public ManagedCollection<Tag> Tags { get; set; }
        public List<List<int>> TagsData { get; set; }
        public MainWindow mainWindow;
        public bool Loaded { get; set; }
        #endregion
        public SourceViewModel(string path) {
            Path = path;
        }
        public void Init() {
            if (!Loaded) {
                mainWindow = Application.Current.MainWindow as MainWindow;
                matchCount = new ObservedType<int>();
                TSVM1 = new TagSearchViewModel();
                TagsData = new List<List<int>>();
                Entries = new ManagedCollection<Entry>(this);
                Entries.PreCollectionChanged += Entries_PreCollectionChanged;
                Tags = new ManagedCollection<Tag>(this);
                PrevEntries = new ManagedCollection<PreviewEntry>(this);
                PrevEntries.PreCollectionChanged += PrevEntries_PreCollectionChanged;
                SearchTags = new ManagedCollection<Tag>(this);
                GuidManager.Init(Tags);
                SearchTags.CollectionCleared += Tag.SetEmptyState;
                SearchTags.ExtraAddValidation += Tag.ExtraAddValidation;
                Tags.ExtraAddValidation += Tag.ExtraAddValidation;
                Tags.PreCollectionChanged += Tags_PreCollectionChanged;
                TSVM1.Tags = SearchTags;
                TSVM1.AfterTagsChangeHandler = ATCHandler;
                Loaded = true;
                FileLoadSource();
            }

        }



        public EntryControl MakeEntryControl(Entry ent) {
            EntryControl EntCont = new EntryControl() { DataContext = this, KeyName = ent.Name };
            EntCont.Tags.AddList(ent.Tags);

            LoadElementEdit(ent.Elements, EntCont.ElementsHolder.Children);

            if (EntCont.Tags.ContainsKey("NONE"))
                EntCont.Tags.PreCollectionChanged += Tag.RemoveEmptyState;
            ent.EControl = EntCont;
            return EntCont;
        }
        public void ApplyEntryChange(string key) {
            if (!Entries.ContainsKey(key) || Entries[key].EControl == null)
                return;
            var ent = Entries[key];
            var EntCont = Entries[key].EControl;
            ApplyElementEdit(EntCont.ElementsHolder.Children, ent.Elements);
            ent.Tags = EntCont.Tags.Map.Values.ToList();
            int eindex = PrevEntries.List.IndexOf(PrevEntries.Map[key]);
            int count = 0;
            foreach (var tag in Tags.Map.Values) {
                TagsData[eindex][count++] = ent.Tags.Contains(tag) ? 1 : 0;
            }
        }
        private static void ApplyElementEdit(UIElementCollection source, List<IElement> dest) {
            dest.Clear();
            foreach (UIElement uiElement in source) {
                if (uiElement is ColColC ccc) {
                    ElementCollection newElement = new ElementCollection();
                    newElement.Visibility = ccc.containerHolder.Visibility;
                    newElement.Header = ccc.Header;
                    newElement.Background = ccc.Background as SolidColorBrush;
                    newElement.Foreground = ccc.Foreground as SolidColorBrush;
                    newElement.BorderBrush = ccc.BorderBrush as SolidColorBrush;
                    ApplyElementEdit(ccc.Children, newElement.Elements);
                    dest.Add(newElement);
                }
                else if (uiElement is TextBoxCon tbc) {
                    TextBoxElement newElement = new TextBoxElement();
                    newElement.Content = tbc.tb.Text;
                    newElement.Background = tbc.Background as SolidColorBrush;
                    newElement.Foreground = tbc.Foreground as SolidColorBrush;
                    newElement.BorderBrush = tbc.BorderBrush as SolidColorBrush;
                    if (tbc.ActualHeight == 0 || tbc.ActualWidth == 0) {
                        newElement.Width = tbc.Width;
                        newElement.Height = tbc.Height;
                    }
                    else {
                        newElement.Width = tbc.ActualWidth;
                        newElement.Height = tbc.ActualHeight;
                    }

                    dest.Add(newElement);
                }

            }
        }
        public static int counter = 0;
        private void LoadElementEdit(List<IElement> source, UIElementCollection dest) {
            dest.Clear();
            foreach (IElement element in source) {
                if (element is ElementCollection ec) {
                    ColColC newUIElement = new ColColC();
                    newUIElement.Name = "ColColC_" + counter++;
                    RoutedEventHandler handler = null;
                    handler = (object sender, RoutedEventArgs e) => {
                        newUIElement.Loaded -= handler;
                        newUIElement.containerHolder.Visibility = ec.Visibility;
                        newUIElement.Header = ec.Header;
                        newUIElement.SetDefaults();
                        newUIElement.SetCurrentValue(ColColC.ProxyBorderBrushProperty, ec.BorderBrush);
                        newUIElement.SetCurrentValue(ColColC.ProxyBackgroundProperty, ec.Background);
                        newUIElement.SetCurrentValue(ColColC.ProxyForegroundProperty, ec.Foreground);
                    };
                    newUIElement.Loaded += handler;
                    dest.Add(newUIElement);
                    LoadElementEdit(ec.Elements, newUIElement.Children);
                }
                else if (element is TextBoxElement tbe) {
                    TextBoxCon newUIElement = new TextBoxCon();
                    RoutedEventHandler handler = null;
                    handler = (object sender, RoutedEventArgs e) => {
                        newUIElement.Loaded -= handler;
                        newUIElement.tb.Text = tbe.Content;
                        newUIElement.Width = tbe.Width;
                        newUIElement.Height = tbe.Height;
                        newUIElement.SetDefaults();
                        newUIElement.SetCurrentValue(Control.BorderBrushProperty, tbe.BorderBrush);
                        newUIElement.SetCurrentValue(Control.BackgroundProperty, tbe.Background);
                        newUIElement.SetCurrentValue(Control.ForegroundProperty, tbe.Foreground);
                    };
                    newUIElement.Loaded += handler;
                    dest.Add(newUIElement);
                }
            }
        }

        public void CreateActiveEntry(Entry obj) {
            EntryControl entCont = MakeEntryControl(obj);
            ClosableC closableC = new ClosableC() { KeyName = obj.Name, MaxWidth = double.PositiveInfinity, MinWidth = 100 };
            entCont.Tab = closableC;
            closableC.Closed += ClosableC_Closed;
            closableC.Click += (object sender, RoutedEventArgs r) => {
                if (last != null)
                    MyAttachments.SetPressed(last, false);
                MyAttachments.SetPressed(closableC, true);
                last = closableC;
                string key = closableC.KeyName;
                if (key != null && Entries.ContainsKey(key))
                    Entries.Active = Entries[key];
            };

            mainWindow.sHolder.Child.Cast<SourceControl>().openEntries.Children.Add(closableC);

            if (last != null)
                MyAttachments.SetPressed(last, false);
            MyAttachments.SetPressed(closableC, true);
            last = closableC;
            Entries.Active = obj;
        }



        #region FILE_SAVE/LOAD
        public void FileLoadSource() {
            FileLoadPreferences();
            FileLoadPrevEntries();
            FileLoadTags();
            FileLoadTagData();
        }
        private void FileLoadPreferences() {
            string path = Path + "Preferences.txt";
            if (File.Exists(path)) {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs)) {
                    string output = sr.ReadToEnd();
                    output = output.Replace("\r", "");
                    string[] rows = output.Split("##\n", StringSplitOptions.RemoveEmptyEntries);
                    int brojac = 0;
                    ColColC.LoadPreferenes(rows[brojac++]);
                    TextBoxCon.LoadPreferenes(rows[brojac++]);
                }
            }
        }
        public void FileLoadPrevEntries() {
            string path = Path + "Entries.txt";
            if (File.Exists(path)) {
                PrevEntries.Clear();
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs)) {
                    string output = sr.ReadToEnd();
                    output = output.Replace("\r", "");
                    string[] rows = output.Split("##\n", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < rows.Length; i++) {
                        string[] parts = rows[i].Split("##|");
                        PreviewEntry obj = new PreviewEntry(parts[0].Unescape());
                        obj.Deleted = bool.Parse(parts[1]);
                        PrevEntries.Add(obj.Name, obj);
                    }
                }
            }
        }
        public Control last;
        public void FileLoadEntry(string path) {
            Entry obj = new FileSaver(path).ReadOne<Entry>();
            obj.LoadTagsFromData(this);
            CreateActiveEntry(obj);
        }


        private void ClosableC_Closed(object sender, EventArgs e) {
            ClosableC cont = sender as ClosableC;
            FileSaveEditedEntry(cont.KeyName);
            Entries.Remove(cont.KeyName);
        }

        public void OpenedEntryClose(Grid g) {
            Button b = g.Children[0] as Button;
            EntryControl ent = b.Tag as EntryControl;
            FileSaveEditedEntry(ent.KeyName);
            Entries.Remove(ent.KeyName);
        }
        public void FileLoadTags() {
            string path = Path + "Tags2.txt";
            if (File.Exists(path)) {
                Tags.AddList(new FileSaver(path).ReadSimple<Tag>());
            }
        }
        public void FileLoadTagsOld() {
            string path = Path + "Tags.txt";
            if (File.Exists(path)) {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs)) {
                    string output = sr.ReadToEnd();
                    output = output.Replace("\r", "");
                    string[] rows = output.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < rows.Length; i++) {
                        string[] parts = rows[i].Split('|');
                        Tag t = new Tag(parts[0]);
                        t.Id = Guid.Parse(parts[1]);
                        GuidManager.Store(t);
                        Tags.Add(t.Name, t);
                    }
                }
            }
        }
        public void FileLoadTagData() {
            string path = Path + "TagData.txt";
            if (File.Exists(path)) {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs)) {
                    string output = sr.ReadToEnd();
                    output = output.Replace("\r", "");
                    string[] rows = output.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < rows.Length; i++) {
                        List<int> list = new List<int>();
                        list.AddRange(rows[i].Select(chr => int.Parse(chr.ToString())));
                        TagsData.Add(list);
                    }
                }
            }
        }
        public void FileSaveSource() {
            if (Loaded == false)
                return;
            string path = Path + "Data\\";
            foreach (var item in Entries.Map.Values) {
                ApplyEntryChange(item.Name);
                FileSaveEntry(path, item);
            }
            FileSavePreferences();
            FileSavePrevEntries();
            FileSaveTags();
            FileSaveTagData();
        }
        public void FileSavePreferences() {
            string path = Path + "Preferences.txt";
            if (Directory.Exists(Path)) {
                using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs)) {
                    fs.SetLength(0);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ColColC.SavePreferences());
                    sb.Append(TextBoxCon.SavePreferences());
                    sw.Write(sb.ToString());
                }
            }
        }
        public void FileSavePrevEntries() {
            string path = Path + "Entries.txt";
            if (Directory.Exists(Path)) {
                using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs)) {
                    fs.SetLength(0);
                    StringBuilder sb = new StringBuilder();
                    foreach (var prevEnt in PrevEntries.Map.Values) {
                        sb.Append(prevEnt.Name.Escape() + "##|" + prevEnt.Deleted.ToString() + "##\n");
                    }
                    sw.Write(sb.ToString());
                }
            }
            PrevEntries.Clear();
        }
        public void FileSaveTags() {
            string path = Path + "Tags2.txt";
            if (Directory.Exists(Path)) {
                Tags.PreCollectionChanged -= Tags_PreCollectionChanged;
                Tags.Remove("NONE");
                Tags.Remove("ALL");
                new FileSaver(path).Write(Tags.List.ToList());
            }
            Entries.Clear();
        }
        public void FileSaveTagsOld() {
            string path = Path + "Tags.txt";
            if (Directory.Exists(Path)) {
                using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs)) {
                    fs.SetLength(0);
                    string strData = "";
                    Tags.PreCollectionChanged -= Tags_PreCollectionChanged;
                    Tags.Remove("NONE");
                    Tags.Remove("ALL");
                    foreach (var item in Tags.Map.Values) {
                        sw.Write(item.Name + "|" + item.Id + "\n");
                    }
                    sw.Write(strData);
                }
            }
            Entries.Clear();
        }
        public void FileSaveTagData() {
            string path = Path + "TagData.txt";
            if (Directory.Exists(Path)) {
                using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs)) {
                    fs.SetLength(0);
                    StringBuilder sb = new StringBuilder();

                    foreach (var td in TagsData) {
                        foreach (var num in td) {
                            sb.Append(num);
                        }
                        sb.AppendLine();
                    }
                    sw.Write(sb.ToString());
                }
            }
        }
        public void FileSaveEntry(string path, Entry item) {
            new FileSaver(path + item.Name.MakeFileName() + ".txt").Write(item);
        }
        public void FileSaveEditedEntry(string key) {
            string path = Path + "Data\\";
            Entry item = Entries.Map[key];
            ApplyEntryChange(item.Name);
            FileSaveEntry(path, item);
        }
        #endregion
        private void ATCHandler(int code) {
            TagManageA.Search(this, TSVM1);
        }
        private void Entries_PreCollectionChanged(object sender, CollectionChangedEventArgs e) {
            if (e.Command == ManagedCollectionCommand.Remove) {
                mainWindow.SMap[this].openEntries.Children.Remove(Entries[e.Key].EControl.Tab);
                PrevEntries[e.Key].IsActive.Value = false;
                if (Entries.Active?.Name == e.Key)
                    Entries.Active = null;
            }
            else if (e.Command == ManagedCollectionCommand.Add) {
                PrevEntries[e.Key].IsActive.Value = true;
            }
        }
        private void PrevEntries_PreCollectionChanged(object sender, CollectionChangedEventArgs e) {
            if (e.Command == ManagedCollectionCommand.Remove) {
                int index = PrevEntries.IndexOf(e.Key);
                TagsData.RemoveAt(index);
                Entries.Remove(e.Key);
                PrevEntries[e.Key].Element?.Close();
            }
        }
        private void Tags_PreCollectionChanged(object sender, CollectionChangedEventArgs e) {
            if (e.Command == ManagedCollectionCommand.Remove) {
                int index = Tags.IndexOf(e.Key);
                foreach (var item in TagsData) {
                    item.RemoveAt(index);
                }
                while (Tags[e.Key].UIElements.Count > 0) {
                    ClosableC closableC = Tags[e.Key].UIElements[0] as ClosableC;
                    Panel p = closableC.Parent as Panel;
                    p.Children.Remove(closableC);
                    closableC.Close();
                }

            }
        }
    }
}
