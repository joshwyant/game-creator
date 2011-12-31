namespace GameCreator.IDE
{
    partial class DesignerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.createExecutableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTimeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ResourceImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.resourcesToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(762, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator3,
            this.createExecutableToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.New;
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // createExecutableToolStripMenuItem
            // 
            this.createExecutableToolStripMenuItem.Name = "createExecutableToolStripMenuItem";
            this.createExecutableToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.createExecutableToolStripMenuItem.Text = "Create Executable";
            this.createExecutableToolStripMenuItem.Click += new System.EventHandler(this.createExecutableToolStripMenuItem_Click);
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSpriteToolStripMenuItem,
            this.createSoundToolStripMenuItem,
            this.createBackgroundToolStripMenuItem,
            this.createPathToolStripMenuItem,
            this.createScriptToolStripMenuItem,
            this.createFontToolStripMenuItem,
            this.createDataFileToolStripMenuItem,
            this.createTimeLineToolStripMenuItem,
            this.createObjectToolStripMenuItem,
            this.createRoomToolStripMenuItem});
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.resourcesToolStripMenuItem.Text = "Resources";
            // 
            // createSpriteToolStripMenuItem
            // 
            this.createSpriteToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Sprite;
            this.createSpriteToolStripMenuItem.Name = "createSpriteToolStripMenuItem";
            this.createSpriteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createSpriteToolStripMenuItem.Text = "Create Sprite";
            this.createSpriteToolStripMenuItem.Click += new System.EventHandler(this.createSpriteToolStripMenuItem_Click);
            // 
            // createSoundToolStripMenuItem
            // 
            this.createSoundToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Sound;
            this.createSoundToolStripMenuItem.Name = "createSoundToolStripMenuItem";
            this.createSoundToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createSoundToolStripMenuItem.Text = "Create Sound";
            this.createSoundToolStripMenuItem.Click += new System.EventHandler(this.createSoundToolStripMenuItem_Click);
            // 
            // createBackgroundToolStripMenuItem
            // 
            this.createBackgroundToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Background1;
            this.createBackgroundToolStripMenuItem.Name = "createBackgroundToolStripMenuItem";
            this.createBackgroundToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createBackgroundToolStripMenuItem.Text = "Create Background";
            this.createBackgroundToolStripMenuItem.Click += new System.EventHandler(this.createBackgroundToolStripMenuItem_Click);
            // 
            // createPathToolStripMenuItem
            // 
            this.createPathToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Path;
            this.createPathToolStripMenuItem.Name = "createPathToolStripMenuItem";
            this.createPathToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createPathToolStripMenuItem.Text = "Create Path";
            this.createPathToolStripMenuItem.Click += new System.EventHandler(this.createPathToolStripMenuItem_Click);
            // 
            // createScriptToolStripMenuItem
            // 
            this.createScriptToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Script;
            this.createScriptToolStripMenuItem.Name = "createScriptToolStripMenuItem";
            this.createScriptToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createScriptToolStripMenuItem.Text = "Create Script";
            this.createScriptToolStripMenuItem.Click += new System.EventHandler(this.createScriptToolStripMenuItem_Click);
            // 
            // createFontToolStripMenuItem
            // 
            this.createFontToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Font;
            this.createFontToolStripMenuItem.Name = "createFontToolStripMenuItem";
            this.createFontToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createFontToolStripMenuItem.Text = "Create Font";
            this.createFontToolStripMenuItem.Click += new System.EventHandler(this.createFontToolStripMenuItem_Click);
            // 
            // createDataFileToolStripMenuItem
            // 
            this.createDataFileToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.DataFile;
            this.createDataFileToolStripMenuItem.Name = "createDataFileToolStripMenuItem";
            this.createDataFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createDataFileToolStripMenuItem.Text = "Create Data File";
            this.createDataFileToolStripMenuItem.Click += new System.EventHandler(this.createDataFileToolStripMenuItem_Click);
            // 
            // createTimeLineToolStripMenuItem
            // 
            this.createTimeLineToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.TimeLine;
            this.createTimeLineToolStripMenuItem.Name = "createTimeLineToolStripMenuItem";
            this.createTimeLineToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createTimeLineToolStripMenuItem.Text = "Create Time Line";
            this.createTimeLineToolStripMenuItem.Click += new System.EventHandler(this.createTimeLineToolStripMenuItem_Click);
            // 
            // createObjectToolStripMenuItem
            // 
            this.createObjectToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Cube;
            this.createObjectToolStripMenuItem.Name = "createObjectToolStripMenuItem";
            this.createObjectToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createObjectToolStripMenuItem.Text = "Create Object";
            this.createObjectToolStripMenuItem.Click += new System.EventHandler(this.createObjectToolStripMenuItem_Click);
            // 
            // createRoomToolStripMenuItem
            // 
            this.createRoomToolStripMenuItem.Image = global::GameCreator.IDE.Properties.Resources.Room;
            this.createRoomToolStripMenuItem.Name = "createRoomToolStripMenuItem";
            this.createRoomToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createRoomToolStripMenuItem.Text = "Create Room";
            this.createRoomToolStripMenuItem.Click += new System.EventHandler(this.createRoomToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.arrangeIconsToolStripMenuItem.Text = "Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.arrangeIconsToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton12,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton1,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripButton4,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(762, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = global::GameCreator.IDE.Properties.Resources.New;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "toolStripButton12";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::GameCreator.IDE.Properties.Resources.Run;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Run the game";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::GameCreator.IDE.Properties.Resources.Sprite;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "Create a sprite";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::GameCreator.IDE.Properties.Resources.Sound;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Create a sound";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::GameCreator.IDE.Properties.Resources.Background1;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.ToolTipText = "Create a background";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::GameCreator.IDE.Properties.Resources.Path;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "Create a path";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::GameCreator.IDE.Properties.Resources.Script;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Create a script";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::GameCreator.IDE.Properties.Resources.Font;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.ToolTipText = "Create a font";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::GameCreator.IDE.Properties.Resources.DataFile;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "toolStripButton10";
            this.toolStripButton10.ToolTipText = "Create a data file";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = global::GameCreator.IDE.Properties.Resources.TimeLine;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "toolStripButton11";
            this.toolStripButton11.ToolTipText = "Create a time line";
            this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::GameCreator.IDE.Properties.Resources.Cube;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Create an object";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::GameCreator.IDE.Properties.Resources.Room;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Create a room";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.ResourceImageList;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 49);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(161, 480);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // ResourceImageList
            // 
            this.ResourceImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ResourceImageList.ImageStream")));
            this.ResourceImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ResourceImageList.Images.SetKeyName(0, "Blank");
            this.ResourceImageList.Images.SetKeyName(1, "FolderClosed");
            this.ResourceImageList.Images.SetKeyName(2, "FolderOpen");
            this.ResourceImageList.Images.SetKeyName(3, "Room");
            this.ResourceImageList.Images.SetKeyName(4, "Sprite");
            this.ResourceImageList.Images.SetKeyName(5, "Sound");
            this.ResourceImageList.Images.SetKeyName(6, "Object");
            this.ResourceImageList.Images.SetKeyName(7, "Script");
            this.ResourceImageList.Images.SetKeyName(8, "Background");
            this.ResourceImageList.Images.SetKeyName(9, "Path");
            this.ResourceImageList.Images.SetKeyName(10, "Font");
            this.ResourceImageList.Images.SetKeyName(11, "DataFile");
            this.ResourceImageList.Images.SetKeyName(12, "TimeLine");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(161, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 480);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // DesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameCreator.IDE.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(762, 529);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DesignerForm";
            this.Text = "Game Creator";
            this.Load += new System.EventHandler(this.DesignerForm_Load);
            this.SizeChanged += new System.EventHandler(this.DesignerForm_SizeChanged);
            this.Move += new System.EventHandler(this.DesignerForm_Move);
            this.Resize += new System.EventHandler(this.DesignerForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Splitter splitter1;
        internal System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem createExecutableToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem createObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem createSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem createBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTimeLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        public System.Windows.Forms.ImageList ResourceImageList;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

