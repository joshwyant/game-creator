using System;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class FontResourceView : IResourceView, IDeletable
    {
        string name;
        FontEditor editor;
        int id;
        public FontResourceView(int index)
        {
            id = index;
        }

        void editor_Save(object sender, EventArgs e)
        {

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
            get { return "Font"; }
        }

        public string ExpandedImageKey
        {
            get { return "Font"; }
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
                editor = new FontEditor();
                editor.Save += new EventHandler(editor_Save);
                editor.Text = "Font Properties: " + name;
                editor.MdiParent = Program.IDE;
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
            get { return "Insert Font"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            FontResourceView res = new FontResourceView(Program.FontIncremental);
            Program.Fonts.Add(Program.FontIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "font" + Program.FontIncremental++.ToString(), Node.Index, true, false, true);
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
        {
            FontResourceView res = new FontResourceView(Program.FontIncremental);
            Program.Fonts.Add(Program.FontIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "font" + Program.FontIncremental++.ToString(), Node.Index + 1, true, false, true);
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
            Program.IDE.AddResource(Node.Parent, new FontGroupResourceView(), null, Node.Index, true, true, false);
        }

        public bool CanSort
        {
            get { return false; }
        }

        public string DragDropFormat { get { return "GameCreatorFontResource"; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorFontResource") && ((IResourceView)data.GetData(typeof(IResourceView))).Node != Node;
        }

        public void DropResource(IDataObject data)
        {
            Program.IDE.MoveResource(Node.Parent, (IResourceView)data.GetData(typeof(IResourceView)), Node.Index);
        }

        public int ResourceID { get { return id; } set { id = value; } }

        #endregion

        #region IDeletable Members

        public void DoDelete(bool removenode)
        {
            if (editor != null && editor.Created)
            {
                editor.Modified = false;
                editor.Close();
            }
            Program.Fonts.Remove(id);
            if (removenode) Node.Remove();
        }

        #endregion
    }
}
