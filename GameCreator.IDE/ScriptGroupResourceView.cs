using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ScriptGroupResourceView : IResourceView
    {
        string name = "new group";
        DesignerForm parent;
        public ScriptGroupResourceView(DesignerForm parent)
        {
            this.parent = parent;
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
            get { return true; }
        }

        public string SpecialActionName
        {
            get { return "Export Group of Scripts..."; }
        }

        public System.Drawing.Image SpecialActionImage
        {
            get { return Properties.Resources.Script; }
        }

        public void SpecialAction()
        {
            throw new NotImplementedException();
        }

        public string ImageKey
        {
            get { return "FolderClosed"; }
        }

        public string ExpandedImageKey
        {
            get { return "FolderOpen"; }
        }

        public System.Windows.Forms.TreeNode Node
        {
            get;
            set;
        }

        public bool CanEdit
        {
            get { return false; }
        }

        public void Edit()
        {
            throw new NotImplementedException();
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
            get { return "Create Script"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            ScriptResourceView res = new ScriptResourceView(parent);
            ScriptsResourceView.scripts.Add(ScriptsResourceView.ids, res);
            res.Name = "script" + ScriptsResourceView.ids++.ToString();
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            Node.Nodes.Add(tn);
            Node.Expand();
            res.Edit();
        }

        public bool CanDuplicate
        {
            get { return false; }
        }

        public void Duplicate()
        {
            throw new NotImplementedException();
        }

        public string InsertGroupString
        {
            get { return "Create Group"; }
        }

        public bool CanInsertGroup
        {
            get { return true; }
        }
        bool ididit = false;
        public void InsertGroup()
        {
            ScriptGroupResourceView res = new ScriptGroupResourceView(parent);
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            Node.Nodes.Add(tn);
            Node.Expand();
            // TODO: ididit
            tn.BeginEdit();
        }

        public bool CanSort
        {
            get { return true; }
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
