using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.IDE
{
    class ActionDeclaration
    {
        public ActionDeclaration(ActionDefinition kind, System.Windows.Forms.ListBox lb, int li)
        {
            Kind = kind;
            Relative = false;
            Not = false;
            AppliesTo = -1;
            Indent = 0;
            ListBox = lb;
            ListIndex = li;
            Arguments = new List<string>();
            for (int i = 0; i < Kind.ArgumentCount; i++)
                Arguments.Add(Kind.Arguments[i].DefaultValue);
        }
        public ActionDeclaration(ActionDeclaration copy)
        {
            CopyFrom(copy);
        }
        public void CopyFrom(ActionDeclaration copy)
        {
            Kind = copy.Kind;
            Relative = copy.Relative;
            Not = copy.Not;
            AppliesTo = copy.AppliesTo;
            Indent = copy.Indent;
            ListBox = copy.ListBox;
            ListIndex = copy.ListIndex;
            Arguments = new List<string>(copy.Arguments);
        }
        public ActionDeclaration(ActionDefinition kind) : this(kind, null, -1) { }
        public System.Windows.Forms.DialogResult Edit()
        {
            if (Kind.InterfaceKind == ActionInferfaceKind.None)
                return System.Windows.Forms.DialogResult.OK;
            if (Kind.InterfaceKind == ActionInferfaceKind.Code)
            {
                CodeEditor e = new CodeEditor();
                e.Code = Arguments[0];
                e.ShowDialog(ListBox == null ? null : ListBox.FindForm());
                if (e.DialogResult == System.Windows.Forms.DialogResult.OK)
                    Arguments[0] = e.Code;
                return e.DialogResult;
            }
            return new ActionForm(this).ShowDialog(ListBox == null ? null : ListBox.FindForm());
        }
        public ActionDefinition Kind { get; set; }
        public System.Windows.Forms.ListBox ListBox { get; set; }
        public int ListIndex { get; set; }
        public bool Relative { get; set; }
        public bool Not { get; set; }
        public int AppliesTo { get; set; }
        public int Indent { get; set; }
        public List<string> Arguments { get; private set; }
        public System.Drawing.FontStyle FontStyle
        {
            get
            {
                System.Drawing.FontStyle fs = System.Drawing.FontStyle.Regular;
                if (Kind.ListText.Contains("@FI")) fs |= System.Drawing.FontStyle.Italic;
                if (Kind.ListText.Contains("@FB")) fs |= System.Drawing.FontStyle.Bold;
                return fs;
            }
        }
        public string ArgumentToString(int i)
        {
            if (i >= Kind.ArgumentCount)
                return string.Empty;
            switch (Kind.Arguments[i].Type)
            {
                case ActionArgumentType.Boolean:
                    return Arguments[i] == "1" ? "true" : "false";
                case ActionArgumentType.Menu:
                    return Kind.Arguments[i].Menu.Split('|')[int.Parse(Arguments[i])];
                case ActionArgumentType.Object:
                    ObjectResourceView obj;
                    int t = int.Parse(Arguments[i]);
                    return Program.Objects.TryGetValue(t, out obj) ? obj.Name : t == -1 ? "self" : t == -2 ? "other" : "<undefined>";
                case ActionArgumentType.Room:
                    RoomResourceView rm;
                    return Program.Rooms.TryGetValue(int.Parse(Arguments[i]), out rm) ? rm.Name : "<undefined>";
                case ActionArgumentType.Script:
                    ScriptResourceView scr;
                    return Program.Scripts.TryGetValue(int.Parse(Arguments[i]), out scr) ? scr.Name : "<undefined>";
                case ActionArgumentType.Sound:
                    SoundResourceView snd;
                    return Program.Sounds.TryGetValue(int.Parse(Arguments[i]), out snd) ? snd.Name : "<undefined>";
                case ActionArgumentType.Path:
                    PathResourceView path;
                    return Program.Paths.TryGetValue(int.Parse(Arguments[i]), out path) ? path.Name : "<undefined>";
                case ActionArgumentType.Background:
                    BackgroundResourceView bg;
                    return Program.Backgrounds.TryGetValue(int.Parse(Arguments[i]), out bg) ? bg.Name : "<undefined>";
                case ActionArgumentType.Font: // Which could also be a datafile, depending on the version of game maker the action is for
                    FontResourceView fnt;
                    return Program.Fonts.TryGetValue(int.Parse(Arguments[i]), out fnt) ? fnt.Name : "<undefined>";
                case ActionArgumentType.Timeline:
                    TimeLineResourceView tmln;
                    return Program.TimeLines.TryGetValue(int.Parse(Arguments[i]), out tmln) ? tmln.Name : "<undefined>";
                case ActionArgumentType.Sprite:
                    SpriteResourceView spr;
                    return Program.Sprites.TryGetValue(int.Parse(Arguments[i]), out spr) ? spr.Name : "<undefined>";
                default:
                    return Arguments[i];
            }
        }
        string FormatString(string s)
        {
            return s.Replace("@w", AppliesTo == -1 ? string.Empty : AppliesTo == -2 ? "for other object: " : string.Format("for all {0}: ", Program.Objects.ContainsKey(AppliesTo) ? Program.Objects[AppliesTo].Name : "<undefined>"))
                .Replace("@r", Relative ? "relative to " : string.Empty)
                .Replace("@N", Not ? "not " : string.Empty)
                .Replace("#", "\r\n")
                .Replace("@0", ArgumentToString(0))
                .Replace("@1", ArgumentToString(1))
                .Replace("@2", ArgumentToString(2))
                .Replace("@3", ArgumentToString(3))
                .Replace("@4", ArgumentToString(4))
                .Replace("@5", ArgumentToString(5))
                .Replace("@6", ArgumentToString(6))
                .Replace("@7", ArgumentToString(7))
                .Replace("@FI", string.Empty)
                ;
        }
        public override string ToString()
        {
            return ListText;
        }
        public string ListText
        {
            get
            {
                return FormatString(Kind.ListText);
            }
        }
        public string HintText
        {
            get
            {
                return FormatString(Kind.HintText);
            }
        }
    }
}
