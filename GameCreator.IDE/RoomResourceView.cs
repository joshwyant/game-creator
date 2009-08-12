using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class RoomResourceView : IResourceView
    {
        string name;
        public string CreationCode = string.Empty;
        RoomEditor editor;
        DesignerForm parent;
        public RoomResourceView(DesignerForm parent)
        {
            this.parent = parent;
        }

        void editor_Save(object sender, EventArgs e)
        {
            CreationCode = editor.CreationCode;
        }
        #region IResourceView Members

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (NameChanged != null) NameChanged(this, EventArgs.Empty);
            }
        }

        public bool CanRename
        {
            get { return true; }
        }

        public event EventHandler NameChanged;

        public bool HasSpecialAction
        {
            get { return false; }
        }

        public string SpecialActionName
        {
            get { throw new NotImplementedException(); }
        }

        public System.Drawing.Image SpecialActionImage
        {
            get { throw new NotImplementedException(); }
        }

        public void SpecialAction()
        {
            throw new NotImplementedException();
        }

        public string ImageKey
        {
            get { return "Room"; }
        }

        public string ExpandedImageKey
        {
            get { return "Room"; }
        }

        public System.Windows.Forms.TreeNode Node
        {
            get;
            set;
        }

        public bool CanEdit
        {
            get { return true; }
        }

        public void Edit()
        {
            if (editor != null && editor.Created)
                editor.Focus();
            else
            {
                editor = new RoomEditor();
                editor.Save += new EventHandler(editor_Save);
                editor.CreationCode = CreationCode;
                editor.Text = "Room Properties: " + name;
                editor.MdiParent = parent;
                editor.Show();
            }
        }

        public bool CanDelete
        {
            get { return true; }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public string InsertString
        {
            get { return "Insert Room"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            RoomResourceView res = new RoomResourceView(parent);
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res);
            res.Name = "room" + RoomsResourceView.ids++.ToString();
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            Node.Parent.Nodes.Insert(Node.Index, tn);
            tn.EnsureVisible();
            res.Edit();
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
        {
            RoomResourceView res = new RoomResourceView(parent);
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res);
            res.Name = "room" + RoomsResourceView.ids++.ToString();
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            Node.Parent.Nodes.Insert(Node.Index+1, tn);
            tn.EnsureVisible();
            res.Edit();
        }

        public string InsertGroupString
        {
            get { return "Insert Group"; }
        }

        public bool CanInsertGroup
        {
            get { return true; }
        }

        public void InsertGroup()
        {
            RoomGroupResourceView res = new RoomGroupResourceView(parent);
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            Node.Parent.Nodes.Insert(Node.Index, tn);
            tn.EnsureVisible();
            tn.BeginEdit();
        }

        public bool CanSort
        {
            get { return false; }
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
