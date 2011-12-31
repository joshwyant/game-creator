using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ScriptsResourceView : IResourceView
    {
        public ScriptsResourceView() { }
        #region IResourceView Members

        public string Name
        {
            get
            {
                return "Scripts";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CanRename
        {
            get { return false; }
        }

        public event EventHandler NameChanged;

        public bool HasSpecialAction
        {
            get { return true; }
        }

        public string SpecialActionName
        {
            get { return "Export All Scripts..."; }
        }

        public System.Drawing.Image SpecialActionImage
        {
            get { return Properties.Resources.ExportScript; }
        }

        public void SpecialAction()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "GML Files|*.gml|All Files|*.*";
            sfd.AddExtension = true;
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
            get { return false; }
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
            ScriptResourceView res = new ScriptResourceView(Program.ScriptIncremental);
            Program.Scripts.Add(Program.ScriptIncremental, res);
            Program.IDE.AddResource(Node, res, "script" + Program.ScriptIncremental++.ToString(), -1, true, false, true);
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

        public void InsertGroup()
        {
            Program.IDE.AddResource(Node, new ScriptGroupResourceView(), null, -1, true, true, false);
        }

        public bool CanSort
        {
            get { return true; }
        }

        public string DragDropFormat { get { return null; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorScriptResource");
        }

        public void DropResource(IDataObject data)
        {
            Program.IDE.MoveResource(Node, (IResourceView)data.GetData(typeof(IResourceView)), -1);
        }

        public int ResourceID { get { throw new InvalidOperationException(); } }

        #endregion
    }
}
