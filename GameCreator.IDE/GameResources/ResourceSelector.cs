using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE.GameResources
{
    [DefaultEvent("SelectedResourceChanged")]
    partial class ResourceSelector : UserControl
    {
        public IResourceView TopResource { get; set; }
        IResourceView selectedResource;
        public IResourceView SelectedResource
        {
            get
            {
                return selectedResource;
            }
            set
            {
                selectedResource = value;
                label1.Text = value == null ? defaultText : value.Name;
                if (SelectedResourceChanged != null)
                    SelectedResourceChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler SelectedResourceChanged;
        string defaultText;
        [DefaultValue("<none>")]
        public string DefaultText { get { return defaultText; } set { label1.Text = defaultText = value; } }
        public override string Text { get { return label1.Text; } }
        public ResourceSelector()
        {
            InitializeComponent();
        }
        void ShowMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add(defaultText).Click += new EventHandler(defaultItem_Click);
            foreach (TreeNode n in TopResource.Node.Nodes)
                menu.Items.Add(CreateItem(n.Tag as IResourceView));
            menu.Show(MousePosition);
        }

        ToolStripMenuItem CreateItem(IResourceView res)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(res.Name);
            if (res.ImageKey != null)
                item.Image = Program.IDE.ResourceImageList.Images[res.ImageKey];
            if (res.CanEdit)
                item.Click += new EventHandler(item_Click);
            item.Tag = res;
            foreach (TreeNode n in res.Node.Nodes)
                item.DropDownItems.Add(CreateItem(n.Tag as IResourceView));
            return item;
        }

        void item_Click(object sender, EventArgs e)
        {
            SelectedResource = (sender as ToolStripMenuItem).Tag as IResourceView;
        }

        void defaultItem_Click(object sender, EventArgs e)
        {
            SelectedResource = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }
    }
}
