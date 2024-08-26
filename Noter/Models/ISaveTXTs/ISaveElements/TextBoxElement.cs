using Noter.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Noter.Models.ISaveTXTs.ISaveElements
{
    public class TextBoxElement : ElementBase
    {
        public string Content { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public SolidColorBrush Background { get; internal set; }
        public SolidColorBrush Foreground { get; internal set; }
        public SolidColorBrush BorderBrush { get; internal set; }

        public override string FormatSave(FileSaver fs, int depth)
        {
            
            StringBuilder sb = new StringBuilder();
            string term = $" {depth + 1}#\n"; // prop ima depth + 1
            sb.Append(SavingHelper.Indent(depth) + "TextBoxElement:" + "\n");
            sb.Append(SavingHelper.Indent(depth + 1) + "Content:\n" + Content.Escape() + term);
            sb.Append(SavingHelper.Indent(depth + 1) + "Width: " + Width + term);
            sb.Append(SavingHelper.Indent(depth + 1) + "Height: " + Height + term);
            sb.Append(SavingHelper.Indent(depth + 1) + "Background: " + Background.Color.ToString().Escape() + term);
            sb.Append(SavingHelper.Indent(depth + 1) + "Foreground: " + Foreground.Color.ToString().Escape() + term);
            sb.Append(SavingHelper.Indent(depth + 1) + "BorderBrush: " + BorderBrush.Color.ToString().Escape() + term);
            sb.FixTerminator(depth);
            return sb.ToString();
        }

        public override void ParseLoad(string body, int depth)
        {
            int counter = 0;
            string term = $" {depth}#\n";
            string[] props = body.Split(term, StringSplitOptions.RemoveEmptyEntries); // data split
            Content = props[counter++].AfterFirst('\n').Unescape();
            Width = double.Parse(props[counter++].AfterFirst(' '));
            Width = double.NaN;
            Height = double.Parse(props[counter++].AfterFirst(' '));
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(props[counter++].AfterFirst(' ').Unescape()));
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(props[counter++].AfterFirst(' ').Unescape()));
            BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(props[counter++].AfterFirst(' ').Unescape()));
            if (Width == 0)
                Width = double.NaN;
            if (Height == 0)
                Height = 150;

        }

    }
}
