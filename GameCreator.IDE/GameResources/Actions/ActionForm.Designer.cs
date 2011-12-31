namespace GameCreator.IDE
{
    partial class ActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionForm));
            this.pictureBoxAction = new System.Windows.Forms.PictureBox();
            this.groupBoxAppliesTo = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonObject = new System.Windows.Forms.RadioButton();
            this.radioButtonOther = new System.Windows.Forms.RadioButton();
            this.radioButtonSelf = new System.Windows.Forms.RadioButton();
            this.panelNormal = new System.Windows.Forms.Panel();
            this.checkBoxRelative = new System.Windows.Forms.CheckBox();
            this.checkBoxNot = new System.Windows.Forms.CheckBox();
            this.labelArg6 = new System.Windows.Forms.Label();
            this.textBoxArg6 = new System.Windows.Forms.TextBox();
            this.buttonArg6 = new System.Windows.Forms.Button();
            this.labelArg5 = new System.Windows.Forms.Label();
            this.textBoxArg5 = new System.Windows.Forms.TextBox();
            this.buttonArg5 = new System.Windows.Forms.Button();
            this.labelArg4 = new System.Windows.Forms.Label();
            this.textBoxArg4 = new System.Windows.Forms.TextBox();
            this.buttonArg4 = new System.Windows.Forms.Button();
            this.labelArg3 = new System.Windows.Forms.Label();
            this.textBoxArg3 = new System.Windows.Forms.TextBox();
            this.buttonArg3 = new System.Windows.Forms.Button();
            this.labelArg2 = new System.Windows.Forms.Label();
            this.textBoxArg2 = new System.Windows.Forms.TextBox();
            this.buttonArg2 = new System.Windows.Forms.Button();
            this.labelArg1 = new System.Windows.Forms.Label();
            this.textBoxArg1 = new System.Windows.Forms.TextBox();
            this.buttonArg1 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelArrows = new System.Windows.Forms.Panel();
            this.checkBoxSW = new System.Windows.Forms.CheckBox();
            this.checkBoxS = new System.Windows.Forms.CheckBox();
            this.checkBoxSE = new System.Windows.Forms.CheckBox();
            this.checkBoxW = new System.Windows.Forms.CheckBox();
            this.checkBoxStop = new System.Windows.Forms.CheckBox();
            this.checkBoxE = new System.Windows.Forms.CheckBox();
            this.checkBoxNW = new System.Windows.Forms.CheckBox();
            this.checkBoxN = new System.Windows.Forms.CheckBox();
            this.checkBoxNE = new System.Windows.Forms.CheckBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelDirections = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.checkBoxArrowsRelative = new System.Windows.Forms.CheckBox();
            this.checkBoxArrowsNot = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAction)).BeginInit();
            this.groupBoxAppliesTo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelNormal.SuspendLayout();
            this.panelArrows.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxAction
            // 
            this.pictureBoxAction.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAction.Location = new System.Drawing.Point(12, 21);
            this.pictureBoxAction.Name = "pictureBoxAction";
            this.pictureBoxAction.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxAction.TabIndex = 0;
            this.pictureBoxAction.TabStop = false;
            // 
            // groupBoxAppliesTo
            // 
            this.groupBoxAppliesTo.Controls.Add(this.button1);
            this.groupBoxAppliesTo.Controls.Add(this.panel1);
            this.groupBoxAppliesTo.Controls.Add(this.radioButtonObject);
            this.groupBoxAppliesTo.Controls.Add(this.radioButtonOther);
            this.groupBoxAppliesTo.Controls.Add(this.radioButtonSelf);
            this.groupBoxAppliesTo.Location = new System.Drawing.Point(51, 12);
            this.groupBoxAppliesTo.Name = "groupBoxAppliesTo";
            this.groupBoxAppliesTo.Size = new System.Drawing.Size(219, 80);
            this.groupBoxAppliesTo.TabIndex = 2;
            this.groupBoxAppliesTo.TabStop = false;
            this.groupBoxAppliesTo.Text = "Applies to";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Image = global::GameCreator.IDE.Properties.Resources.Cursor;
            this.button1.Location = new System.Drawing.Point(191, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 22);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(68, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 22);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radioButtonObject
            // 
            this.radioButtonObject.AutoSize = true;
            this.radioButtonObject.Location = new System.Drawing.Point(6, 53);
            this.radioButtonObject.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonObject.Name = "radioButtonObject";
            this.radioButtonObject.Size = new System.Drawing.Size(59, 17);
            this.radioButtonObject.TabIndex = 2;
            this.radioButtonObject.TabStop = true;
            this.radioButtonObject.Text = "Object:";
            this.radioButtonObject.UseVisualStyleBackColor = true;
            this.radioButtonObject.CheckedChanged += new System.EventHandler(this.radioButtonObject_CheckedChanged);
            // 
            // radioButtonOther
            // 
            this.radioButtonOther.AutoSize = true;
            this.radioButtonOther.Location = new System.Drawing.Point(6, 36);
            this.radioButtonOther.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonOther.Name = "radioButtonOther";
            this.radioButtonOther.Size = new System.Drawing.Size(51, 17);
            this.radioButtonOther.TabIndex = 1;
            this.radioButtonOther.TabStop = true;
            this.radioButtonOther.Text = "Other";
            this.radioButtonOther.UseVisualStyleBackColor = true;
            this.radioButtonOther.CheckedChanged += new System.EventHandler(this.radioButtonOther_CheckedChanged);
            // 
            // radioButtonSelf
            // 
            this.radioButtonSelf.AutoSize = true;
            this.radioButtonSelf.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSelf.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonSelf.Name = "radioButtonSelf";
            this.radioButtonSelf.Size = new System.Drawing.Size(43, 17);
            this.radioButtonSelf.TabIndex = 0;
            this.radioButtonSelf.TabStop = true;
            this.radioButtonSelf.Tag = "";
            this.radioButtonSelf.Text = "Self";
            this.radioButtonSelf.UseVisualStyleBackColor = true;
            this.radioButtonSelf.CheckedChanged += new System.EventHandler(this.radioButtonSelf_CheckedChanged);
            // 
            // panelNormal
            // 
            this.panelNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNormal.Controls.Add(this.checkBoxRelative);
            this.panelNormal.Controls.Add(this.checkBoxNot);
            this.panelNormal.Controls.Add(this.labelArg6);
            this.panelNormal.Controls.Add(this.textBoxArg6);
            this.panelNormal.Controls.Add(this.buttonArg6);
            this.panelNormal.Controls.Add(this.labelArg5);
            this.panelNormal.Controls.Add(this.textBoxArg5);
            this.panelNormal.Controls.Add(this.buttonArg5);
            this.panelNormal.Controls.Add(this.labelArg4);
            this.panelNormal.Controls.Add(this.textBoxArg4);
            this.panelNormal.Controls.Add(this.buttonArg4);
            this.panelNormal.Controls.Add(this.labelArg3);
            this.panelNormal.Controls.Add(this.textBoxArg3);
            this.panelNormal.Controls.Add(this.buttonArg3);
            this.panelNormal.Controls.Add(this.labelArg2);
            this.panelNormal.Controls.Add(this.textBoxArg2);
            this.panelNormal.Controls.Add(this.buttonArg2);
            this.panelNormal.Controls.Add(this.labelArg1);
            this.panelNormal.Controls.Add(this.textBoxArg1);
            this.panelNormal.Controls.Add(this.buttonArg1);
            this.panelNormal.Location = new System.Drawing.Point(12, 98);
            this.panelNormal.Name = "panelNormal";
            this.panelNormal.Size = new System.Drawing.Size(258, 174);
            this.panelNormal.TabIndex = 0;
            // 
            // checkBoxRelative
            // 
            this.checkBoxRelative.AutoSize = true;
            this.checkBoxRelative.Location = new System.Drawing.Point(131, 155);
            this.checkBoxRelative.Name = "checkBoxRelative";
            this.checkBoxRelative.Size = new System.Drawing.Size(65, 17);
            this.checkBoxRelative.TabIndex = 12;
            this.checkBoxRelative.Text = "Relative";
            this.checkBoxRelative.UseVisualStyleBackColor = true;
            this.checkBoxRelative.CheckedChanged += new System.EventHandler(this.checkBoxRelative_CheckedChanged);
            // 
            // checkBoxNot
            // 
            this.checkBoxNot.AutoSize = true;
            this.checkBoxNot.Location = new System.Drawing.Point(202, 155);
            this.checkBoxNot.Name = "checkBoxNot";
            this.checkBoxNot.Size = new System.Drawing.Size(49, 17);
            this.checkBoxNot.TabIndex = 13;
            this.checkBoxNot.Text = "NOT";
            this.checkBoxNot.UseVisualStyleBackColor = true;
            this.checkBoxNot.CheckedChanged += new System.EventHandler(this.checkBoxNot_CheckedChanged);
            // 
            // labelArg6
            // 
            this.labelArg6.Location = new System.Drawing.Point(3, 123);
            this.labelArg6.Margin = new System.Windows.Forms.Padding(0);
            this.labelArg6.Name = "labelArg6";
            this.labelArg6.Size = new System.Drawing.Size(82, 19);
            this.labelArg6.TabIndex = 22;
            this.labelArg6.Text = "arg:";
            this.labelArg6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArg6
            // 
            this.textBoxArg6.Location = new System.Drawing.Point(88, 123);
            this.textBoxArg6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxArg6.Name = "textBoxArg6";
            this.textBoxArg6.Size = new System.Drawing.Size(137, 20);
            this.textBoxArg6.TabIndex = 10;
            this.textBoxArg6.TextChanged += new System.EventHandler(this.textBoxArg_TextChanged);
            // 
            // buttonArg6
            // 
            this.buttonArg6.Image = ((System.Drawing.Image)(resources.GetObject("buttonArg6.Image")));
            this.buttonArg6.Location = new System.Drawing.Point(229, 123);
            this.buttonArg6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonArg6.Name = "buttonArg6";
            this.buttonArg6.Size = new System.Drawing.Size(22, 22);
            this.buttonArg6.TabIndex = 11;
            this.buttonArg6.UseVisualStyleBackColor = true;
            // 
            // labelArg5
            // 
            this.labelArg5.Location = new System.Drawing.Point(3, 99);
            this.labelArg5.Margin = new System.Windows.Forms.Padding(0);
            this.labelArg5.Name = "labelArg5";
            this.labelArg5.Size = new System.Drawing.Size(82, 19);
            this.labelArg5.TabIndex = 19;
            this.labelArg5.Text = "arg:";
            this.labelArg5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArg5
            // 
            this.textBoxArg5.Location = new System.Drawing.Point(88, 99);
            this.textBoxArg5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxArg5.Name = "textBoxArg5";
            this.textBoxArg5.Size = new System.Drawing.Size(137, 20);
            this.textBoxArg5.TabIndex = 8;
            this.textBoxArg5.TextChanged += new System.EventHandler(this.textBoxArg_TextChanged);
            // 
            // buttonArg5
            // 
            this.buttonArg5.Image = ((System.Drawing.Image)(resources.GetObject("buttonArg5.Image")));
            this.buttonArg5.Location = new System.Drawing.Point(229, 99);
            this.buttonArg5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonArg5.Name = "buttonArg5";
            this.buttonArg5.Size = new System.Drawing.Size(22, 22);
            this.buttonArg5.TabIndex = 9;
            this.buttonArg5.UseVisualStyleBackColor = true;
            // 
            // labelArg4
            // 
            this.labelArg4.Location = new System.Drawing.Point(3, 75);
            this.labelArg4.Margin = new System.Windows.Forms.Padding(0);
            this.labelArg4.Name = "labelArg4";
            this.labelArg4.Size = new System.Drawing.Size(82, 19);
            this.labelArg4.TabIndex = 16;
            this.labelArg4.Text = "arg:";
            this.labelArg4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArg4
            // 
            this.textBoxArg4.Location = new System.Drawing.Point(88, 75);
            this.textBoxArg4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxArg4.Name = "textBoxArg4";
            this.textBoxArg4.Size = new System.Drawing.Size(137, 20);
            this.textBoxArg4.TabIndex = 6;
            this.textBoxArg4.TextChanged += new System.EventHandler(this.textBoxArg_TextChanged);
            // 
            // buttonArg4
            // 
            this.buttonArg4.Image = ((System.Drawing.Image)(resources.GetObject("buttonArg4.Image")));
            this.buttonArg4.Location = new System.Drawing.Point(229, 75);
            this.buttonArg4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonArg4.Name = "buttonArg4";
            this.buttonArg4.Size = new System.Drawing.Size(22, 22);
            this.buttonArg4.TabIndex = 7;
            this.buttonArg4.UseVisualStyleBackColor = true;
            // 
            // labelArg3
            // 
            this.labelArg3.Location = new System.Drawing.Point(3, 51);
            this.labelArg3.Margin = new System.Windows.Forms.Padding(0);
            this.labelArg3.Name = "labelArg3";
            this.labelArg3.Size = new System.Drawing.Size(82, 19);
            this.labelArg3.TabIndex = 13;
            this.labelArg3.Text = "arg:";
            this.labelArg3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArg3
            // 
            this.textBoxArg3.Location = new System.Drawing.Point(88, 51);
            this.textBoxArg3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxArg3.Name = "textBoxArg3";
            this.textBoxArg3.Size = new System.Drawing.Size(137, 20);
            this.textBoxArg3.TabIndex = 4;
            this.textBoxArg3.TextChanged += new System.EventHandler(this.textBoxArg_TextChanged);
            // 
            // buttonArg3
            // 
            this.buttonArg3.Image = ((System.Drawing.Image)(resources.GetObject("buttonArg3.Image")));
            this.buttonArg3.Location = new System.Drawing.Point(229, 51);
            this.buttonArg3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonArg3.Name = "buttonArg3";
            this.buttonArg3.Size = new System.Drawing.Size(22, 22);
            this.buttonArg3.TabIndex = 5;
            this.buttonArg3.UseVisualStyleBackColor = true;
            // 
            // labelArg2
            // 
            this.labelArg2.Location = new System.Drawing.Point(3, 27);
            this.labelArg2.Margin = new System.Windows.Forms.Padding(0);
            this.labelArg2.Name = "labelArg2";
            this.labelArg2.Size = new System.Drawing.Size(82, 19);
            this.labelArg2.TabIndex = 10;
            this.labelArg2.Text = "arg:";
            this.labelArg2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArg2
            // 
            this.textBoxArg2.Location = new System.Drawing.Point(88, 27);
            this.textBoxArg2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxArg2.Name = "textBoxArg2";
            this.textBoxArg2.Size = new System.Drawing.Size(137, 20);
            this.textBoxArg2.TabIndex = 2;
            this.textBoxArg2.TextChanged += new System.EventHandler(this.textBoxArg_TextChanged);
            // 
            // buttonArg2
            // 
            this.buttonArg2.Image = ((System.Drawing.Image)(resources.GetObject("buttonArg2.Image")));
            this.buttonArg2.Location = new System.Drawing.Point(229, 27);
            this.buttonArg2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonArg2.Name = "buttonArg2";
            this.buttonArg2.Size = new System.Drawing.Size(22, 22);
            this.buttonArg2.TabIndex = 3;
            this.buttonArg2.UseVisualStyleBackColor = true;
            // 
            // labelArg1
            // 
            this.labelArg1.Location = new System.Drawing.Point(3, 3);
            this.labelArg1.Margin = new System.Windows.Forms.Padding(0);
            this.labelArg1.Name = "labelArg1";
            this.labelArg1.Size = new System.Drawing.Size(82, 19);
            this.labelArg1.TabIndex = 5;
            this.labelArg1.Text = "arg:";
            this.labelArg1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxArg1
            // 
            this.textBoxArg1.Location = new System.Drawing.Point(88, 3);
            this.textBoxArg1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxArg1.Name = "textBoxArg1";
            this.textBoxArg1.Size = new System.Drawing.Size(137, 20);
            this.textBoxArg1.TabIndex = 0;
            this.textBoxArg1.TextChanged += new System.EventHandler(this.textBoxArg_TextChanged);
            // 
            // buttonArg1
            // 
            this.buttonArg1.Image = ((System.Drawing.Image)(resources.GetObject("buttonArg1.Image")));
            this.buttonArg1.Location = new System.Drawing.Point(229, 3);
            this.buttonArg1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonArg1.Name = "buttonArg1";
            this.buttonArg1.Size = new System.Drawing.Size(22, 22);
            this.buttonArg1.TabIndex = 1;
            this.buttonArg1.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Image = global::GameCreator.IDE.Properties.Resources.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 278);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::GameCreator.IDE.Properties.Resources.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(195, 278);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelArrows
            // 
            this.panelArrows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelArrows.Controls.Add(this.checkBoxSW);
            this.panelArrows.Controls.Add(this.checkBoxS);
            this.panelArrows.Controls.Add(this.checkBoxSE);
            this.panelArrows.Controls.Add(this.checkBoxW);
            this.panelArrows.Controls.Add(this.checkBoxStop);
            this.panelArrows.Controls.Add(this.checkBoxE);
            this.panelArrows.Controls.Add(this.checkBoxNW);
            this.panelArrows.Controls.Add(this.checkBoxN);
            this.panelArrows.Controls.Add(this.checkBoxNE);
            this.panelArrows.Controls.Add(this.labelSpeed);
            this.panelArrows.Controls.Add(this.labelDirections);
            this.panelArrows.Controls.Add(this.textBoxSpeed);
            this.panelArrows.Controls.Add(this.checkBoxArrowsRelative);
            this.panelArrows.Controls.Add(this.checkBoxArrowsNot);
            this.panelArrows.Location = new System.Drawing.Point(12, 98);
            this.panelArrows.Name = "panelArrows";
            this.panelArrows.Size = new System.Drawing.Size(258, 174);
            this.panelArrows.TabIndex = 1;
            // 
            // checkBoxSW
            // 
            this.checkBoxSW.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSW.Image = global::GameCreator.IDE.Properties.Resources.DirSW;
            this.checkBoxSW.Location = new System.Drawing.Point(80, 70);
            this.checkBoxSW.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSW.Name = "checkBoxSW";
            this.checkBoxSW.Size = new System.Drawing.Size(26, 26);
            this.checkBoxSW.TabIndex = 7;
            this.checkBoxSW.UseVisualStyleBackColor = true;
            this.checkBoxSW.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxS
            // 
            this.checkBoxS.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxS.Image = global::GameCreator.IDE.Properties.Resources.DirS;
            this.checkBoxS.Location = new System.Drawing.Point(106, 70);
            this.checkBoxS.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxS.Name = "checkBoxS";
            this.checkBoxS.Size = new System.Drawing.Size(26, 26);
            this.checkBoxS.TabIndex = 8;
            this.checkBoxS.UseVisualStyleBackColor = true;
            this.checkBoxS.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxSE
            // 
            this.checkBoxSE.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSE.Image = global::GameCreator.IDE.Properties.Resources.DirSE;
            this.checkBoxSE.Location = new System.Drawing.Point(132, 70);
            this.checkBoxSE.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSE.Name = "checkBoxSE";
            this.checkBoxSE.Size = new System.Drawing.Size(26, 26);
            this.checkBoxSE.TabIndex = 9;
            this.checkBoxSE.UseVisualStyleBackColor = true;
            this.checkBoxSE.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxW
            // 
            this.checkBoxW.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxW.Image = global::GameCreator.IDE.Properties.Resources.DirW;
            this.checkBoxW.Location = new System.Drawing.Point(80, 44);
            this.checkBoxW.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxW.Name = "checkBoxW";
            this.checkBoxW.Size = new System.Drawing.Size(26, 26);
            this.checkBoxW.TabIndex = 4;
            this.checkBoxW.UseVisualStyleBackColor = true;
            this.checkBoxW.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxStop
            // 
            this.checkBoxStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxStop.Image = global::GameCreator.IDE.Properties.Resources.DirStop;
            this.checkBoxStop.Location = new System.Drawing.Point(106, 44);
            this.checkBoxStop.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxStop.Name = "checkBoxStop";
            this.checkBoxStop.Size = new System.Drawing.Size(26, 26);
            this.checkBoxStop.TabIndex = 5;
            this.checkBoxStop.UseVisualStyleBackColor = true;
            this.checkBoxStop.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxE
            // 
            this.checkBoxE.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxE.Image = global::GameCreator.IDE.Properties.Resources.DirE;
            this.checkBoxE.Location = new System.Drawing.Point(132, 44);
            this.checkBoxE.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxE.Name = "checkBoxE";
            this.checkBoxE.Size = new System.Drawing.Size(26, 26);
            this.checkBoxE.TabIndex = 6;
            this.checkBoxE.UseVisualStyleBackColor = true;
            this.checkBoxE.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxNW
            // 
            this.checkBoxNW.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxNW.Image = global::GameCreator.IDE.Properties.Resources.DirNW;
            this.checkBoxNW.Location = new System.Drawing.Point(80, 18);
            this.checkBoxNW.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxNW.Name = "checkBoxNW";
            this.checkBoxNW.Size = new System.Drawing.Size(26, 26);
            this.checkBoxNW.TabIndex = 1;
            this.checkBoxNW.UseVisualStyleBackColor = true;
            this.checkBoxNW.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxN
            // 
            this.checkBoxN.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxN.Image = global::GameCreator.IDE.Properties.Resources.DirN;
            this.checkBoxN.Location = new System.Drawing.Point(106, 18);
            this.checkBoxN.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxN.Name = "checkBoxN";
            this.checkBoxN.Size = new System.Drawing.Size(26, 26);
            this.checkBoxN.TabIndex = 2;
            this.checkBoxN.UseVisualStyleBackColor = true;
            this.checkBoxN.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // checkBoxNE
            // 
            this.checkBoxNE.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxNE.Image = global::GameCreator.IDE.Properties.Resources.DirNE;
            this.checkBoxNE.Location = new System.Drawing.Point(132, 18);
            this.checkBoxNE.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxNE.Name = "checkBoxNE";
            this.checkBoxNE.Size = new System.Drawing.Size(26, 26);
            this.checkBoxNE.TabIndex = 3;
            this.checkBoxNE.UseVisualStyleBackColor = true;
            this.checkBoxNE.CheckedChanged += new System.EventHandler(this.arrows_CheckedChanged);
            // 
            // labelSpeed
            // 
            this.labelSpeed.Location = new System.Drawing.Point(6, 103);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(68, 26);
            this.labelSpeed.TabIndex = 36;
            this.labelSpeed.Text = "Speed:";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDirections
            // 
            this.labelDirections.Location = new System.Drawing.Point(6, 44);
            this.labelDirections.Name = "labelDirections";
            this.labelDirections.Size = new System.Drawing.Size(68, 26);
            this.labelDirections.TabIndex = 35;
            this.labelDirections.Text = "Directions:";
            this.labelDirections.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(80, 107);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(145, 20);
            this.textBoxSpeed.TabIndex = 0;
            this.textBoxSpeed.TextChanged += new System.EventHandler(this.textBoxSpeed_TextChanged);
            // 
            // checkBoxArrowsRelative
            // 
            this.checkBoxArrowsRelative.AutoSize = true;
            this.checkBoxArrowsRelative.Location = new System.Drawing.Point(131, 155);
            this.checkBoxArrowsRelative.Name = "checkBoxArrowsRelative";
            this.checkBoxArrowsRelative.Size = new System.Drawing.Size(65, 17);
            this.checkBoxArrowsRelative.TabIndex = 10;
            this.checkBoxArrowsRelative.Text = "Relative";
            this.checkBoxArrowsRelative.UseVisualStyleBackColor = true;
            this.checkBoxArrowsRelative.CheckedChanged += new System.EventHandler(this.checkBoxRelative_CheckedChanged);
            // 
            // checkBoxArrowsNot
            // 
            this.checkBoxArrowsNot.AutoSize = true;
            this.checkBoxArrowsNot.Location = new System.Drawing.Point(202, 155);
            this.checkBoxArrowsNot.Name = "checkBoxArrowsNot";
            this.checkBoxArrowsNot.Size = new System.Drawing.Size(49, 17);
            this.checkBoxArrowsNot.TabIndex = 11;
            this.checkBoxArrowsNot.Text = "NOT";
            this.checkBoxArrowsNot.UseVisualStyleBackColor = true;
            this.checkBoxArrowsNot.CheckedChanged += new System.EventHandler(this.checkBoxNot_CheckedChanged);
            // 
            // ActionForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(282, 308);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxAppliesTo);
            this.Controls.Add(this.pictureBoxAction);
            this.Controls.Add(this.panelArrows);
            this.Controls.Add(this.panelNormal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Action Properties";
            this.Load += new System.EventHandler(this.ActionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAction)).EndInit();
            this.groupBoxAppliesTo.ResumeLayout(false);
            this.groupBoxAppliesTo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelNormal.ResumeLayout(false);
            this.panelNormal.PerformLayout();
            this.panelArrows.ResumeLayout(false);
            this.panelArrows.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAction;
        private System.Windows.Forms.GroupBox groupBoxAppliesTo;
        private System.Windows.Forms.RadioButton radioButtonObject;
        private System.Windows.Forms.RadioButton radioButtonOther;
        private System.Windows.Forms.RadioButton radioButtonSelf;
        private System.Windows.Forms.Panel panelNormal;
        private System.Windows.Forms.CheckBox checkBoxRelative;
        private System.Windows.Forms.CheckBox checkBoxNot;
        private System.Windows.Forms.Label labelArg6;
        private System.Windows.Forms.TextBox textBoxArg6;
        private System.Windows.Forms.Button buttonArg6;
        private System.Windows.Forms.Label labelArg5;
        private System.Windows.Forms.TextBox textBoxArg5;
        private System.Windows.Forms.Button buttonArg5;
        private System.Windows.Forms.Label labelArg4;
        private System.Windows.Forms.TextBox textBoxArg4;
        private System.Windows.Forms.Button buttonArg4;
        private System.Windows.Forms.Label labelArg3;
        private System.Windows.Forms.TextBox textBoxArg3;
        private System.Windows.Forms.Button buttonArg3;
        private System.Windows.Forms.Label labelArg2;
        private System.Windows.Forms.TextBox textBoxArg2;
        private System.Windows.Forms.Button buttonArg2;
        private System.Windows.Forms.Label labelArg1;
        private System.Windows.Forms.TextBox textBoxArg1;
        private System.Windows.Forms.Button buttonArg1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelArrows;
        private System.Windows.Forms.CheckBox checkBoxArrowsRelative;
        private System.Windows.Forms.CheckBox checkBoxArrowsNot;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelDirections;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.CheckBox checkBoxSW;
        private System.Windows.Forms.CheckBox checkBoxS;
        private System.Windows.Forms.CheckBox checkBoxSE;
        private System.Windows.Forms.CheckBox checkBoxW;
        private System.Windows.Forms.CheckBox checkBoxStop;
        private System.Windows.Forms.CheckBox checkBoxE;
        private System.Windows.Forms.CheckBox checkBoxNW;
        private System.Windows.Forms.CheckBox checkBoxN;
        private System.Windows.Forms.CheckBox checkBoxNE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}