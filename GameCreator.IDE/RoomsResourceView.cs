using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class RoomsResourceView : IResourceView
    {
        public static long ids = 0;
        public static Dictionary<long, RoomResourceView> rooms = new Dictionary<long, RoomResourceView>();
        DesignerForm parent;
        public RoomsResourceView(DesignerForm parent)
        {
            this.parent = parent;
        }
        #region IResourceView Members

        public string Name
        {
            get
            {
                return "Rooms";
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
            get { return "Create Room"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            RoomResourceView res = new RoomResourceView(parent, RoomsResourceView.ids);
            rooms.Add(ids, res);
            parent.AddResource(Node, res, "room" + ids++.ToString(), -1, true, false, true);
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
            parent.AddResource(Node, new RoomGroupResourceView(parent), null, -1, true, true, false);
        }

        public bool CanSort
        {
            get { return true; }
        }

        #endregion
    }
}
