namespace GameCreator.IDE
{
    partial class TimeLineEditor
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
            this.actionPanel1 = new GameCreator.IDE.ActionPanel();
            this.SuspendLayout();
            // 
            // actionPanel1
            // 
            this.actionPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.actionPanel1.Location = new System.Drawing.Point(260, 0);
            this.actionPanel1.Name = "actionPanel1";
            this.actionPanel1.Size = new System.Drawing.Size(322, 364);
            this.actionPanel1.TabIndex = 0;
            // 
            // TimeLineEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 364);
            this.Controls.Add(this.actionPanel1);
            this.MinimumSize = new System.Drawing.Size(16, 400);
            this.Name = "TimeLineEditor";
            this.Text = "TimeLineEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeLineEditor_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ActionPanel actionPanel1;
    }
}