using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.IDE
{
    interface IResourceView
    {
        // The name of the resource
        string Name { get; set; }
        bool CanRename { get; }
        // Event for name change
        event EventHandler NameChanged;
        // Special action such as "Export selected script"
        bool HasSpecialAction { get; }
        string SpecialActionName { get; }
        System.Drawing.Image SpecialActionImage { get; }
        void SpecialAction();
        // Image key for use with tree view (i.e. "Sprite")
        string ImageKey { get; }
        string ExpandedImageKey { get; }
        // Tree node
        System.Windows.Forms.TreeNode Node { get; set; }
        // Edit option
        bool CanEdit { get; }
        void Edit();
        // Delete option
        bool CanDelete { get; }
        void Delete();
        // Insert option
        string InsertString { get; }
        bool CanInsert { get; }
        void Insert();
        // Duplicate option
        bool CanDuplicate { get; }
        void Duplicate();
        // Insert Group option
        string InsertGroupString { get; }
        bool CanInsertGroup { get; }
        void InsertGroup();
        // Sort by name option
        bool CanSort { get; }
        // Drag and drop
        string DragDropFormat { get; }
        bool AcceptsResource(System.Windows.Forms.IDataObject data);
        void DropResource(System.Windows.Forms.IDataObject data);
        // Resource ID
        int ResourceID { get; }
    }
}
