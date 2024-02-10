using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ResourceContextMenuStrip : System.Windows.Forms.ContextMenuStrip
    {
        ToolStripMenuItem ItemInsert = new ToolStripMenuItem("Insert");
        ToolStripMenuItem ItemDuplicate = new ToolStripMenuItem("Duplicate");
        ToolStripMenuItem ItemSpecial = new ToolStripMenuItem("Special");
        ToolStripMenuItem ItemInsertGroup = new ToolStripMenuItem("Insert Group");
        ToolStripMenuItem ItemSortByName = new ToolStripMenuItem("Sort by Name");
        ToolStripMenuItem ItemDelete = new ToolStripMenuItem("Delete");
        ToolStripMenuItem ItemRename = new ToolStripMenuItem("Rename");
        ToolStripMenuItem ItemProperties = new ToolStripMenuItem("Properties");
        IResourceView irv;
        public ResourceContextMenuStrip(IResourceView irv)
        {
            this.irv = irv;
            // Set the 'enabled' properties
            ItemInsert.Enabled = irv.CanInsert;
            ItemDuplicate.Enabled = irv.CanDuplicate;
            ItemInsertGroup.Enabled = irv.CanInsertGroup;
            ItemSortByName.Enabled = irv.CanSort;
            ItemDelete.Enabled = irv.CanDelete;
            ItemRename.Enabled = irv.CanRename;
            ItemProperties.Enabled = irv.CanEdit;
            // Set custom icons and text
            if (!string.IsNullOrEmpty(irv.InsertString))
                ItemInsert.Text = irv.InsertString;
            if (irv.HasSpecialAction)
            {
                ItemSpecial.Image = irv.SpecialActionImage;
                ItemSpecial.Text = irv.SpecialActionName;
            }
            if (!string.IsNullOrEmpty(irv.InsertGroupString))
                ItemInsertGroup.Text = irv.InsertGroupString;
            // More images
            ItemInsert.Image = Properties.Resources.Add;
            ItemDuplicate.Image = Properties.Resources.Copy;
            ItemInsertGroup.Image = Properties.Resources.CreateFolder;
            ItemDelete.Image = Properties.Resources.Delete;
            ItemRename.Image = Properties.Resources.Rename;
            ItemProperties.Image = Properties.Resources.Preferences;
            // Set the events for the items
            ItemInsert.Click += new EventHandler(ItemInsert_Click);
            ItemDuplicate.Click += new EventHandler(ItemDuplicate_Click);
            ItemSpecial.Click += new EventHandler(ItemSpecial_Click);
            ItemInsertGroup.Click += new EventHandler(ItemInsertGroup_Click);
            ItemSortByName.Click += new EventHandler(ItemSortByName_Click);
            ItemDelete.Click += new EventHandler(ItemDelete_Click);
            ItemRename.Click += new EventHandler(ItemRename_Click);
            ItemProperties.Click += new EventHandler(ItemProperties_Click);
            // Add the items
            Items.Add(ItemInsert);
            Items.Add(ItemDuplicate);
            Items.Add(new ToolStripSeparator());
            if (irv.HasSpecialAction)
            {
                Items.Add(ItemSpecial);
                Items.Add(new ToolStripSeparator());
            }
            Items.Add(ItemInsertGroup);
            Items.Add(new ToolStripSeparator());
            Items.Add(ItemSortByName);
            Items.Add(new ToolStripSeparator());
            Items.Add(ItemDelete);
            Items.Add(new ToolStripSeparator());
            Items.Add(ItemRename);
            Items.Add(new ToolStripSeparator());
            Items.Add(ItemProperties);
            
        }

        void ItemProperties_Click(object sender, EventArgs e)
        {
            irv.Edit();
        }

        void ItemRename_Click(object sender, EventArgs e)
        {
            irv.Node.BeginEdit();
        }

        void ItemDelete_Click(object sender, EventArgs e)
        {
            irv.Delete();
        }

        void ItemSortByName_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            foreach (TreeNode n in irv.Node.Nodes)
                l.Add(n.Name);
            l.Sort();
            int i = 0;
            foreach (string s in l)
            {
                TreeNode n = irv.Node.Nodes[s];
                n.Remove();
                irv.Node.Nodes.Insert(i++, n);
            }
        }

        void ItemInsertGroup_Click(object sender, EventArgs e)
        {
            irv.InsertGroup();
        }

        void ItemSpecial_Click(object sender, EventArgs e)
        {
            irv.SpecialAction();
        }

        void ItemDuplicate_Click(object sender, EventArgs e)
        {
            irv.Duplicate();
        }

        void ItemInsert_Click(object sender, EventArgs e)
        {
            irv.Insert();
        }
    }
}
