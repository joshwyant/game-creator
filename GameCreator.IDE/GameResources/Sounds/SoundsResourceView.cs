using System;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class SoundsResourceView : IResourceView
    {
        public SoundsResourceView() { }
        #region IResourceView Members

        public string Name
        {
            get
            {
                return "Sounds";
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
            get { return "Create Sound"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            SoundResourceView res = new SoundResourceView(Program.SoundIncremental);
            Program.Sounds.Add(Program.SoundIncremental, res);
            Program.IDE.AddResource(Node, res, "sound" + Program.SoundIncremental++.ToString(), -1, true, false, true);
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
            Program.IDE.AddResource(Node, new SoundGroupResourceView(), null, -1, true, true, false);
        }

        public bool CanSort
        {
            get { return true; }
        }

        public string DragDropFormat { get { return null; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorSoundResource");
        }

        public void DropResource(IDataObject data)
        {
            Program.IDE.MoveResource(Node, (IResourceView)data.GetData(typeof(IResourceView)), -1);
        }

        public int ResourceID { get { throw new InvalidOperationException(); } }

        #endregion
    }
}
