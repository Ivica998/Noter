using Noter.Models;
using Noter.Utils;
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
    public partial class EntryControl : BaseConC
    {
    /*
        public static readonly DependencyProperty EntryItemProperty = DependencyProperty.Register(
            name: "EntryItem",
            propertyType: typeof(Entry),
            ownerType: typeof(EntryControl2),
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: null,
                flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                propertyChangedCallback: new PropertyChangedCallback(OnEntryItemChanged))
           // { BindsTwoWayByDefault = true,DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged }
    );

        public Entry EntryItem
        {
            get => (Entry)GetValue(EntryItemProperty);
            set => SetValue(EntryItemProperty, value);
        }

        private static void OnEntryItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d == null)
                return;
            if (e.NewValue is Entry ent)
            {
                EntryControl2 control = d as EntryControl2;
                control.UCTitle.Text = ent.Title;
                control.UCContent.Text = ent.Content;
                control.Tags.AddList(ent.Tags);
                control.Tags.Clear();
            }
        }
     */

        public string KeyName { get; set; }
        public TagSearchViewModel TSVM2 { get; set; } = new TagSearchViewModel();
        public ManagedCollection<Tag> Tags { get; set; }
        public ManagedCollection<Tag> MainTags { get; set; }
        public UIElement Tab { get; set; }
        public EntryControl()
        {
            MainTags = ((Application.Current.MainWindow as MainWindow).cbSource.SelectedItem as SourceViewModel).Tags;
            Tags = new ManagedCollection<Tag>(this);
            Tags.CollectionCleared += Models.Tag.SetEmptyState;
            Tags.ExtraAddValidation += Models.Tag.ExtraAddValidation;
            Tags.ExtraAddValidation += Models.Tag.ALLTagForbid;
            TSVM2.Tags = Tags;
            TSVM2.ErrorHandler = TSErrorHandler;
            TSVM2.AfterTagsChangeHandler = ATCHandler;
            InitializeComponent();
            TSVM2.Panel = TagHolder;
            Tag = ElementsHolder;
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
        private void ATCHandler(int code)
        {
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as SourceViewModel).FileSaveEditedEntry(KeyName);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            TSVM2.Init?.Invoke(TSVM2);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new ElementCreator(ElementsHolder).ShowDialog();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers != ModifierKeys.None)
                return;
            ScrollViewer sv = sender as ScrollViewer;
            sv.ScrollToVerticalOffset(sv.VerticalOffset - e.Delta/2);
            e.Handled = true;
        }

        private void Grid_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }
    }
}
