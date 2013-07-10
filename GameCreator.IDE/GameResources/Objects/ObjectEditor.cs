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
    partial class ObjectEditor : Form
    {
        public ObjectEditor(ObjectResourceView obj)
        {
            InitializeComponent();
            resourceSelector1.TopResource = Program.IDE.Sprites;
            resourceSelector2.TopResource = Program.IDE.Objects;
            resourceSelector3.TopResource = Program.IDE.Sprites;
        }

        public event EventHandler Save;
        public bool Saved;
        public IEnumerable<ObjectEvent> ObjectEvents
        { 
            get { return listBox2.Items.Cast<ObjectEvent>(); }
            set
            {
                listBox2.BeginUpdate();
                foreach (ObjectEvent ev in value)
                    AddEvent(ev, false);
                listBox2.SelectedIndex = Math.Min(listBox2.Items.Count - 1, 0);
                listBox2.EndUpdate();
            }
        }
        public bool VisibleChecked { get { return checkBoxVisible.Checked; } set { checkBoxVisible.Checked = value; } }
        public bool SolidChecked { get { return checkBoxSolid.Checked; } set { checkBoxSolid.Checked = value; } }
        public bool PersistentChecked { get { return checkBoxPersistent.Checked; } set { checkBoxPersistent.Checked = value; } }
        public SpriteResourceView Sprite { get { return resourceSelector1.SelectedResource as SpriteResourceView; } set { resourceSelector1.SelectedResource = value; } }
        public ObjectResourceView ObjectParent { get { return resourceSelector2.SelectedResource as ObjectResourceView; } set { resourceSelector2.SelectedResource = value; } }
        public SpriteResourceView Mask { get { return resourceSelector3.SelectedResource as SpriteResourceView; } set { resourceSelector3.SelectedResource = value; } }
        public string ObjectName { get { return textBoxName.Text; } set { textBoxName.Text = value; } }
        double depth;
        public double Depth { get { return depth; } set { textBox1.Text = value.ToString(); depth = value; } }
        private void ObjectEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
                switch (MessageBox.Show("Save changes to the object?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        Save(this, EventArgs.Empty);
                        Saved = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Save != null)
                Save(this, EventArgs.Empty);
            Saved = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EventForm ef = new EventForm();
            if (ef.ShowDialog() == DialogResult.OK)
            {
                ObjectEvent ev = new ObjectEvent(ef.EventType, ef.EventNumber);
                AddEvent(ev, true);
            }
        }
        void AddEvent(ObjectEvent ev, bool select)
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                ObjectEvent e2 = listBox2.Items[i] as ObjectEvent;
                if ((e2.EventType > ev.EventType) ||
                    (e2.EventType == ev.EventType && e2.EventNumber > ev.EventNumber))
                {
                    listBox2.Items.Insert(i, ev);
                    if (select) listBox2.SelectedIndex = i;
                    return;
                }
                else if (e2.EventType == ev.EventType && e2.EventNumber == ev.EventNumber)
                {
                    if (select) listBox2.SelectedIndex = i;
                    return;
                }
            }
            listBox2.Items.Add(ev);
            if (select) listBox2.SelectedIndex = listBox2.Items.Count - 1;
        }
        string EventToString(EventType ev, int num)
        {
            switch (ev)
            {
                case EventType.Create:
                    return "Create";
                case EventType.Alarm:
                    return string.Format("Alarm {0}", num);
                case EventType.Collision:
                    return Program.Objects[num].Name;
                case EventType.Destroy:
                    return "Destroy";
                case EventType.Draw:
                    return "Draw";
                case EventType.Keyboard:
                    return KeyCodes.Names[num];
                case EventType.KeyPress:
                    return string.Format("press {0}", KeyCodes.Names[num]);
                case EventType.KeyRelease:
                    return string.Format("release {0}", KeyCodes.Names[num]);
                case EventType.Mouse:
                    return MouseEvents.Names[num];
                case EventType.Other:
                    return OtherEvents.Names[num];
                case EventType.Step:
                    return StepEvents.Names[num];
                default:
                    return string.Empty;
            }
        }
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Rectangle textrect = e.Bounds;
            textrect.Offset(18, 0);
            ObjectEvent ev = listBox2.Items[e.Index] as ObjectEvent;
            string str = EventToString(ev.EventType, ev.EventNumber);
            System.Drawing.Bitmap bmp = null;
            switch (ev.EventType)
            {
                case EventType.Create:
                    bmp = Properties.Resources.Create;
                    break;
                case EventType.Destroy:
                    bmp = Properties.Resources.Destroy;
                    break;
                case EventType.Alarm:
                    bmp = Properties.Resources.Alarm;
                    break;
                case EventType.Step:
                    bmp = Properties.Resources.Step;
                    break;
                case EventType.Collision:
                    bmp = Properties.Resources.Collision;
                    break;
                case EventType.Keyboard:
                    bmp = Properties.Resources.Keyboard;
                    break;
                case EventType.Mouse:
                    bmp = Properties.Resources.Mouse;
                    break;
                case EventType.Draw:
                    bmp = Properties.Resources.Sprite;
                    break;
                case EventType.KeyPress:
                    bmp = Properties.Resources.KeyPress;
                    break;
                case EventType.KeyRelease:
                    bmp = Properties.Resources.KeyRelease;
                    break;
                case EventType.Other:
                    bmp = Properties.Resources.GreenCube;
                    break;
            }
            if (bmp != null)
                e.Graphics.DrawImage(bmp, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, 16, 16));
            e.Graphics.DrawString(str, e.Font, new SolidBrush(e.ForeColor), (float)e.Bounds.X + 20f, (float)e.Bounds.Y+((float)e.Bounds.Height-e.Graphics.MeasureString(str, e.Font).Height)/2);
            e.DrawFocusRectangle();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                actionPanel1.Actions = new ActionDeclaration[0];
            else
            {
                ObjectEvent ev = listBox2.SelectedItem as ObjectEvent;
                actionPanel1.Actions = ev.Actions;
            }
        }

        private void actionPanel1_BeforeActionDrop(object sender, CancelEventArgs e)
        {
            if (listBox2.Items.Count == 0 || listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select or add an event before you can add actions.", Program.IDE.Text);
                e.Cancel = true;
            }
        }

        private void actionPanel1_ActionDrop(object sender, EventArgs e)
        {
            ObjectEvent ev = listBox2.SelectedItem as ObjectEvent;
            ev.Actions = new List<ActionDeclaration>(actionPanel1.Actions);
            Saved = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                return;
            int i = listBox2.SelectedIndex;
            listBox2.Items.RemoveAt(i);
            listBox2.SelectedIndex = Math.Min(listBox2.Items.Count - 1, i);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                return;
            EventForm ef = new EventForm();
            List<ActionDeclaration> actions = (listBox2.SelectedItem as ObjectEvent).Actions;
            if (ef.ShowDialog() == DialogResult.OK)
            {
                listBox2.BeginUpdate();
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                ObjectEvent ev = new ObjectEvent(ef.EventType, ef.EventNumber);
                ev.Actions = actions;
                AddEvent(ev, true);
                listBox2.EndUpdate();
            }
        }

        private void checkBoxVisible_CheckedChanged(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void checkBoxSolid_CheckedChanged(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void checkBoxPersistent_CheckedChanged(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out depth)) 
            {
                textBox1.BackColor = Color.FromKnownColor(KnownColor.Window);
                Saved = false;
            }
            else
                textBox1.BackColor = Color.Red;
        }

        private void resourceSelector1_SelectedResourceChanged(object sender, EventArgs e)
        {
            Saved = false;
            if (resourceSelector1.SelectedResource != null)
                pictureBox1.Image = Program.IDE.ResourceImageList.Images[resourceSelector1.SelectedResource.ImageKey];
        }

        private void resourceSelector2_SelectedResourceChanged(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void resourceSelector3_SelectedResourceChanged(object sender, EventArgs e)
        {
            Saved = false;
        }
    }
}
