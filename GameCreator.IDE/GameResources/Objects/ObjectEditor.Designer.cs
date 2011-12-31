namespace GameCreator.IDE
{
    partial class ObjectEditor
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resourceSelector3 = new GameCreator.IDE.GameResources.ResourceSelector();
            this.resourceSelector2 = new GameCreator.IDE.GameResources.ResourceSelector();
            this.button8 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxPersistent = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxSolid = new System.Windows.Forms.CheckBox();
            this.checkBoxVisible = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resourceSelector1 = new GameCreator.IDE.GameResources.ResourceSelector();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.New = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.actionPanel1 = new GameCreator.IDE.ActionPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Image = global::GameCreator.IDE.Properties.Resources.OK;
            this.button1.Location = new System.Drawing.Point(56, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.resourceSelector3);
            this.panel1.Controls.Add(this.resourceSelector2);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.checkBoxPersistent);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxSolid);
            this.panel1.Controls.Add(this.checkBoxVisible);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 364);
            this.panel1.TabIndex = 6;
            // 
            // resourceSelector3
            // 
            this.resourceSelector3.DefaultText = "<same as sprite>";
            this.resourceSelector3.Location = new System.Drawing.Point(48, 218);
            this.resourceSelector3.Name = "resourceSelector3";
            this.resourceSelector3.SelectedResource = null;
            this.resourceSelector3.Size = new System.Drawing.Size(124, 23);
            this.resourceSelector3.TabIndex = 14;
            this.resourceSelector3.TopResource = null;
            this.resourceSelector3.SelectedResourceChanged += new System.EventHandler(this.resourceSelector3_SelectedResourceChanged);
            // 
            // resourceSelector2
            // 
            this.resourceSelector2.DefaultText = "<no parent>";
            this.resourceSelector2.Location = new System.Drawing.Point(48, 191);
            this.resourceSelector2.Name = "resourceSelector2";
            this.resourceSelector2.SelectedResource = null;
            this.resourceSelector2.Size = new System.Drawing.Size(124, 23);
            this.resourceSelector2.TabIndex = 13;
            this.resourceSelector2.TopResource = null;
            this.resourceSelector2.SelectedResourceChanged += new System.EventHandler(this.resourceSelector2_SelectedResourceChanged);
            // 
            // button8
            // 
            this.button8.Image = global::GameCreator.IDE.Properties.Resources.Info;
            this.button8.Location = new System.Drawing.Point(22, 247);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(132, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Show Information";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mask:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Parent:";
            // 
            // checkBoxPersistent
            // 
            this.checkBoxPersistent.AutoSize = true;
            this.checkBoxPersistent.Location = new System.Drawing.Point(48, 168);
            this.checkBoxPersistent.Name = "checkBoxPersistent";
            this.checkBoxPersistent.Size = new System.Drawing.Size(72, 17);
            this.checkBoxPersistent.TabIndex = 9;
            this.checkBoxPersistent.Text = "Persistent";
            this.checkBoxPersistent.UseVisualStyleBackColor = true;
            this.checkBoxPersistent.CheckedChanged += new System.EventHandler(this.checkBoxPersistent_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Depth:";
            // 
            // checkBoxSolid
            // 
            this.checkBoxSolid.AutoSize = true;
            this.checkBoxSolid.Location = new System.Drawing.Point(81, 118);
            this.checkBoxSolid.Name = "checkBoxSolid";
            this.checkBoxSolid.Size = new System.Drawing.Size(49, 17);
            this.checkBoxSolid.TabIndex = 6;
            this.checkBoxSolid.Text = "Solid";
            this.checkBoxSolid.UseVisualStyleBackColor = true;
            this.checkBoxSolid.CheckedChanged += new System.EventHandler(this.checkBoxSolid_CheckedChanged);
            // 
            // checkBoxVisible
            // 
            this.checkBoxVisible.AutoSize = true;
            this.checkBoxVisible.Location = new System.Drawing.Point(6, 118);
            this.checkBoxVisible.Name = "checkBoxVisible";
            this.checkBoxVisible.Size = new System.Drawing.Size(56, 17);
            this.checkBoxVisible.TabIndex = 5;
            this.checkBoxVisible.Text = "Visible";
            this.checkBoxVisible.UseVisualStyleBackColor = true;
            this.checkBoxVisible.CheckedChanged += new System.EventHandler(this.checkBoxVisible_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resourceSelector1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.New);
            this.groupBox1.Location = new System.Drawing.Point(6, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 82);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sprite";
            // 
            // resourceSelector1
            // 
            this.resourceSelector1.DefaultText = "<no sprite>";
            this.resourceSelector1.Location = new System.Drawing.Point(28, 19);
            this.resourceSelector1.Name = "resourceSelector1";
            this.resourceSelector1.SelectedResource = null;
            this.resourceSelector1.Size = new System.Drawing.Size(133, 26);
            this.resourceSelector1.TabIndex = 8;
            this.resourceSelector1.TopResource = null;
            this.resourceSelector1.SelectedResourceChanged += new System.EventHandler(this.resourceSelector1_SelectedResourceChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // New
            // 
            this.New.Location = new System.Drawing.Point(28, 51);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(48, 20);
            this.New.TabIndex = 5;
            this.New.Text = "New";
            this.New.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(47, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(125, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.actionPanel1);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.listBox2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(180, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(492, 364);
            this.panel3.TabIndex = 7;
            // 
            // actionPanel1
            // 
            this.actionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionPanel1.Location = new System.Drawing.Point(150, 0);
            this.actionPanel1.Name = "actionPanel1";
            this.actionPanel1.Size = new System.Drawing.Size(338, 360);
            this.actionPanel1.TabIndex = 12;
            this.actionPanel1.ActionDrop += new System.EventHandler(this.actionPanel1_ActionDrop);
            this.actionPanel1.BeforeActionDrop += new System.ComponentModel.CancelEventHandler(this.actionPanel1_BeforeActionDrop);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(77, 331);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Change";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(7, 331);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(7, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Add Event";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.IntegralHeight = false;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(7, 24);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(137, 272);
            this.listBox2.TabIndex = 8;
            this.listBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Events:";
            // 
            // ObjectEditor
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 364);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "ObjectEditor";
            this.Text = "Object Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ObjectEditor_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private ActionPanel actionPanel1;
        private System.Windows.Forms.CheckBox checkBoxVisible;
        private System.Windows.Forms.CheckBox checkBoxPersistent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxSolid;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GameCreator.IDE.GameResources.ResourceSelector resourceSelector1;
        private GameCreator.IDE.GameResources.ResourceSelector resourceSelector2;
        private GameCreator.IDE.GameResources.ResourceSelector resourceSelector3;
    }
}