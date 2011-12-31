using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class SpriteResourceView : IResourceView, IDeletable
    {
        string name;
        SpriteEditor editor;
        int id;
        public SpriteResourceView(int index)
        {
            id = index;
        }

        FrameBasedAnimation animation = new FrameBasedAnimation();
        public FrameBasedAnimation Animation { get { return editor != null && editor.Created ? editor.Animation : animation; } set { animation = value; } }

        void editor_Save(object sender, EventArgs e)
        {
            if (animation != null)
                animation.Dispose();
            animation = editor.Animation;
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
            get { return string.Format("sprite{0}", ResourceID); }
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
                editor = new SpriteEditor();
                editor.Animation = animation;
                editor.Save += new EventHandler(editor_Save);
                editor.Text = "Sprite Properties: " + name;
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
            get { return "Insert Sprite"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            SpriteResourceView res = new SpriteResourceView(Program.SpriteIncremental);
            Program.Sprites.Add(Program.SpriteIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "sprite" + Program.SpriteIncremental++.ToString(), Node.Index, true, false, true);
        }

        public bool CanDuplicate
        {
            get { return true; }
        }

        public void Duplicate()
        {
            SpriteResourceView res = new SpriteResourceView(Program.SpriteIncremental);
            Program.Sprites.Add(Program.SpriteIncremental, res);
            Program.IDE.AddResource(Node.Parent, res, "sprite" + Program.SpriteIncremental++.ToString(), Node.Index + 1, true, false, true);
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
            Program.IDE.AddResource(Node.Parent, new SpriteGroupResourceView(), null, Node.Index, true, true, false);
        }

        public bool CanSort
        {
            get { return false; }
        }

        public string DragDropFormat { get { return "GameCreatorSpriteResource"; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorSpriteResource") && ((IResourceView)data.GetData(typeof(IResourceView))).Node != Node;
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
                editor.Saved = true;
                editor.Close();
            }
            Program.Sprites.Remove(id);
            if (removenode) Node.Remove();
        }

        #endregion
    }
}
