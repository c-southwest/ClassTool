using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace screenshot
{
    public partial class Form1 : Form
    {
        Point p1;
        Point p2;
        Pen pen1 = new Pen(Color.Red, 2);
        Image img2; //截图后的图片
        bool leftBtisDown = false;

        public Form1()
        {
            InitializeComponent();
            //双缓冲
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("ClassTool");
            if (proc.Length == 0)
            {
                this.Close();
            }

            this.Visible = false;
            Size sz1 = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);//屏幕Size
            this.Size = sz1;
            this.Location = new Point(0, 0);

            Image img1 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g1 = Graphics.FromImage(img1);
            g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), sz1);
            g1.DrawRectangle(pen1, 0, 0, sz1.Width, sz1.Height);
            this.BackgroundImage = img1;
            this.Visible = true;
            this.Cursor = Cursors.Cross;
            //this.TopMost = true;
        }

        bool isup;
        private Point offset;
        Point pNow;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            leftBtisDown = true;
            if (isup == false)
            {
                p1 = e.Location; //记录按下的点
                timer1.Enabled = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            leftBtisDown = false;
            if (isup == true)
            {
                return;
            }
            timer1.Enabled = false;
            p2 = e.Location; //记录松开的点


            try
            {
                img2 = new Bitmap(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
            }
            catch
            {
                return;
            }
            Graphics g2 = Graphics.FromImage(img2);
            Point r = new Point();
            Point s = new Point();
            Size sz = new Size();
            string warningMessage = "The area is too small, please select again";
            if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)
            {
                sz = new Size(p2.X - p1.X, p2.Y - p1.Y);

                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(p1, new Point(0, 0), sz); //右下截图
            }
            else if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)
            {
                r.X = p1.X;
                r.Y = p2.Y;
                sz = new Size(p2.X - p1.X, p1.Y - p2.Y);
                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, new Point(0, 0), sz); //右上截图
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)
            {
                r.X = p2.X;
                r.Y = p1.Y;
                sz = new Size(p1.X - p2.X, p2.Y - p1.Y);
                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, new Point(0, 0), sz); //左下截图
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)
            {
                r.X = p2.X;
                r.Y = p2.Y;
                sz = new Size(p1.X - p2.X, p1.Y - p2.Y);
                if (sz.Width < 30 && sz.Height < 30)
                {
                    MessageBox.Show(warningMessage);
                    return;
                }
                g2.CopyFromScreen(r, new Point(0, 0), sz); //左上截图
            }
            pictureBox1.Visible = true;
            pictureBox1.Image = img2;
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Width = Math.Abs(p2.X - p1.X);
            pictureBox1.Height = Math.Abs(p2.Y - p1.Y);

            Point picP = PointToScreen(pictureBox1.Location);

            this.Width = pictureBox1.Width;
            this.Height = pictureBox1.Height;
            //this.Refresh(); //清除红框
            this.CenterToScreen();
            Graphics gpic = this.CreateGraphics();//不必保存的graphics
            gpic.DrawRectangle(pen1, 1, 1, pictureBox1.Width, pictureBox1.Height); //画红框
            isup = true;
            this.Cursor = Cursors.Default;
            this.TopMost = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);  //窗体中点击的坐标，转成屏幕坐标
            offset = new Point(cur.X - this.Left, cur.Y - this.Top); //获得鼠标相当于窗体中的宽高
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gpic = this.CreateGraphics();//不必保存的graphics
            gpic.DrawRectangle(pen1, 1, 1, pictureBox1.Width, pictureBox1.Height); //画红框
        }
        bool isDouble;
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (isDouble == false)
                {
                    pictureBox1.Width *= 2;
                    pictureBox1.Height *= 2;
                    this.Width = pictureBox1.Width;
                    this.Height = pictureBox1.Height;

                    isDouble = true;
                }
                else
                {
                    pictureBox1.Width /= 2;
                    pictureBox1.Height /= 2;
                    this.Width = pictureBox1.Width;
                    this.Height = pictureBox1.Height;

                    isDouble = false;
                }

            }
        }
        void changesize()
        {
            if (isDouble == false)
            {
                pictureBox1.Width *= 2;
                pictureBox1.Height *= 2;
                this.Width = pictureBox1.Width;
                this.Height = pictureBox1.Height;

                isDouble = true;
            }
            else
            {
                pictureBox1.Width /= 2;
                pictureBox1.Height /= 2;
                this.Width = pictureBox1.Width;
                this.Height = pictureBox1.Height;

                isDouble = false;
            }
        }
        private void 复制到剪切板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(img2);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isSave = true;
            SaveFileDialog dg = new SaveFileDialog();
            dg.Title = "Save Image";
            dg.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif";
            if (dg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dg.FileName.ToString();

                if (fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();

                    System.Drawing.Imaging.ImageFormat imgformat = null;

                    if (fileExtName != "")
                    {
                        switch (fileExtName)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "gif":
                                imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                            default:
                                MessageBox.Show("Only support: jpg, bmp, gif Format");
                                isSave = false;
                                break;
                        }

                    }

                    //默认保存为JPG格式  
                    if (imgformat == null)
                    {
                        imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }

                    if (isSave)
                    {
                        try
                        {
                            this.pictureBox1.Image.Save(fileName, imgformat);
                            //MessageBox.Show("图片已经成功保存!");  
                        }
                        catch
                        {
                            MessageBox.Show("Failed, you may not get an image properly, try again");
                        }
                    }

                }
            }
        }

        int incrementW = 0;
        int incrementH = 0;
        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pictureBox1.Width += 50;
            //pictureBox1.Height += 50;

            if (incrementW == 0 || incrementH==0) //first time
            {
                incrementW = (int)(pictureBox1.Width * 0.2);
                incrementH = (int)(pictureBox1.Height * 0.2);
            }
        
            pictureBox1.Width +=  incrementW;
            pictureBox1.Height +=  incrementH;

            this.Width = pictureBox1.Width;
            this.Height = pictureBox1.Height;
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Width <= 50 || pictureBox1.Height <= 50)
            {
                return;
            }

            if (incrementW == 0 || incrementH == 0) //first time
            {
                incrementW = (int)(pictureBox1.Width * 0.2);
                incrementH = (int)(pictureBox1.Height * 0.2);
            }
            pictureBox1.Width -= incrementW;
            pictureBox1.Height -= incrementH;

            this.Width = pictureBox1.Width;
            this.Height = pictureBox1.Height;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (isup == true)
            {
                return;
            }
            p2 = e.Location;
            if (leftBtisDown == true)
            {
                drawRec();
            }

        }

        Size sz = new Size();
        Point r = new Point();   //矩形左上方的点
        Rectangle rec = new Rectangle();

        private void drawRec()
        {
            Graphics g = this.CreateGraphics();
            this.Refresh();

            if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)
            {
                sz = new Size(p2.X - p1.X, p2.Y - p1.Y);
                rec = new Rectangle(p1, sz);
                g.DrawRectangle(pen1, rec);

            }
            else if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)
            {
                r.X = p1.X;
                r.Y = p2.Y;
                sz = new Size(p2.X - p1.X, p1.Y - p2.Y);
                rec = new Rectangle(r, sz);
                g.DrawRectangle(pen1, rec);
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)
            {
                r.X = p2.X;
                r.Y = p1.Y;
                sz = new Size(p1.X - p2.X, p2.Y - p1.Y);
                rec = new Rectangle(r, sz);
                g.DrawRectangle(pen1, rec);
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)
            {
                r.X = p2.X;
                r.Y = p2.Y;
                sz = new Size(p1.X - p2.X, p1.Y - p2.Y);
                rec = new Rectangle(r, sz);
                g.DrawRectangle(pen1, rec);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
