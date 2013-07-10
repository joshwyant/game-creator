using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameCreator.Framework;

namespace GameCreator.IDE
{
    partial class ActionPanel : UserControl
    {
        class ActionTag
        {
            public ToolTip ToolTip;
            public ActionDefinition Action;
        }
        public ActionPanel()
        {
            InitializeComponent();
            listBox1.Focus();
        }
        public event EventHandler ActionDrop;
        public event CancelEventHandler BeforeActionDrop;
        public IEnumerable<ActionDeclaration> Actions
        {
            get
            {
                return listBox1.Items.Cast<ActionDeclaration>();
            }
            set
            {
                int i = 0;
                int indent = 0;
                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                foreach (ActionDeclaration ad in value)
                {
                    ad.ListBox = listBox1;
                    ad.ListIndex = i++;
                    ad.Indent = indent;
                    if (ad.Kind.Kind == ActionKind.BeginGroup)
                        ad.Indent = ++indent;
                    else if (ad.Kind.Kind == ActionKind.EndGroup)
                        ad.Indent = indent--;
                    listBox1.Items.Add(ad);
                }
                listBox1.EndUpdate();
            }
        }
        void pb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.DoDragDrop(new ActionDataObject(new ActionDeclaration(((ActionTag)pb.Tag).Action)), DragDropEffects.Move);
        }

