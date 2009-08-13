using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class RoomResourceView : IResourceView, IDeletable
    {
        string name;
        string creationCode = string.Empty;
        public string CreationCode
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.CreationCode;
                return creationCode;
            }
            set { creationCode = value; }
        }
        RoomEditor editor;
        DesignerForm parent;
        long id;
        public RoomResourceView(DesignerForm parent, long index)
        {
            this.parent = parent;
            id = index;
        }

        void editor_Save(object sender, EventArgs e)
        {
            creationCode = editor.CreationCode;
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
            if (MessageBox.Show(string.Format("Are you sure you want to permanently delete {0}?", name), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DoDelete(true);
            }
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
            RoomResourceView res = new RoomResourceView(parent, RoomsResourceView.ids);
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res);
            parent.AddResource(Node.Parent, res, "room" + RoomsResourceView.ids++.ToString(), Node.Index, true, false, true);
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
        {
            RoomResourceView res = new RoomResourceView(parent, RoomsResourceView.ids);
            RoomsResourceView.rooms.Add(RoomsResourceView.ids, res);
            res.CreationCode = CreationCode;
            parent.AddResource(Node.Parent, res, "room" + RoomsResourceView.ids++.ToString(), Node.Index + 1, true, false, true);
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
            parent.AddResource(Node.Parent, new RoomGroupResourceView(parent), null, Node.Index, true, true, false);
        }

        public bool CanSort
        {
            get { return false; }
        }

        #endregion

        #region IDeletable Members

        public void DoDelete(bool removenode)
        {
            if (editor != null && editor.Created)
            {
                editor.Saved = true;
                editor.Close();
            }
            RoomsResourceView.rooms.Remove(id);
            if (removenode) Node.Remove();
        }

        #endregion
    }
}
