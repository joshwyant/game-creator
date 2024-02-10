using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class ObjectResourceView : IResourceView, IDeletable
    {
        string name;
        public IEnumerable<ObjectEvent> Events
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.ObjectEvents;
                return events;
            }
            set { events = new List<ObjectEvent>(value); }
        }
        public List<ObjectEvent> events = new List<ObjectEvent>();
        bool visible, solid, persistent;
        int sprite = -1;
        public int Sprite
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.Sprite == null ? -1 : editor.Sprite.ResourceID;
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }
        public bool Visible
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.VisibleChecked;
                return visible;
            }
            set
            {
                visible = value;
            }
        }
        public bool Solid
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.SolidChecked;
                return solid;
            }
            set
            {
                solid = value;
            }
        }
        public bool Persistent
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.PersistentChecked;
                return persistent;
            }
            set
            {
                persistent = value;
            }
        }
        double depth;
        public double Depth
        {
            get
            {
                if (editor != null && editor.Created)
                    return editor.Depth;
                return depth;
            }
            set
            {
                depth = value;
            }
        }
        ObjectEditor editor;
        int id;
        public ObjectResourceView(int index)
        {
            id = index;
            visible = true;
            solid = false;
            persistent = false;
            depth = 0;
        }

        void editor_Save(object sender, EventArgs e)
        {
            events = new List<ObjectEvent>(editor.ObjectEvents);
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Actions.Count == 0)
                    events.RemoveAt(i--); // i-- since we are modifying the list while iterating through it
            }
            visible = editor.VisibleChecked;
            solid = editor.SolidChecked;
            persistent = editor.PersistentChecked;
            depth = editor.Depth;
            Name = editor.ObjectName;
            sprite = editor.Sprite == null ? -1 : editor.Sprite.ResourceID;
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
                if (Node != null) Node.Text = Node.Name = value;
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
            get { return null; }
        }

        public string ExpandedImageKey
        {
            get { return null; }
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
                editor = new ObjectEditor(this);
                editor.ObjectEvents = Events;
                editor.VisibleChecked = visible;
                editor.SolidChecked = solid;
                editor.PersistentChecked = persistent;
                editor.ObjectName = name;
                editor.Depth = depth;
                editor.Text = "Object Properties: " + name;
                editor.MdiParent = Program.IDE;
                editor.Saved = true;
                SpriteResourceView r = null;
                Program.Sprites.TryGetValue(sprite, out r);
                editor.Sprite = r;
                editor.Save += new EventHandler(editor_Save);
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
            get { return "Insert Object"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            ObjectResourceView res = new ObjectResourceView(Program.ObjectIncremental);
            Program.Objects.Add(Program.ObjectIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "object" + Program.ObjectIncremental++.ToString(), Node.Index, true, false, true);
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
        {
            ObjectResourceView res = new ObjectResourceView(Program.ObjectIncremental);
            Program.Objects.Add(Program.ObjectIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "object" + Program.ObjectIncremental++.ToString(), Node.Index + 1, true, false, true);
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
            Program.IDE.AddResource(Node.Parent, new ObjectGroupResourceView(), null, Node.Index, true, true, false);
        }

        public bool CanSort
        {
            get { return false; }
        }

        public string DragDropFormat { get { return "GameCreatorObjectResource"; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorObjectResource") && ((IResourceView)data.GetData(typeof(IResourceView))).Node != Node;
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
                editor.Saved = true; // to force close without save messages
                editor.Close();
            }
            Program.Objects.Remove(id);
            if (removenode) Node.Remove();
        }

        #endregion
    }
}
