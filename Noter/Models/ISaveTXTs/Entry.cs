using Noter.Models.ISaveTXTs;
using Noter.Models.ISaveTXTs.ISaveElements;
using Noter.Models.MyControls;
using Noter.UserControls;
using Noter.Utils;
using Noter.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Noter.Models
{
    public class Entry : SaveTXTBase
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<IElement> Elements { get; set; } = new List<IElement>();
        public EntryControl EControl { get; set; }
        public List<ClosableC> LinkedElements = new List<ClosableC>();

        public Entry() { }
        public Entry(string name = "")
        {
            Name = name;
        }

        public override string FormatSave(FileSaver fs,int depth) // depth = 1
        {
            string term = $" {depth}#\n";
            StringBuilder sb = new StringBuilder();
            sb.Append("--- !u!" + SavingHelper.GetCode(this) + " &" + fs.Next() + term);
            sb.Append(this.GetType().Name + $": {depth}#\n");
            sb.Append(SavingHelper.Indent(depth) + "Guid: " + Id.ToString().Escape() + term);
            sb.Append(SavingHelper.Indent(depth) + "Name: " + Name.Escape() + term);
            sb.Append(SavingHelper.Indent(depth) + "Elements:\n");
            foreach (var item in Elements)
            {
                sb.Append(item.FormatSave(fs, 2));
            }
            if (Elements.Count > 0)
                sb.FixTerminator(depth);
            return sb.ToString();
        }

        public override void ParseLoad(string body, int depth)
        {
            string[] rows = body.Split(" 1#\n", StringSplitOptions.RemoveEmptyEntries);
            int counter = 1;
            int length = rows.Length;
            Id = Guid.Parse(rows[counter].AfterFirst(' ').Unescape());
            counter++;
            Name = rows[counter].AfterFirst(' ').Unescape();
            counter++;
            if(rows.Length > counter)
            {
                depth = 1;
                ParseAllElements(Elements, rows[counter], depth);
            }
        }

        public static void ParseAllElements(IList<IElement> Elem, string body,int depth)
        {
            string[] elements = body.Split($" {depth}#\n", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < elements.Length; i++)
            {
                string[] parts = elements[i].Split("\n", 2, StringSplitOptions.None);
                ParseElement(Elem, parts, depth + 1);
            }
            //if (elements.Length % 2 == 1)
              //  ParseElement(Elem, elements, elements.Length, depth, false);
        }

        public static void ParseElement(IList<IElement> Elem, string[] parts, int depth, bool parse=true)
        {
            switch (parts[0].Trim())
            {
                case "Elements:":
                    ParseAllElements(Elem, parts[1], depth);
                    break;
                case "ElementCollection:":
                    ElementCollection ec = new ElementCollection();
                    if (parse)
                        ec.ParseLoad(parts[1], depth);
                    Elem.Add(ec);
                    break;
                case "TextBoxElement:":
                    TextBoxElement tbe = new TextBoxElement();
                    if(parse)
                        tbe.ParseLoad(parts[1], depth);
                    Elem.Add(tbe);
                    break;
            }
        }

        public override void PreValChange(object owner)
        {
            if(owner is SourceViewModel svm)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.sHolder.Child.Cast<SourceControl>().activeEntryHolder.Child = null;
            }
        }
        public override void PostValChange(object owner)
        {
            if (owner is SourceViewModel svm)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.sHolder.Child.Cast<SourceControl>().activeEntryHolder.Child = EControl;
            }
            //var tmp = viewModel.activeEntryHolder;
            //tmp.Child = viewModel.ucEnties[Name];
        }

        public void LoadTagsFromData(object owner)
        {
            if (owner is SourceViewModel svm)
            {

                int index = svm.PrevEntries.IndexOf(Name);
                for (int i = 0; i < svm.TagsData[index].Count; i++)
                {
                    if (svm.TagsData[index][i] == 1)
                        Tags.Add(svm.Tags.List[i]);
                }
            }
        }

    }
}

/*
           counter+=2;//skip Tags: row
           string[] tags = rows[counter].Split("2#\n", StringSplitOptions.RemoveEmptyEntries);
           for (int i = 0; i < tags.Length; i++)
           {
               Guid id = Guid.Parse(tags[i].AfterFirst(' ').Unescape());
               Tag obj = (Tag)GuidManager.GetOrMake<Tag>(id);
               Tags.Add(obj);
           }
       */
