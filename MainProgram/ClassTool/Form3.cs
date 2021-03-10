using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ViewTool
{
    public partial class Form3 : Form
    {
        static bool isDown = false;
        static Point p = new Point(0, 0);
        Graphics drawG;
        Pen pen1 = new Pen(Color.Red, 4);
        Image tempImg;
        Image tempImg2;  //用于清除后重绘
        string picpath;
        Point p1;//按下记录点
        Point p2;//放开记录点
        



        public Form3()
        {
            InitializeComponent();
            //双缓冲
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }


        private void DrawForm_Load(object sender, EventArgs e)
        {

            Bitmap a = (Bitmap)Bitmap.FromFile(@"img\DrawCursos.png");
            SetCursor(a, new Point(0, 0));

            Temp._fm3 = this; //保存fm3对象

            this.Visible = false;   //防止干扰截屏

            //调整PictureBox大小和位置
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            pictureBox1.Location = new Point(0, 0);

            //this.pictureBox1.Image = CatchScreen();
            tempImg2 = CatchScreen();
            picpath = System.AppDomain.CurrentDomain.BaseDirectory + "temp.png";
            tempImg2.Save(picpath, ImageFormat.Png);
            tempImg2.Dispose();
            tempImg = Image.FromFile(picpath);
            //tempDesktop = CatchScreen(); //保存当前桌面原画
            pictureBox1.Image = tempImg;

            this.Visible = true;
            //this.BackgroundImage = CatchScreen();     //将Image赋值给窗体


            //在外部实例化对象，避免重复执行 占用资源
            // drawG = this.CreateGraphics();
            drawG = Graphics.FromImage(tempImg);   //将获取的Img用于实例化Graphics
            drawG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }



        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);

            this.Cursor = new Cursor(myNewCursor.GetHicon());

            g.Dispose();
            myNewCursor.Dispose();
        }

        /// <summary>
        /// 截取屏幕，并且返回Image对象
        /// </summary>
        /// <returns></returns>
        public Image CatchScreen()
        {
            int sWidth = Screen.PrimaryScreen.Bounds.Width;
            int sHeight = Screen.PrimaryScreen.Bounds.Height;
            Image img = new Bitmap(sWidth, sHeight); //创建与屏幕一样大的Image
            Graphics gp = Graphics.FromImage(img);
            gp.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(sWidth, sHeight));//自动赋值给Image
            return img;
        }



        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tempImg = Image.FromFile(picpath);
            Temp._fm1.drawAgain();
            //pictureBox1.Image = tempImg;
            //drawG = Graphics.FromImage(tempImg); //重新建立drawG，因为这几步转换已经改变了tempImg
            //drawG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //别忘了设置抗锯齿

        }

        private void 置剪切板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(tempImg);
        }

        public void fm3_quit() {
            drawG.Dispose();
            tempImg.Dispose();
            tempImg2.Dispose();
            Temp._isDraw = false;
            Temp._fm6.Hide();
            this.Close();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawG.Dispose();
            tempImg.Dispose();
            tempImg2.Dispose();
            Temp._isDraw = false;
            Temp._fm6.Hide();
            this.Close();
        }



        //bool isLeftDown;
        Point tempPoint = new Point();
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Temp.isLeftDown = true;
                tempPoint = e.Location;
            }
            p1 = e.Location;
            if (Temp.drawKey== "Control") {
                //timer1.Enabled = true;        放弃动态绘制

            }
        }
        // 

        //用于动态展示
        private void drawArrow2()
        {
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen RedPen = new Pen(pen1.Color, pen1.Width);
            pictureBox1.Refresh();
            RedPen.CustomEndCap = lineCap;
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(RedPen, p1, p2);
        }
        //真正写入image
        private void drawArrow() {
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            
            Pen RedPen =new  Pen(pen1.Color,pen1.Width);
            pictureBox1.Refresh();
            RedPen.CustomEndCap = lineCap;
            
            drawG.DrawLine(RedPen, p1, p2);
            pictureBox1.Image = tempImg;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
            if (Temp.isLeftDown == true && Temp.drawKey=="")
            {
                drawG.DrawLine(pen1, tempPoint, e.Location);
                tempPoint = e.Location;
                pictureBox1.Image = tempImg;
            }
            if (Temp.isLeftDown ==true && Temp.drawKey=="Alt") {
                drawArrow2();



            }
            if (Temp.isLeftDown == true && Temp.drawKey == "Control") {
                
                drawRectangle2();
                //Graphics a = pictureBox1.CreateGraphics();
                //a.DrawLine(pen1, tempPoint, e.Location);
                //MessageBox.Show("");
                //Rectangle rt = new Rectangle(tempPoint,new Size(e.X-tempPoint.X,e.Y-tempPoint.Y));
                //drawG.DrawRectangle(pen1,rt);

            }


        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Temp.isLeftDown = false;
            p2 = e.Location;
            timer1.Enabled = false;
            if (Temp.drawKey=="Control") {
                try
                {
                    drawRectangle();
                }
                catch { }

                //Graphics gtest = pictureBox1.CreateGraphics(); 一个不错的想法  画直线
                //gtest.DrawLine(pen1, p1, p2);
                //MessageBox.Show("55");
            }
            if (Temp.drawKey == "Alt")
            {
                
                try
                {
                    drawArrow();
                }
                catch { }
                //Graphics gtest = pictureBox1.CreateGraphics(); 一个不错的想法  画直线
                //gtest.DrawLine(pen1, p1, p2);
                //MessageBox.Show("55");
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            drawG.Dispose();
            tempImg.Dispose();
            pictureBox1.Dispose();
            tempImg2.Dispose();
            Temp._isDraw = false;
            Temp._fm6.Hide();
            this.Close();
        }

        void SingleCheck(object sender)
        {
            thickness_smallmost.Checked = false;
            thickness_middle.Checked = false;
            thickness_widemost.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }



        private void Menue_Click(object sender, EventArgs e)
        {
            string var = ((ToolStripMenuItem)sender).Name.ToString();  //转菜单，判断Name属性
            string temp = var;
            if (var.IndexOf("_") > 0)
            {     //判断是否为子菜单

                var = temp.Substring(0, temp.IndexOf("_"));
            }
            switch (var)
            {
                case "thickness":
                    thickness_smallmost.Checked = false;
                    thickness_small.Checked = false;
                    thickness_middle.Checked = false;
                    thickness_wide.Checked = false;
                    thickness_widemost.Checked = false;
                    switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag.ToString()))
                    {
                        case 1:
                            thickness_smallmost.Checked = true;
                            pen1.Width = 2;
                            break;

                        case 2:
                            thickness_small.Checked = true;
                            pen1.Width = 3;
                            break;

                        case 3:                 //中
                            thickness_middle.Checked = true;
                            pen1.Width = 4;
                            break;

                        case 4:
                            thickness_wide.Checked = true;
                            pen1.Width = 5;
                            break;

                        case 5:
                            thickness_widemost.Checked = true;
                            pen1.Width = 6;
                            break;
                    }
                    break;

                case "color":
                    color_black.Checked = false;
                    color_red.Checked = false;
                    color_yellow.Checked = false;
                    color_blue.Checked = false;
                    color_green.Checked = false;
                    color_cyan.Checked = false;
                    color_orange.Checked = false;
                    color_purple.Checked = false;
                    ((ToolStripMenuItem)sender).Checked = true;
                    switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag.ToString()))
                    {
                        case 1:
                            pen1.Color = System.Drawing.Color.Black;
                            break;
                        case 2:
                            pen1.Color = System.Drawing.Color.Red;
                            break;
                        case 3:
                            pen1.Color = System.Drawing.Color.Yellow;
                            break;
                        case 4:
                            pen1.Color = System.Drawing.Color.Blue;
                            break;
                        case 5:
                            pen1.Color = System.Drawing.Color.Green;
                            break;
                        case 6:
                            pen1.Color = System.Drawing.Color.Cyan;
                            break;
                        case 7:
                            pen1.Color = System.Drawing.Color.Orange;
                            break;
                        case 8:
                            pen1.Color = System.Drawing.Color.Purple;
                            break;

                    }
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isSave = true;
            SaveFileDialog dg = new SaveFileDialog();
            dg.Title = "图片保存";
            dg.Filter = @"JPEG|*.jpg|PNG|*.png|BMP|*.bmp|GIF|*.gif";
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
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                MessageBox.Show("只能存取为: jpg,bmp,gif,png 格式");
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
                            MessageBox.Show("保存失败,你还没有截取过图片或已经清空图片!");
                        }
                    }

                }
            }
        }

        Size sz;
        Rectangle rec;
        Point r;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Graphics g = this.CreateGraphics();
            //MessageBox.Show("ppp");
            this.Refresh();
        }
            //用于给image画框
        private void drawRectangle() {
            if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)
            {
                sz = new Size(p2.X - p1.X, p2.Y - p1.Y);
                rec = new Rectangle(p1, sz);
                drawG.DrawRectangle(pen1, rec);
                pictureBox1.Image = tempImg;
            }



            else if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)
            {
                //drawG = Graphics.FromImage(tempImg);   //将获取的Img用于实例化Graphics
                //drawG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                r.X = p1.X;
                r.Y = p2.Y;
                sz = new Size(p2.X - p1.X, p1.Y - p2.Y);
                rec = new Rectangle(r, sz);
                drawG.DrawRectangle(pen1, rec);
                pictureBox1.Image = tempImg;
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)
            {
                r.X = p2.X;
                r.Y = p1.Y;
                sz = new Size(p1.X - p2.X, p2.Y - p1.Y);
                rec = new Rectangle(r, sz);
                drawG.DrawRectangle(pen1, rec);
                pictureBox1.Image = tempImg;
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)
            {
                r.X = p2.X;
                r.Y = p2.Y;
                sz = new Size(p1.X - p2.X, p1.Y - p2.Y);
                rec = new Rectangle(r, sz);
                drawG.DrawRectangle(pen1, rec);
                pictureBox1.Image = tempImg;
            }
        }

        //用来展现框，但实际并不加入image中
        private void drawRectangle2() {
            pictureBox1.Refresh();
            Graphics picG = pictureBox1.CreateGraphics();
            if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)
            {
               
                sz = new Size(p2.X - p1.X, p2.Y - p1.Y);
                rec = new Rectangle(p1, sz);
                picG.DrawRectangle(pen1, rec);
                //pictureBox1.Image = tempImg;
            }

            else if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)
            {
                //drawG = Graphics.FromImage(tempImg);   //将获取的Img用于实例化Graphics
                //drawG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                r.X = p1.X;
                r.Y = p2.Y;
                sz = new Size(p2.X - p1.X, p1.Y - p2.Y);
                rec = new Rectangle(r, sz);
                picG.DrawRectangle(pen1, rec);
                
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)
            {
                r.X = p2.X;
                r.Y = p1.Y;
                sz = new Size(p1.X - p2.X, p2.Y - p1.Y);
                rec = new Rectangle(r, sz);
                picG.DrawRectangle(pen1, rec);
                
            }
            else if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)
            {
                r.X = p2.X;
                r.Y = p2.Y;
                sz = new Size(p1.X - p2.X, p1.Y - p2.Y);
                rec = new Rectangle(r, sz);
                picG.DrawRectangle(pen1, rec);
                
            }
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                drawG.Dispose();
                tempImg.Dispose();
                tempImg2.Dispose();
                Temp._isDraw = false;
                Temp._fm6.Hide();
                this.Close();
            }
        }
    }
}
/*
 //以下为画图时候的标记做准备
            if (e.KeyData == (Keys.Alt)) { Temp.drawKey="Alt"; }    //画箭头
            if (e.KeyData == (Keys.Control)) { Temp.drawKey="Control"; }//画矩形

     */