        void pb_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            ActionTag at = (ActionTag)pb.Tag;
            at.ToolTip.Show(at.Action.Description, pb);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(ActionDeclaration)) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            drag = false;
            CancelEventArgs t_e = new CancelEventArgs();
            BeforeActionDrop(this, t_e);
            if (t_e.Cancel)
                return;
            int y = listBox1.PointToClient(new Point(e.X, e.Y)).Y;
            int i = listBox1.TopIndex + (int)Math.Round((float)y / 26f);
            int absindex = listBox1.TopIndex + y / 26;
            ActionDeclaration a = (ActionDeclaration)e.Data.GetData(typeof(ActionDeclaration));
            if (absindex == a.ListIndex && a.ListBox == listBox1)
                return;
            listBox1.BeginUpdate();
            bool lb = a.ListBox != null;
            if (i >= listBox1.Items.Count)
            {
                listBox1.Items.Add(a);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
            else
                listBox1.Items.Insert(i, a);
            if (lb)
                a.ListBox.Items.RemoveAt(i <= a.ListIndex && a.ListBox == listBox1 ? a.ListIndex + 1 : a.ListIndex);
            a.ListBox = listBox1;
            int indent = 0;
            for (int j = 0; j < listBox1.Items.Count; j++)
            {
                ActionDeclaration ad = (ActionDeclaration)listBox1.Items[j];
                ad.ListIndex = j;
                ad.Indent = indent;
                if (ad.Kind.Kind == ActionKind.BeginGroup)
                    ad.Indent = ++indent;
                else if (ad.Kind.Kind == ActionKind.EndGroup)
                    ad.Indent = indent--;
                if (indent < 0)
                    indent = 0;
            }
            foreach (int s in listBox1.SelectedIndices)
                listBox1.SetSelected(s, false);
            listBox1.SelectedIndex = a.ListIndex;
            listBox1.EndUpdate();
            if (!lb && a.Edit() == DialogResult.Cancel)
                listBox1.Items.RemoveAt(a.ListIndex);
            else
            {
                listBox1.Refresh();
                ActionDrop(this, EventArgs.Empty);
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!DesignMode)
            {
                if (e.Index < 0 || e.Index >= listBox1.Items.Count)
                    // because when deleting the last item in the list, this gets called with e.Index = -1. huh!??
                    return;
                e.DrawBackground();
                ActionDeclaration a = (ActionDeclaration)listBox1.Items[e.Index];
                e.Graphics.DrawImage(a.Kind.Image, Point.Add(e.Bounds.Location, new Size(a.Indent * 16 + 1, 1)));
                e.Graphics.DrawString(a.ListText, new Font(e.Font, a.FontStyle), new SolidBrush(e.ForeColor), new Point(e.Bounds.X + 26 + a.Indent * 16, e.Bounds.Y + 13 - (int)(e.Graphics.MeasureString(a.ListText, e.Font).Height / 2)));
                e.DrawFocusRectangle();
            }
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 26;
        }

        int clickindex = -1;
        Point clickpos = Point.Empty;
        bool drag;

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clickindex = listBox1.TopIndex + e.Y / 26;
            if (clickindex >= listBox1.Items.Count)
                clickindex = -1;
            clickpos = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
            }
            else if (e.Button == MouseButtons.Right && clickindex >= 0)
            {
                if (!listBox1.SelectedIndices.Contains(clickindex))
                    listBox1.SelectedIndices.Clear();
                listBox1.SelectedIndex = clickindex;
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void ActionPanel_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            foreach (ActionLibrary lib in Program.Library)
            {
                TabPage tp = new TabPage(lib.TabCaption);
                Panel p = new Panel();
                p.Dock = DockStyle.Fill;
                p.AutoScroll = true;
                tp.Controls.Add(p);
                int col = 0;
                int y = 0;
                foreach (ActionDefinition ad in lib.Actions)
                {
                    if (col == 3 || (col != 0 && ad.Kind == ActionKind.Label))
                    {
                        col = 0;
                        y += 32;
                    }
                    if (ad.Kind == ActionKind.Label)
                    {
                        Label l = new Label();
                        l.AutoSize = true;
                        l.Text = ad.Name;
                        l.Location = new Point(0, y);
                        p.Controls.Add(l);
                        y += l.Height + 3;
                    }
                    else if (ad.Kind != ActionKind.Separator && !ad.Hidden)
                    {
                        if (ad.Kind != ActionKind.Placeholder)
                        {
                            PictureBox pb = new PictureBox();
                            pb.BackColor = Color.Transparent;
                            pb.Size = new Size(24, 24);
                            pb.Image = ad.Image;
                            pb.Location = new Point(3 + col * 32, y);
                            pb.MouseDown += new MouseEventHandler(pb_MouseDown);
                            pb.MouseHover += new EventHandler(pb_MouseHover);
                            ActionTag at = new ActionTag();
                            at.Action = ad;
                            at.ToolTip = new ToolTip();
                            at.ToolTip.InitialDelay = 1000;
                            pb.Tag = at;
                            p.Controls.Add(pb);
                        }
                        col++;
                    }
                }
                tabControl1.TabPages.Add(tp);
            }
        }
        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int i = listBox1.TopIndex + listBox1.PointToClient(MousePosition).Y / 26;
            if (i != tooltipitem)
            {
                tooltipitem = i;
                if (tooltipitem >= listBox1.Items.Count)
                {
                    tooltipitem = -1;
                    toolTip1.Hide(listBox1);
                }
                timer1.Start();
            }
            if (!drag || clickpos == e.Location)
                return;
            if (clickindex != -1)
            {
                listBox1.DoDragDrop(new ActionDataObject((ActionDeclaration)listBox1.Items[clickindex]), DragDropEffects.Move);
            }
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (clickindex == -1)
                return;
            (listBox1.Items[clickindex] as ActionDeclaration).Edit();
        }

        private void listBox1_MouseHover(object sender, EventArgs e)
        {

        }
        int tooltipitem = -1;
        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            tooltipitem = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tooltipitem < 0 || tooltipitem >= listBox1.Items.Count)
                return;
            if (tooltipitem >= 0)
                toolTip1.Show((listBox1.Items[tooltipitem] as ActionDeclaration).HintText, listBox1);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                listBox1.BeginUpdate();
                int i = listBox1.SelectedIndex;
                foreach (ActionDeclaration a in listBox1.SelectedItems.Cast<ActionDeclaration>().ToArray())
                    listBox1.Items.Remove(a);
                listBox1.SelectedIndex = Math.Min(listBox1.Items.Count - 1, i);
                listBox1.EndUpdate();
            }
            ActionDrop(this, EventArgs.Empty);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled = listBox1.SelectedItem != null;
            deleteToolStripMenuItem.Enabled = listBox1.SelectedItems.Count != 0;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            int i = listBox1.SelectedIndex;
            foreach (ActionDeclaration a in listBox1.SelectedItems.Cast<ActionDeclaration>().ToArray())
                listBox1.Items.Remove(a);
            listBox1.SelectedIndex = Math.Min(listBox1.Items.Count - 1, i);
            listBox1.EndUpdate();
            ActionDrop(this, EventArgs.Empty);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ActionDrop(this, EventArgs.Empty);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                (listBox1.Items[clickindex] as ActionDeclaration).Edit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
