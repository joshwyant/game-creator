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
    partial class SpriteEditor : Form
    {
        public SpriteEditor()
        {
            InitializeComponent();
        }

        bool saved = true;
        public bool Saved
        {
            get { return saved; }
            set { saved = value; if (!value) Program.GameModified = true; }
        }
        int currentFrame = -1;
        public event EventHandler Save;
        FrameBasedAnimation animation = new FrameBasedAnimation();
        public FrameBasedAnimation Animation { get { return animation; } set { animation = value; Reset(); } }

        private void Reset()
        {
            currentFrame = 0;
            SelectFrame();
            label1.Text = string.Format("{0} subimage{1}", animation.FrameCount, animation.FrameCount != 1 ? "s" : string.Empty);
        }

        private void SpriteEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
                switch (MessageBox.Show("Save changes to the sprite?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        Save(this, EventArgs.Empty);
                        Saved = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap b = new Bitmap(openFileDialog1.FileName))
                {
                    SetImage(b);
                }
            }
        }

        private void SetImage(Bitmap bmp)
        {
            pictureBox1.Image = null;
            animation.Clear();
            animation.AddImage(bmp, false, false, true, null);
            Reset();
        }

        private void AddFrame(Bitmap img)
        {
            if (img == null) return;
            animation.AddImage(img, false, img.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb, true, null);
            Saved = false;
            currentFrame = animation.FrameCount - 1;
            SelectFrame();
            label1.Text = string.Format("{0} subimage{1}", animation.FrameCount, animation.FrameCount != 1 ? "s" : string.Empty);
        }

        private void SpriteEditor_Load(object sender, EventArgs e)
        {

        }

        // delete
        private void button5_Click(object sender, EventArgs e)
        {
            if (animation.FrameCount != 0)
            {
                pictureBox1.Image = null;
                animation.RemoveFrame(currentFrame);
                if (currentFrame == animation.FrameCount) currentFrame--;
                label1.Text = string.Format("{0} subimage{1}", animation.FrameCount, animation.FrameCount != 1 ? "s" : string.Empty);
                SelectFrame();
                Saved = false;
            }
        }

        public void SelectFrame()
        {
            button2.Enabled = currentFrame > 0;
            button3.Enabled = currentFrame != animation.FrameCount - 1;
            button5.Enabled = currentFrame >= 0;
            pictureBox1.Image = currentFrame == -1 ? null : animation.Frames[currentFrame] as Image;
            pictureBox1.Size = currentFrame == -1 ? new Size(32, 32) : pictureBox1.Image.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentFrame--;
            SelectFrame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentFrame++;
            SelectFrame();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFrame(new Bitmap(openFileDialog1.FileName));
            }
        }
    }
}
