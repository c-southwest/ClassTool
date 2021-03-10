using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 局部放大
{
    public partial class Form1 : Form
    {
        MouseHook mh = new MouseHook();
        KeyboardHook kh = new KeyboardHook();
        Image getimg;
        Graphics g;
        Point pSource;
        Size s;
        int sz = 80;        //放大量，越小 图片放得越大

        public Form1()
        {
            
            InitializeComponent();
            mh.OnMouseActivity += new MouseEventHandler(mouse_OnMouseActivity);
            mh.Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("ClassTool");
            if (proc.Length == 0)
            {
                this.Close();
            }

            this.ShowInTaskbar = false;         //取消在任务栏中出现
            this.TopMost = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Width = 320;
            pictureBox1.Height = 300;

            kh.SetHook();
            kh.OnKeyDownEvent += kh_OnKeyDownEvent;
            biger();
        }
        void kh_OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Z | Keys.Alt))
            {
                if (sz >= 6)
                {
                    sz -= 5;
                }
                biger();
            }
            else if (e.KeyData == (Keys.X | Keys.Alt))
            {
                if (sz <= 75)
                {       //缩小到75之后，将失去放大效果，故无用
                    sz += 5;
                }
                biger();
            }

        }



        void mouse_OnMouseActivity(object sender, MouseEventArgs e)
        {

            biger();
        }

        bool left;      //更改显示方式为左的标记
        bool top;
        void biger()
        {

            getimg = new Bitmap(sz * 2, sz * 2);    //新建Image
            g = Graphics.FromImage(getimg);
            pSource = new Point(MousePosition.X - sz, MousePosition.Y - sz);
            s = new Size(sz * 2, sz * 2);
            g.CopyFromScreen(pSource, new Point(0, 0), s);
            pictureBox1.Image = getimg;

            //鼠标移动后判断
            if (MousePosition.X + this.Width + sz >= Screen.PrimaryScreen.Bounds.Width) //窗体超过屏幕右边
            {
                //this.Left = this.Location.X - sz;
                left = true;                    //改为左
            }
            else {
                left = false;
            }

            if (MousePosition.Y + this.Height + sz >= Screen.PrimaryScreen.Bounds.Height)   //窗体超过屏幕下边
            {
                //this.Top = this.Location.Y - sz;    //改为上
                top = true;
            }
            else {
                top = false;
            }



            if (left == true && top != true)
            {
                this.Left = MousePosition.X - sz - this.Width;
                this.Top = MousePosition.Y + sz;
                
            }
            else if (top == true && left != true)
            {
                this.Left = MousePosition.X + sz;
                this.Top = MousePosition.Y - sz - this.Height;
                
            }
            else if (left == true && top == true)
            {
                this.Left = MousePosition.X - sz - this.Width;
                this.Top = MousePosition.Y - sz - this.Height;
              
            }

            if (left != true && top != true)
            {
                this.Left = MousePosition.X + sz;
                this.Top = MousePosition.Y + sz;
            }
            //this.Left = MousePosition.X + sz;
            //this.Top = MousePosition.Y + sz;


            //else if (this.Location.X <= 0)      //窗体超过屏幕左边
            //{
            //    this.Left = this.Location.X + sz * 2;
            //    right = true;
            //}
            //else if (this.Location.Y <= 0)
            //{
            //    this.Top = this.Location.X + sz * 2;
            //}
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mh.Stop();
            kh.UnHook();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

