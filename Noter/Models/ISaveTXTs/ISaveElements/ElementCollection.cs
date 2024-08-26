using Noter.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Noter.Models.ISaveTXTs.ISaveElements
{
    class ElementCollection : ElementBase
    {

        public Visibility Visibility { get; set; }
        public List<IElement> Elements { get; set; } = new List<IElement>();
        public string Header { get; internal set; } = "";
        public SolidColorBrush Background { get; internal set; }
        public SolidColorBrush Foreground { get; internal set; }
        public SolidColorBrush BorderBrush { get; internal set; }

        public override string FormatSave(FileSaver fs, int depth)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SavingHelper.Indent(depth) + "ElementCollection:" + "\n");
            depth++;
            string term =$" {depth }#\n";
            sb.Append(SavingHelper.Indent(depth) + "Visibility: " + Visibility.ToString() + term);
            sb.Append(SavingHelper.Indent(depth) + "Header: " + Header.Escape() + term);
            sb.Append(SavingHelper.Indent(depth) + "Background: " + Background.Color.ToString().Escape() + term);
            sb.Append(SavingHelper.Indent(depth) + "Foreground: " + Foreground.Color.ToString().Escape() + term);
            sb.Append(SavingHelper.Indent(depth) + "BorderBrush: " + BorderBrush.Color.ToString().Escape() + term);
            sb.Append(SavingHelper.Indent(depth) + "Elements:" + "\n");
            foreach (var item in Elements)
            {
                sb.Append(item.FormatSave(fs, depth + 1));
            }
            if (Elements.Count > 0)
                sb.RemoveTerminator(depth);
            sb.Append($" {depth-1}#\n"); // to depth then depth - 1
            return sb.ToString();
        }

        public override void ParseLoad(string body, int depth)
        {
            string[] rows = body.Split($" {depth}#\n", StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;
            Visibility = (Visibility)Enum.Parse(typeof(Visibility), rows[counter++].AfterFirst(' '));
            Header = rows[counter++].AfterFirst(' ').Unescape();
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rows[counter++].AfterFirst(' ').Unescape()));
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rows[counter++].AfterFirst(' ').Unescape()));
            BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(rows[counter++].AfterFirst(' ').Unescape()));
            Entry.ParseAllElements(Elements, rows[counter], depth);
        }
    }
}
