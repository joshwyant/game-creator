using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.Runtime.Game
{
    partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }
        public string Message
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.button1;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.button0;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.button2;
        }
    }
}
