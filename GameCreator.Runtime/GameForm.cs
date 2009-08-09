using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.Runtime
{
    partial class GameForm : Form
    {
        Room current;
        public GameForm(Room startroom)
        {
            InitializeComponent();
            current = startroom;
            startroom.Init();
        }

        private void GameForm_Click(object sender, EventArgs e)
        {
            current.Init();
        }
    }
}
