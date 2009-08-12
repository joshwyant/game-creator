using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    public partial class ScriptEditor : Form
    {
        public ScriptEditor()
        {
            InitializeComponent();
        }
        public event EventHandler Save;
        bool saved;
        public string Code
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; saved = true; textBox1.Select(0, 0); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Save != null)
                Save(this, EventArgs.Empty);
            saved = true;
            this.Close();
        }

        private void ScriptEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
                switch (MessageBox.Show("Save changes to the code?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        Save(this, EventArgs.Empty);
                        saved = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }
    }
}
