using Noter.Models.Extra;
using Noter.Models.ISaveTXTs;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Noter.Models
{
    public class Tag : SaveTXTBase
    {
        private static Brush DefaultBG;
        private static Brush DefaultFG;
        private static Brush DefaultBorder;
        static Tag()
        {
            Style style = new FrameworkElement().FindResource(typeof(Button)) as Style;
            Button b = new Button { Style = style };
            DefaultBG = b.Background;
            DefaultFG = b.Foreground;
            DefaultBorder = b.BorderBrush;
        }
        public ObservedType<SolidColorBrush> BrushBG = new ObservedType<SolidColorBrush>() { Value = DefaultBG as SolidColorBrush ?? Brushes.Transparent };
        public ObservedType<SolidColorBrush> BrushFG = new ObservedType<SolidColorBrush>() { Value = DefaultFG as SolidColorBrush ?? Brushes.Transparent };
        public ObservedType<SolidColorBrush> BrushBorder = new ObservedType<SolidColorBrush>() { Value = DefaultBorder as SolidColorBrush ?? Brushes.Transparent };
        public List<UIElement> UIElements { get; set; } = new List<UIElement>();

        public Tag() { }
        public Tag(string name = "")
        {
            Name = name.ToUpper();
        }

        public override string FormatSave(FileSaver fs, int depth)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name.Escape() + "1#");
            sb.Append(Id.ToString().Escape() + "1#");
            sb.Append(BrushBG.Value.Color.ToString().Escape() + "1#");
            sb.Append(BrushFG.Value.Color.ToString().Escape() + "1#");
            sb.Append(BrushBorder.Value.Color.ToString().Escape() + "1#");

            sb.AppendLine("2#");
            return sb.ToString();
        }

        public string FormatSaveOld(FileSaver fs, int depth)
        {
            string content = "";
            content = "--- !u!" + SavingHelper.GetCode(this) + " &" + fs.Next() + "1#\n";
            content += this.GetType().Name + ":1#\n";
            content += SavingHelper.Indent(1) + "Guid: " + Id.ToString().Escape() + "1#\n";
            content += SavingHelper.Indent(1) + "Name: " + Name.Escape() + "1#\n";
            content += SavingHelper.Indent(1) + "ColorBG: " + BrushBG.Value.Color.ToString().Escape() + "1#\n";
            content += SavingHelper.Indent(1) + "ColorFG: " + BrushFG.Value.Color.ToString().Escape() + "1#\n";
            return content;
        }

        public override void ParseLoad(string body, int depth)
        {
            string[] rows = body.Split("1#", StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;
            Name = rows[counter].AfterFirst(' ').Unescape();
            counter++;
            Id = Guid.Parse(rows[counter].AfterFirst(' ').Unescape());
            counter++;
            BrushBG.Value = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rows[counter].AfterFirst(' ').Unescape()));
            counter++;
            BrushFG.Value = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rows[counter].AfterFirst(' ').Unescape()));
            counter++;
            BrushBorder.Value = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rows[counter].AfterFirst(' ').Unescape()));

        }

        public static void SetEmptyState(object sender, CollectionClearedEventArgs e)
        {
            ManagedCollection<Tag> col = sender as ManagedCollection<Tag>;
            Tag none = GuidManager.NONETag;
            col.Add(none.Name, none);
            col.PreCollectionChanged += RemoveEmptyState;
        }

        public static void RemoveEmptyState(object sender, CollectionChangedEventArgs e)
        {
            if (e.Command == ManagedCollectionCommand.Add)
            {
                ManagedCollection<Tag> col = sender as ManagedCollection<Tag>;
                col.PreCollectionChanged -= RemoveEmptyState;
                Tag none = GuidManager.NONETag;
                col.Remove(none.Name);
            }
        }

        internal static bool ALLTagForbid(object sender, string key)
        {
            if (key == "ALL")
                return false;
            return true;
        }

        public static bool ExtraAddValidation(object sender, string key)
        {
            var tags = sender as ManagedCollection<Tag>;
            if (key == "NONE" && (tags.ContainsKey("NONE") || tags.Count > 0))
                return false;
            return true;
        }
    }
}
