using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ScriptResourceView : IResourceView
    {
        string name;
        public string Code = string.Empty;
        ScriptEditor editor;
        DesignerForm parent;
        public ScriptResourceView(DesignerForm parent)
        {
            this.parent = parent;
        }

        void editor_Save(object sender, EventArgs e)
        {
            Code = editor.Code;
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
            get { return "Export Selected Script..."; }
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
            get { return "Script"; }
        }

        public string ExpandedImageKey
        {
            get { return "Script"; }
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
                editor = new ScriptEditor();
                editor.Save += new EventHandler(editor_Save);
                editor.Code = Code;
                editor.Text = "Script Properties: " + name;
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
            get { return "Insert Script"; }
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
            Node.Parent.Nodes.Insert(Node.Index, tn);
            res.Edit();
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
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
            Node.Parent.Nodes.Insert(Node.Index+1, tn);
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
            ScriptGroupResourceView res = new ScriptGroupResourceView(parent);
            TreeNode tn = new TreeNode(res.Name);
            res.Node = tn;
            tn.Name = tn.Text;
            tn.ImageKey = res.ImageKey;
            tn.SelectedImageKey = res.ImageKey;
            tn.Tag = res;
            Node.Parent.Nodes.Insert(Node.Index, tn);
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
