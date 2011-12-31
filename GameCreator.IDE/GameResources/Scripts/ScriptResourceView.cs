using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ScriptResourceView : IResourceView, IScriptExportable, IDeletable
    {
        string name;
        string code = string.Empty;
        int id;
        public string Code {
            get 
            {
                if (editor != null && editor.Created)
                    return editor.Code;
                return code; 
            } 

            set { code = value; } 
        }
        CodeEditor editor;
        public ScriptResourceView(int index)
        {
            id = index;
        }

        void editor_Save(object sender, EventArgs e)
        {
            code = editor.Code;
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
                WriteToStream(stream);
                stream.Close();
            }
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
                editor = new CodeEditor();
                editor.Save += new EventHandler(editor_Save);
                editor.Code = Code;
                editor.Text = "Script Properties: " + name;
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
            get { return "Insert Script"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            ScriptResourceView res = new ScriptResourceView(Program.ScriptIncremental);
            Program.Scripts.Add(Program.ScriptIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "script" + Program.ScriptIncremental++.ToString(), Node.Index, true, true, false);
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
        {
            ScriptResourceView res = new ScriptResourceView(Program.ScriptIncremental);
            res.Code = Code;
            Program.Scripts.Add(Program.ScriptIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "script" + Program.ScriptIncremental++.ToString(), Node.Index + 1, true, false, true);
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
            Program.IDE.AddResource(Node.Parent, new ScriptGroupResourceView(), null, Node.Index, true, true, false);
        }

        public bool CanSort
        {
            get { return false; }
        }

        public string DragDropFormat { get { return "GameCreatorScriptResource"; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorScriptResource") && ((IResourceView)data.GetData(typeof(IResourceView))).Node != Node;
        }

        public void DropResource(IDataObject data)
        {
            Program.IDE.MoveResource(Node.Parent, (IResourceView)data.GetData(typeof(IResourceView)), Node.Index);
        }

        public int ResourceID { get { return id; } set { id = value; } }


        #endregion

        #region IScriptExportable Members

        public void WriteToStream(System.IO.TextWriter stream)
        {
            stream.WriteLine("#define {0}", name);
            stream.WriteLine(Code);
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
            if (removenode) Node.Remove();
            Program.Scripts.Remove(id);
        }

        #endregion
    }
}
