using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ViewTool
{
    public partial class Form2 : Form
    {
        MouseHook mHook = new MouseHook();                       //实例化MouseHook
        Penetrate penetrate = new Penetrate();                     //鼠标穿透
                                                                   //Temp._mPoint = new Point(MousePosition.X, MousePosition.Y); //新建Point，储存鼠标位置

        public Form2()
        {
            InitializeComponent();

            //窗体初始化后启动钩子
            mHook.OnMouseActivity += new MouseEventHandler(mouse_OnMouseActivity);
            mHook.Start();
        }

        private void MouseEllipse_Load(object sender, EventArgs e)
        {
            Temp._mPoint.X -= 30;
            Temp._mPoint.Y -= 30;
            this.Location = Temp._mPoint;      //初始化时更改窗体2位置
            this.ShowInTaskbar = false;         //取消在任务栏中出现
            this.TopMost = true;                 //设置窗体置顶         *经测试有BUG，抢夺焦点 [更正：仅在自身存在]

            penetrate.CanPenetrate(this.Handle);    //设置窗体鼠标穿透
            
        }

        void mouse_OnMouseActivity(object sender, MouseEventArgs e)
        {
            //动态更改窗体2位置
            Temp._mPoint.X = MousePosition.X - this.Height / 2;      //mPoint以form2的高度作为标准，为正方形
            Temp._mPoint.Y = MousePosition.Y - this.Height / 2;
            this.Location = Temp._mPoint;
            //Temp._fm1.Text = "X:" + Temp._mPoint.X + "  Y:" + Temp._mPoint.Y + " 宽：" + this.Width + " 高:" + this.Height;  //  用于调试使用
            
        }

        bool isDraw = false;
        private void MouseEllipse_Paint(object sender, PaintEventArgs e)
        {

            //优化代码，防止高频重绘浪费资源
            if (isDraw == false)
            {
                GraphicsPath formMouse = new GraphicsPath();        //绘制一个圆，并赋给窗体   
                formMouse.AddEllipse(0, 0, this.Width - 66, this.Height - 6);
                this.Region = new Region(formMouse);
                isDraw = true;
            }


        }

        private void Form2_mouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            mHook.Stop();   //卸载鼠标钩子
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            this.TopMost = true;     
            
        }
    }
}
