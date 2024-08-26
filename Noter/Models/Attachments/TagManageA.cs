using Noter.Models.Converters;
using Noter.Models.Extra;
using Noter.Models.MyControls;
using Noter.UserControls;
using Noter.Utils;
using Noter.ViewModel;
using Noter.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Noter.Models.Attachments
{
    public class TagManageA : DependencyObject
    {
        static Dictionary<SourceViewModel, Dictionary<ComboBox, TagSearchViewModel>> TSMap { get; set; } = new Dictionary<SourceViewModel, Dictionary<ComboBox, TagSearchViewModel>>();
        static Dictionary<object, TagSearchViewModel> Data { get; set; } = new Dictionary<object, TagSearchViewModel>();
        private static MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        private static SourceViewModel curS;
        public static SourceViewModel CurS
        {
            get => curS;
            set
            {
                if (curS != value)
                {
                    curS = value;
                    if (!TSMap.ContainsKey(curS))
                        TSMap.Add(curS, new Dictionary<ComboBox, TagSearchViewModel>());
                }
            }
        }



        public static readonly DependencyProperty TagManageProperty = DependencyProperty.RegisterAttached("TagManage", typeof(TagSearchViewModel), typeof(TagManageA),
          new PropertyMetadata(default(TagSearchViewModel), OnLoaded));
        public static void SetTagManage(DependencyObject element, TagSearchViewModel value)
        {
            element.SetValue(TagManageProperty, value);
        }
        public static TagSearchViewModel GetTagManage(DependencyObject element)
        {
            return (TagSearchViewModel)element.GetValue(TagManageProperty);
        }



        private static void OnLoaded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is ComboBox cb))
                return;
            if (cb == null || e.NewValue == null || TSMap[curS].ContainsKey(cb))
                return;

            TagSearchViewModel VModel = e.NewValue as TagSearchViewModel;
            TSMap[CurS].Add(cb, VModel);
            VModel.Tags.CollectionChanged += Tags_CollectionChanged;
            VModel.Tags.Extra = VModel;

            Fabric.MakeNONEInstance(VModel);

            cb.KeyDown += cbTag_KeyDown;
            cb.DropDownOpened += Cb_DropDownOpened;
            cb.DropDownClosed += Cb_DropDownClosed;
            VModel.Init += InitBeforeStart;

        }

        private static void Cb_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.SelectionChanged -= Cb_SelectionChanged;
        }

        private static void Cb_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.SelectionChanged += Cb_SelectionChanged;
        }



        private static void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string key = cb.SelectedValue as string;
            TagSearchViewModel VModel = TSMap[CurS][cb];
            TryTagAdd(VModel, key);
        }

        private static void InitBeforeStart(TagSearchViewModel VModel)
        {
            if (VModel.Tags.Count == 0)
                VModel.Tags.Clear();
            VModel.AfterTagsChangeHandler?.Invoke(1);
        }
        private static void cbTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ComboBox cb = sender as ComboBox;
                string key = cb.SelectedValue as string;
                TagSearchViewModel VModel = TSMap[CurS][cb];
                TryTagAdd(VModel, key);
            }
        }
        private static void Tags_CollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            ManagedCollection<Tag> tgs = sender as ManagedCollection<Tag>;
            TagSearchViewModel VModel = tgs.Extra as TagSearchViewModel;
            switch (e.Command)
            {
                case ManagedCollectionCommand.Add:
                    if (e.Key == "NONE")
                        VModel.Panel.Children.Add(VModel.UIE_NONE);
                    else
                        AddTagItem(VModel, e.Key);
                    break;
                case ManagedCollectionCommand.Clear:
                    VModel.Panel.Children.Clear();
                    break;
                case ManagedCollectionCommand.Remove:
                    if (e.Key == "NONE")
                        VModel.Panel.Children.Remove(VModel.UIE_NONE);
                    break;
            }
        }
        private static void TryTagAdd(TagSearchViewModel VModel, string key)
        {
            if (key != null)
            {
                key = key.ToUpper();
                if (!VModel.Tags.ContainsKey(key))
                {
                    VModel.Tags.Add(key, mainWindow.cbSource.SelectedItem.Cast<SourceViewModel>().Tags[key]);
                }
                else
                    VModel.ErrorHandler?.Invoke(1);
            }
            else
                VModel.ErrorHandler?.Invoke(2);
        }
        private static void AddTagItem(TagSearchViewModel VModel, string key)
        {

            TagC tagC = new TagC() { KeyName = key , Width = 70, Height = 30};
            tagC.Closed += TagC_Closed;
            tagC.Click += B_Click;
            tagC.TagLink = VModel.Tags[key];
            Binding bind = new Binding("Value") { Source = curS.Tags[key].BrushBG };
            Binding bind2 = new Binding("Value") { Source = curS.Tags[key].BrushFG };
            Binding bind3 = new Binding("Value") { Source = curS.Tags[key].BrushBorder };
            tagC.Loaded += (object s, RoutedEventArgs e) =>
            {
                tagC.InnerButton.SetBinding(Control.BackgroundProperty, bind);
                tagC.InnerButton.SetBinding(Control.ForegroundProperty, bind2);
                tagC.InnerButton.SetBinding(Control.BorderBrushProperty, bind3);
            };
            Data.Add(tagC, VModel);
            VModel.Tags[key].UIElements.Add(tagC);
            VModel.Panel.Children.Add(tagC);
            VModel.AfterTagsChangeHandler?.Invoke(1);
            VModel.ErrorHandler?.Invoke(0);
        }

        private static void TagC_Closed(object sender, EventArgs e)
        {
            ClosableC cont = sender as ClosableC;
            TagSearchViewModel VModel = Data[cont];
            string key = cont.KeyName;
            VModel.Tags[key].UIElements.Remove(cont);
            VModel.Tags.Remove(key);
            VModel.AfterTagsChangeHandler?.Invoke(0);
        }
        private static void B_Click(object sender, RoutedEventArgs e)
        {
            new TagSettings(((sender as Button).TemplatedParent as TagC).TagLink).ShowDialog();
        }
        public static void Search(SourceViewModel owner, TagSearchViewModel VModel)
        {
            Panel MH = mainWindow.sHolder.Child.Cast<SourceControl>().searchC.Cast<SearchControl>().MH;
            MH.Children.Clear();
            List<int> indexes = new List<int>();
            List<int> chosenEI = new List<int>(owner.TagsData.Count);
            int count = 0;
            bool add = true;
            if (owner.SearchTags.ContainsKey("ALL"))
                chosenEI.FillIntAsc(0, owner.TagsData.Count);
            else
            {
                foreach (var stag in owner.SearchTags.Map.Values)
                {
                    indexes.Add(owner.Tags.List.IndexOf(stag));
                }
                foreach (var entryData in owner.TagsData)
                {
                    foreach (var index in indexes)
                    {
                        if (entryData[index] == 0)
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add && indexes.Count != 0)
                        chosenEI.Add(count);
                    add = true;
                    count++;
                }
            }
            foreach (var chosen in chosenEI)
            {
                MH.Children.Add(owner.PrevEntries.List[chosen].Element ??= MakePrevEntryControl(owner, chosen, MH));
            }
        }

        private static ClosableC MakePrevEntryControl(SourceViewModel owner, int chosen, Panel MH)
        {
            string objName = owner.PrevEntries.List[chosen].Name;
            ClosableC closableC = new ClosableC() { KeyName = objName, MinWidth = 150, MinHeight = 30, MaxWidth = 150, MaxHeight = 30 };
            closableC.ButtonIsEnabled = !owner.Entries.ContainsKey(objName);
            Binding bind = new Binding("IsActive.Value") { Source = owner.PrevEntries.List[chosen], Converter = new BoolToInverseConverter() };
            closableC.SetBinding(ClosableC.ButtonIsEnabledProperty, bind);
            if (!closableC.ButtonIsEnabled)
                owner.Entries[objName].LinkedElements.Add(closableC);
            closableC.Closed += (object s, EventArgs e) =>
            {
                MH.Children.Remove(s as ClosableC);
            };
            closableC.Click += (object s, RoutedEventArgs e) =>
            {
                Button b = s as Button;
                //b.IsEnabled = false;
                if (!owner.PrevEntries.ContainsKey(closableC.KeyName))
                    return;
                string path = owner.Path + "Data\\" + closableC.KeyName.MakeFileName() + ".txt";
                owner.FileLoadEntry(path);
            };
            return closableC;
        }
    }
}
