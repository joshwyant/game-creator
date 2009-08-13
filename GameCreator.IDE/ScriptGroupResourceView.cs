using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ScriptGroupResourceView : IResourceView, IScriptExportable, IDeletable
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "GML Files|*.gml|All Files|*.*";
            sfd.AddExtension = true;
            sfd.FileName = name;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.TextWriter stream = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.ASCII);
                foreach (TreeNode n in Node.Nodes)
                    ((IScriptExportable)n.Tag).WriteToStream(stream);
                stream.Close();
            }
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
            if (MessageBox.Show(string.Format("Are you sure you want to permanently delete all of the scripts in the group '{0}'?", name), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DoDelete(true);
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
            ScriptResourceView res = new ScriptResourceView(parent, ScriptsResourceView.ids);
            ScriptsResourceView.scripts.Add(ScriptsResourceView.ids, res);
            parent.AddResource(Node, res, "script" + ScriptsResourceView.ids++.ToString(), -1, true, false, true);
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
            parent.AddResource(Node, new ScriptGroupResourceView(parent), null, -1, true, true, false);
        }

        public bool CanSort
        {
            get { return true; }
        }

        #endregion

        #region IScriptExportable Members

        public void WriteToStream(System.IO.TextWriter stream)
        {
            foreach (TreeNode n in Node.Nodes)
                ((IScriptExportable)n.Tag).WriteToStream(stream);
        }

        #endregion

        #region IScriptExportable Members

        void IScriptExportable.WriteToStream(System.IO.TextWriter stream)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDeletable Members

        public void DoDelete(bool removenode)
        {
            foreach (TreeNode n in Node.Nodes)
                ((IDeletable)(n.Tag)).DoDelete(false);
            if (removenode) Node.Remove();
        }

        #endregion
    }
}
