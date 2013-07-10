using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameCreator.Framework;

namespace GameCreator.IDE
{
    partial class ActionForm : Form
    {
        ActionDeclaration action;
        ActionDeclaration originalAction;
        CheckBox[] Arrows;
        Label[] ArgLabels;
        TextBox[] ArgTextBoxes;
        Button[] ArgMenus;
        bool initialsetting;
        ContextMenuStrip objectMenu = new ContextMenuStrip();
        public ActionForm(ActionDeclaration a)
        {
            InitializeComponent();
            foreach (TreeNode n in Program.IDE.Objects.Node.Nodes)
                objectMenu.Items.Add(CreateResourceMenuItem(n, item_Click, null));
            initialsetting = true;
            pictureBoxAction.Image = a.Kind.Image;
            Text = a.Kind.Description;
            this.StartPosition = FormStartPosition.CenterParent;
            Arrows = new CheckBox[]{checkBoxSW, checkBoxS, checkBoxSE, 
                                    checkBoxW, checkBoxStop, checkBoxE,
                                    checkBoxNW, checkBoxN, checkBoxNE
                                    };
            ArgLabels = new Label[] { labelArg1, labelArg2, labelArg3, labelArg4, labelArg5, labelArg6 };
            ArgTextBoxes = new TextBox[] { textBoxArg1, textBoxArg2, textBoxArg3, textBoxArg4, textBoxArg5, textBoxArg6 };
            ArgMenus = new Button[] { buttonArg1, buttonArg2, buttonArg3, buttonArg4, buttonArg5, buttonArg6 };
            action = new ActionDeclaration(a);
            originalAction = a;
            this.radioButtonSelf.Checked = a.AppliesTo == -1;
            this.radioButtonOther.Checked = a.AppliesTo == -2;
            this.radioButtonObject.Checked = a.AppliesTo >= 0;
            this.panel1.Visible = this.radioButtonObject.Checked;
            this.label1.Text = action.AppliesTo == -1 ? "self" : action.AppliesTo == -2 ? "other" : Program.Objects.ContainsKey(action.AppliesTo) ? Program.Objects[action.AppliesTo].Name : "<undefined>";
            this.button1.Visible = this.radioButtonObject.Checked;
            this.checkBoxRelative.Checked = this.checkBoxArrowsRelative.Checked = a.Relative;
            this.checkBoxNot.Checked = this.checkBoxArrowsNot.Checked = a.Not;
            this.panelArrows.Visible = a.Kind.InterfaceKind == ActionInferfaceKind.Arrows;
            this.panelNormal.Visible = a.Kind.InterfaceKind == ActionInferfaceKind.Normal;
            this.groupBoxAppliesTo.Visible = a.Kind.ShowApplyTo;
            if (a.Kind.InterfaceKind == ActionInferfaceKind.Arrows)
            {
                for (int i = 0; i < 9; i++)
                    Arrows[i].Checked = a.Arguments[0][i] != '0';
                textBoxSpeed.Text = a.Arguments[1];
                checkBoxArrowsRelative.Visible = a.Kind.ShowRelative;
                checkBoxArrowsNot.Visible = a.Kind.IsQuestion;
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i >= a.Arguments.Count)
                    {
                        ArgLabels[i].Visible = false;
                        ArgTextBoxes[i].Visible = false;
                        ArgMenus[i].Visible = false;
                    }
                    else
                    {
                        ArgLabels[i].Text = a.Kind.Arguments[i].Caption;
                        if (a.Kind.Arguments[i].Type == ActionArgumentType.FontString)
                        {
                            string[] sl = action.Arguments[i].Split(',');
                            int col = int.Parse(sl[2]);
                            ArgTextBoxes[i].ForeColor = Color.FromArgb(255, col & 255, (col >> 8) & 255, (col >> 16) & 255);
                            FontStyle fs = FontStyle.Regular;
                            if (sl[3] == "1")
                                fs |= FontStyle.Bold;
                            if (sl[4] == "1")
                                fs |= FontStyle.Italic;
                            if (sl[5] == "1")
                                fs |= FontStyle.Underline;
                            if (sl[6] == "1")
                                fs |= FontStyle.Strikeout;
                            ArgTextBoxes[i].Font = new Font(sl[0].Replace("\"", string.Empty), float.Parse(sl[1]), fs, GraphicsUnit.Point);
                        }
                        ArgTextBoxes[i].Text = ArgToString(i);
                        ActionArgumentType t = a.Kind.Arguments[i].Type;
                        ArgTextBoxes[i].ReadOnly = t != ActionArgumentType.Expression && t != ActionArgumentType.String && t != ActionArgumentType.Both;
                        if (a.Kind.Arguments[i].Type == ActionArgumentType.Color)
                        {
                            int col = int.Parse(action.Arguments[i]);
                            ArgTextBoxes[i].BackColor = Color.FromArgb(255, col & 255, (col >> 8) & 255, (col >> 16) & 255);
                        }
                        else
                            ArgTextBoxes[i].BackColor = Color.FromKnownColor(KnownColor.Window);
                        ArgTextBoxes[i].Tag = (object)i;
                        ArgMenus[i].Tag = (object)i;
                        bool hasmenu = true;
                        switch (a.Kind.Arguments[i].Type)
                        {
                            case ActionArgumentType.Expression:
                            case ActionArgumentType.String:
                            case ActionArgumentType.Both:
                                ArgMenus[i].Visible = hasmenu = false;
                                break;
                        }
                        if (hasmenu)
                        {
                            ArgTextBoxes[i].Click += new EventHandler(argument_Click);
                            ArgMenus[i].Click += new EventHandler(argument_Click);
                        }
                    }
                }
                checkBoxRelative.Visible = a.Kind.ShowRelative;
                checkBoxNot.Visible = a.Kind.IsQuestion;
            }
            initialsetting = false;
        }
        string ArgToString(int i)
        {
            int t;
            switch (action.Kind.Arguments[i].Type)
            {
                case ActionArgumentType.Menu:
                    return action.Kind.Arguments[i].Menu.Split('|')[int.Parse(action.Arguments[i])];
                case ActionArgumentType.Sprite:
                    t = int.Parse(action.Arguments[i]);
                    SpriteResourceView spr;
                    return t < 0 ? "No sprite" : Program.Sprites.TryGetValue(t, out spr) ? spr.Name : "<undefined>";
                case ActionArgumentType.Sound:
                    SoundResourceView snd;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No sound" : Program.Sounds.TryGetValue(t, out snd) ? snd.Name : "<undefined>";
                case ActionArgumentType.Background:
                    BackgroundResourceView bg;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No background" : Program.Backgrounds.TryGetValue(t, out bg) ? bg.Name : "<undefined>";
                case ActionArgumentType.Path:
                    PathResourceView path;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No path" : Program.Paths.TryGetValue(t, out path) ? path.Name : "<undefined>";
                case ActionArgumentType.Script:
                    ScriptResourceView scr;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No script" : Program.Scripts.TryGetValue(t, out scr) ? scr.Name : "<undefined>";
                case ActionArgumentType.Font:
                    FontResourceView font;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No font" : Program.Fonts.TryGetValue(t, out font) ? font.Name : "<undefined>";
                case ActionArgumentType.Timeline:
                    TimeLineResourceView tmln;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No timeline" : Program.TimeLines.TryGetValue(t, out tmln) ? tmln.Name : "<undefined>";
                case ActionArgumentType.Object:
                    ObjectResourceView obj;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No object" : Program.Objects.TryGetValue(t, out obj) ? obj.Name : "<undefined>";
                case ActionArgumentType.Room:
                    RoomResourceView rm;
                    t = int.Parse(action.Arguments[i]);
                    return t < 0 ? "No room" : Program.Rooms.TryGetValue(t, out rm) ? rm.Name : "<undefined>";
                case ActionArgumentType.Color:
                    return string.Empty;
                case ActionArgumentType.FontString:
                    return "AaBbCc";
                case ActionArgumentType.Boolean:
                    return action.Arguments[i] == "0" ? "False" : "True";
                default:
                    return action.Arguments[i];
            }
        }
        private ToolStripItem CreateResourceMenuItem(TreeNode n, EventHandler click, object dropDownTag)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(n.Name);
            IResourceView res = n.Tag as IResourceView;
            if (res.ImageKey != null)
                item.Image = Program.IDE.ResourceImageList.Images[res.ImageKey];
            if (res.CanEdit)
                item.Click += click;
            item.Tag = res;
            item.DropDown.Tag = dropDownTag;
            foreach (TreeNode tn in res.Node.Nodes)
                item.DropDownItems.Add(CreateResourceMenuItem(tn, click, dropDownTag));
            return item;
        }

        void item_Click(object sender, EventArgs e)
        {
            IResourceView res = (sender as ToolStripMenuItem).Tag as IResourceView;
            action.AppliesTo = (int)res.ResourceID;
            label1.Text = res.Name;
        }

        private void ActionForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonSelf_CheckedChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            if (radioButtonSelf.Checked)
                action.AppliesTo = -1;
        }

        private void radioButtonOther_CheckedChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            if (radioButtonOther.Checked)
                action.AppliesTo = -2;
        }

        private void radioButtonObject_CheckedChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            panel1.Visible = button1.Visible = radioButtonObject.Checked;
        }

        private void arrows_CheckedChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            char[] c = new char[9];
            for (int i = 0; i < 9; i++)
                c[i] = Arrows[i].Checked ? '1' : '0';
            action.Arguments[0] = new string(c);
        }

        private void checkBoxRelative_CheckedChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            action.Relative = (sender as CheckBox).Checked;
        }

        private void checkBoxNot_CheckedChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            action.Not = (sender as CheckBox).Checked;
        }

        private void textBoxArg_TextChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            for (int i = 0; i < action.Arguments.Count; i++)
            {
                if (!ArgMenus[i].Visible)
                    action.Arguments[i] = ArgTextBoxes[i].Text;
            }
        }

        private void textBoxSpeed_TextChanged(object sender, EventArgs e)
        {
            if (initialsetting)
                return;
            action.Arguments[1] = textBoxSpeed.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            objectMenu.Show(MousePosition);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objectMenu.Show(MousePosition);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            originalAction.CopyFrom(action);
        }

        private void argument_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as Control).Tag;
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Tag = (sender as Control).Tag;
            IResourceView res = null;
            int col; // color
            string defstr = null;
            switch (action.Kind.Arguments[i].Type)
            {
                case ActionArgumentType.Menu:
                    foreach (string s in action.Kind.Arguments[i].Menu.Split('|'))
                        menu.Items.Add(s).Click += new EventHandler(argCustomMenuItem_Click);
                    break;
                case ActionArgumentType.Background:
                    res = Program.IDE.Backgrounds;
                    defstr = "No background";
                    break;
                case ActionArgumentType.Font:
                    res = Program.IDE.Fonts;
                    defstr = "No font";
                    break;
                case ActionArgumentType.Object:
                    res = Program.IDE.Objects;
                    defstr = "No object";
                    break;
                case ActionArgumentType.Path:
                    res = Program.IDE.Paths;
                    defstr = "No path";
                    break;
                case ActionArgumentType.Room:
                    res = Program.IDE.Rooms;
                    defstr = "No room";
                    break;
                case ActionArgumentType.Script:
                    res = Program.IDE.Scripts;
                    defstr = "No script";
                    break;
                case ActionArgumentType.Sound:
                    res = Program.IDE.Sounds;
                    defstr = "No sound";
                    break;
                case ActionArgumentType.Sprite:
                    res = Program.IDE.Sprites;
                    defstr = "No sprite";
                    break;
                case ActionArgumentType.Timeline:
                    res = Program.IDE.TimeLines;
                    defstr = "No timeline";
                    break;
                case ActionArgumentType.Boolean:
                    menu.Items.Add("True").Click += new EventHandler(true_Click);
                    menu.Items.Add("False").Click += new EventHandler(false_Click);
                    break;
                case ActionArgumentType.Color:
                    ColorDialog d = new ColorDialog();
                    col = int.Parse(action.Arguments[i]);
                    d.Color = Color.FromArgb(255, col & 255, (col >> 8) & 255, (col >> 16) & 255);
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        ArgTextBoxes[i].BackColor = d.Color;
                        action.Arguments[i] = ((int)d.Color.R | ((int)d.Color.G << 8) | ((int)d.Color.B << 16)).ToString();
                    }
                    break;
                case ActionArgumentType.FontString:
                    FontDialog dialog = new FontDialog();
                    dialog.ShowColor = true;
                    string[] sl = action.Arguments[i].Split(',');
                    col = int.Parse(sl[2]);
                    dialog.Color = Color.FromArgb(255, col & 255, (col >> 8) & 255, (col >> 16) & 255);
                    FontStyle fs = FontStyle.Regular;
                    if (sl[3] == "1")
                        fs |= FontStyle.Bold;
                    if (sl[4] == "1")
                        fs |= FontStyle.Italic;
                    if (sl[5] == "1")
                        fs |= FontStyle.Underline;
                    if (sl[6] == "1")
                        fs |= FontStyle.Strikeout;
                    dialog.Font = new Font(sl[0].Replace("\"", string.Empty), float.Parse(sl[1]), fs, GraphicsUnit.Point);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        action.Arguments[i] = string.Format(
                            "\"{0}\",{1},{2},{3},{4},{5},{6}",
                            dialog.Font.Name,
                            (int)Math.Round(dialog.Font.SizeInPoints),
                            ((int)dialog.Color.R | ((int)dialog.Color.G << 8) | ((int)dialog.Color.B << 16)).ToString(),
                            dialog.Font.Bold ? "1" : "0",
                            dialog.Font.Italic ? "1" : "0",
                            dialog.Font.Underline ? "1" : "0",
                            dialog.Font.Strikeout ? "1" : "0"
                            );
                        ArgTextBoxes[i].Font = dialog.Font;
                        ArgTextBoxes[i].ForeColor = dialog.Color;
                    }
                    break;
            }
            if (res != null)
            {
                menu.Items.Add(defstr).Click += new EventHandler(defaultItem_Click);
                foreach (TreeNode n in res.Node.Nodes)
                    menu.Items.Add(CreateResourceMenuItem(n, new EventHandler(resItem_Click), menu.Tag));
            }
            menu.Show(MousePosition);
        }

        void resItem_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as ToolStripItem).Owner.Tag;
            action.Arguments[i] = ((sender as ToolStripItem).Tag as IResourceView).ResourceID.ToString();
            ArgTextBoxes[i].Text = (sender as ToolStripItem).Text;
        }

        void defaultItem_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as ToolStripItem).Owner.Tag;
            action.Arguments[i] = "-1";
            ArgTextBoxes[i].Text = (sender as ToolStripItem).Text;
        }
        

        void false_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as ToolStripItem).Owner.Tag;
            action.Arguments[i] = "0";
            ArgTextBoxes[i].Text = "False";
        }

        void true_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as ToolStripItem).Owner.Tag;
            action.Arguments[i] = "1";
            ArgTextBoxes[i].Text = "True";
        }

        void argCustomMenuItem_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as ToolStripItem).Owner.Tag;
            action.Arguments[i] = (sender as ToolStripItem).Owner.Items.IndexOf(sender as ToolStripItem).ToString();
            ArgTextBoxes[i].Text = (sender as ToolStripItem).Text;
        }
    }
}
