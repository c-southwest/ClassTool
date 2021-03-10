using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViewTool
{
    public partial class Form5 : Form
    {
        public Form5()
        {

            InitializeComponent();
        }
        private Point offset;
        private void Form5_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"img/UI/1.png");
            pictureBox2.Image = Image.FromFile(@"img/UI/2.png");
            pictureBox3.Image = Image.FromFile(@"img/UI/3.png");
            pictureBox4.Image = Image.FromFile(@"img/UI/4.png");
            pictureBox5.Image = Image.FromFile(@"img/UI/5.png");
            pictureBox6.Image = Image.FromFile(@"img/UI/6.png");

        }
        Size size1 = new Size(218, 86); //标准工具条
        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Temp._fm1.Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temp._fm1.IsOpenCursor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Temp._fm1.StartScreenShot();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Temp._fm1.IsOpenEnlarge();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Temp._fm1.Record();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Temp._fm1.toolbar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Temp._fm1.IsOpenCursor();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"img/UI/11.png");

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"img/UI/1.png");

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"img/UI/12.png");

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"img/UI/1.png");

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"img/UI/21.png");

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"img/UI/2.png");
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"img/UI/22.png");
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"img/UI/2.png");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Temp._fm1.Draw();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"img/UI/31.png");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"img/UI/3.png");
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"img/UI/32.png");
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"img/UI/3.png");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Temp._fm1.StartScreenShot();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Image.FromFile(@"img/UI/41.png");
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Image.FromFile(@"img/UI/4.png");
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = Image.FromFile(@"img/UI/42.png");
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = Image.FromFile(@"img/UI/4.png");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Temp._fm1.IsOpenEnlarge();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = Image.FromFile(@"img/UI/51.png");
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Image.FromFile(@"img/UI/5.png");
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = Image.FromFile(@"img/UI/52.png");
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = Image.FromFile(@"img/UI/5.png");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Temp._fm1.Record();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = Image.FromFile(@"img/UI/61.png");
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = Image.FromFile(@"img/UI/6.png");
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox6.Image = Image.FromFile(@"img/UI/62.png");
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox6.Image = Image.FromFile(@"img/UI/6.png");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Temp._fm1.toolbar();
        }
    }
}


