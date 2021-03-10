using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ViewTool
{
    public partial class Form1 : Form
    {

        static bool isOpen = false;               //新建变量，用于判断窗口2是否打开




        KeyboardHook kh = new KeyboardHook();    //实例化键盘钩子，用于监控热键
        Sunisoft.IrisSkin.SkinEngine se = null;     //皮肤对象
        public Form1()
        {

            InitializeComponent();
            se = new Sunisoft.IrisSkin.SkinEngine();
            se.SkinAllForm = true;//所有窗体均应用此皮肤
            se.SkinFile = "skin/Vista2_color6.ssk";
            se.SkinDialogs = false; //防止对话框报错

        }

        public void button1_Click(object sender, EventArgs e)
        {
            IsOpenCursor();
        }

        //注册的Focus事件        牵扯问题太多，停用


        private void Form1_Load(object sender, EventArgs e)
        {
            
            string runname = Path.GetFileName(Application.ExecutablePath);
            if (runname != "ClassTool.exe")
            {
                MessageBox.Show("Don't change file name, Please keep file name as 'ClassTool.exe'", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            Process[] pro = Process.GetProcesses();
            int cout = 0;
            foreach (Process p in pro)
            {
                if (p.ProcessName == Path.GetFileNameWithoutExtension(runname))
                {
                    cout += 1;
                }
            }
            if (cout > 1)
            {
                MessageBox.Show("The program has been executed.", "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            Temp._fm1 = this;
            //Temp._fm2 = new Form2();    //实例化一次窗口2，防止重复实例化
            Temp._fm3 = new Form3();    //实例化一次窗口3，防止重复实例化
            Temp._cs = new ColorScreen();//实例化一次窗口ColorScreen，防止重复实例化
            Temp._menu1 = OpenCursorLight;      //窗口菜单中  光晕状态
            Temp._menu2_con = conOpenCursorLight;   //右键菜单中 光晕状态
            Temp._fm5 = new Form5();        //工具条
            Temp._fm6 = new Form6();        //圈圈点点工具条

            //gotfocusth.Start();

            //设置键盘钩子
            kh.SetHook();
            kh.OnKeyDownEvent += kh_OnKeyDownEvent;
            kh.OnKeyUpEvent += kh_OnKeyUpEvent;


        }
        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void kh_OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.A | Keys.Alt)) { IsOpenCursor(); }
            if (e.KeyData == (Keys.S | Keys.Alt)) { Draw(); }
            if (e.KeyData == (Keys.D | Keys.Alt)) { IsOpenEnlarge(); }
            //if (e.KeyData == (Keys.F | Keys.Alt)) { Record(); }
            if (e.KeyData == (Keys.G | Keys.Alt)) { StartScreenShot(); }
            if (e.KeyData == (Keys.T | Keys.Alt)) { toolbar(); }

            if (e.KeyValue == 164 || e.KeyValue == 165) { Temp.drawKey = "Alt"; }//MessageBox.Show("Alt Press"); }    //画箭头
            if (e.KeyValue == 162 || e.KeyValue == 163) { Temp.drawKey = "Control";}//MessageBox.Show("Ctrl Press"); }//画矩形
        }
        void kh_OnKeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString()=="LMenu") { Temp.drawKey = "" ; }
            if (e.KeyData.ToString() == "LControlKey") { Temp.drawKey = ""; }
            if (e.KeyData.ToString() == "RMenu") { Temp.drawKey = ""; }
            if (e.KeyData.ToString() == "RControlKey") { Temp.drawKey = ""; }
            //MessageBox.Show(e.KeyData.ToString());

        }

        ///使主界面成为工具条模式

        /// <summary>
        /// 启动光晕窗口，并且赋予初始值
        /// </summary>
        /// 
        void LightShow()
        {

            Process pro = new Process();
            pro.StartInfo.FileName = @"application\CursorLight.exe";

            //独立程序中 自动初始化坐标
            //Temp._mPoint.X = MousePosition.X;
            //Temp._mPoint.Y = MousePosition.Y;


            if (isOpen == false)
            {
                pro.Start();  //启动鼠标光晕
                isOpen = true;
            }
            else {
                Process[] ps = Process.GetProcesses();
                foreach (Process item in ps)
                {
                    if (item.ProcessName == "CursorLight")
                    {
                        item.Kill();
                    }
                }
                isOpen = false;
            }
        }

        private void 开启光晕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsOpenCursor();




        }
        /// <summary>
        /// 统一制定鼠标光晕的开关状态,并且根据已有状态开启或者光晕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IsOpenCursor()
        {
            if (Temp._menu1.Checked == false && button1.Text == "Highlight" && Temp._menu2_con.Checked == false)
            {
                LightShow();
                this.Focus();
                Temp._menu1.Checked = true;
                Temp._menu2_con.Checked = true;
                button1.Text = "Off Highlight";



            }
            else {
                Temp._menu1.Checked = false;
                Temp._menu2_con.Checked = false;
                button1.Text = "Highlight";
                LightShow();

            }
        }
        public void drawAgain() {
           // Form3 fm3 = new Form3();
            Temp._fm3.fm3_quit();
            Draw();
            //Temp._fm3;
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        bool FistShow = true;


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                if (FistShow == true)
                {        //如果是第一次关闭，则气泡提示
                    notifyIcon1.ShowBalloonTip(500, this.Text, this.Text + " Running in the background", ToolTipIcon.Info);
                    FistShow = false;
                }
                return;
            }
            //关闭 CursorLight 和 Enlarge 或 ScreenShot
            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == "CursorLight" || item.ProcessName == "Enlarge" || item.ProcessName == "ScreenShot")
                {
                    item.Kill();
                }
            }


        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();  //不能用close 会被判定为 UserClosing
        }

        private void 打开主窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void conOpenCursorLight_Click(object sender, EventArgs e)
        {
            IsOpenCursor();
        }

        private void 缩小至任务栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 最小化置托盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            kh.UnHook();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void DrawPic_Click(object sender, EventArgs e)
        {
            Draw();
        }
        public void Draw()
        {
            if (Temp._isDraw == false)
            {
               
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "temp.png");//清理缓存

                Form3 fm3 = new Form3();
                fm3.Show();
                Temp._isDraw = true;
                Temp._fm6.Show();
            }

        }

        private void 启动画笔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IsOpenEnlarge();
        }

        bool largeOpen;
        public void IsOpenEnlarge()
        {
            Process pro = new Process();
            pro.StartInfo.FileName = @"application\Zoom\Enlarge.exe";

            if (largeOpen == false)
            {
                pro.Start();  //启动局部放大
                largeOpen = true;
                button3.Text = "Off Zoom";
                OpenEnlarge.Checked = true;
                conEnlarge.Checked = true;
            }
            else {
                Process[] ps = Process.GetProcesses();
                foreach (Process item in ps)
                {
                    if (item.ProcessName == "Enlarge")
                    {
                        item.Kill();
                    }
                }
                button3.Text = "Zoom";
                largeOpen = false;
                OpenEnlarge.Checked = false;
                conEnlarge.Checked = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            OpenColorScreen();
        }

        private void 开启局部放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsOpenEnlarge();
        }

        private void 色彩帷幕AltFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenColorScreen();

        }

        void OpenColorScreen()
        {
            if (Temp._cs.Visible == false)
            {
                Temp._cs.Show();
                button4.Text = "关闭色彩帷幕";
                StartColorScreen.Checked = true;
                conColorScreen.Checked = true;
                this.Focus();
            }
            else {
                Temp._cs.Hide();
                button4.Text = "开启色彩帷幕";
                StartColorScreen.Checked = false;
                conColorScreen.Checked = false;
                this.Focus();
            }
        }
        //void menuCS(object sender, EventArgs e)
        //{


        //    string var = ((ToolStripMenuItem)sender).Name.ToString();
        //    var = var.Substring(0, var.IndexOf("_"));
        //    if (var == "Color")
        //    {
        //        Color_Black.Checked = false;
        //        Color_Green.Checked = false;
        //        Color_Indigo.Checked = false;
        //        Color_Purple.Checked = false;
        //        Color_SkyBlue.Checked = false;
        //        Color_Snow.Checked = false;
        //        Color_Tan.Checked = false;
        //        Color_Tomato.Checked = false;
        //        Color_Red.Checked = false;
        //        Color_Org.Checked = false;
        //        ((ToolStripMenuItem)sender).Checked = true;
        //        switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
        //        {
        //            case 1:
        //                Temp._cs.BackColor = System.Drawing.Color.Black;
        //                break;
        //            case 2:
        //                Temp._cs.BackColor = System.Drawing.Color.Green;
        //                break;
        //            case 3:
        //                Temp._cs.BackColor = System.Drawing.Color.Indigo;
        //                break;
        //            case 4:
        //                Temp._cs.BackColor = System.Drawing.Color.Snow;
        //                break;
        //            case 5:
        //                Temp._cs.BackColor = System.Drawing.Color.Tomato;
        //                break;
        //            case 6:
        //                Temp._cs.BackColor = System.Drawing.Color.Purple;
        //                break;
        //            case 7:
        //                Temp._cs.BackColor = System.Drawing.Color.SkyBlue;
        //                break;
        //            case 8:
        //                Temp._cs.BackColor = System.Drawing.Color.Tan;
        //                break;
        //            case 9:
        //                Temp._cs.BackColor = System.Drawing.Color.Red;
        //                break;
        //            case 10:
        //                Temp._cs.BackColor = System.Drawing.Color.Orange;
        //                break;
        //        }
        //    }
        //    else if (var == "Level")
        //    {
        //        Level_Last.Checked = false;
        //        Level_Later.Checked = false;
        //        Level_Mid.Checked = false;
        //        Level_More.Checked = false;
        //        Level_Most.Checked = false;
        //        ((ToolStripMenuItem)sender).Checked = true;

        //        switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
        //        {
        //            case 1:
        //                Temp._cs.Opacity = 0.05;
        //                break;
        //            case 2:
        //                Temp._cs.Opacity = 0.1;
        //                break;
        //            case 3:
        //                Temp._cs.Opacity = 0.15;
        //                break;
        //            case 4:
        //                Temp._cs.Opacity = 0.2;
        //                break;
        //            case 5:
        //                Temp._cs.Opacity = 0.25;
        //                break;

        //        }

        //    }
        //}
        void menuCS2(object sender, EventArgs e)    //右键菜单,然后再设置 窗体菜单
        {


            string var = ((ToolStripMenuItem)sender).Name.ToString();
            var = var.Substring(0, var.IndexOf("_"));
            #region 执行右键菜单响应
            if (var == "mColor" )  //如果为 右键菜单，执行他自己的判断
            {
                mColor_Black.Checked = false;
                mColor_Green.Checked = false;
                mColor_Indigo.Checked = false;
                mColor_Purple.Checked = false;
                mColor_SkyBlue.Checked = false;
                mColor_Snow.Checked = false;
                mColor_Tan.Checked = false;
                mColor_Tomato.Checked = false;
                mColor_Red.Checked = false;
                mColor_Org.Checked = false;

                Color_Black.Checked = false;
                Color_Green.Checked = false;
                Color_Indigo.Checked = false;
                Color_Purple.Checked = false;
                Color_SkyBlue.Checked = false;
                Color_Snow.Checked = false;
                Color_Tan.Checked = false;
                Color_Tomato.Checked = false;
                Color_Red.Checked = false;
                Color_Org.Checked = false;

                ((ToolStripMenuItem)sender).Checked = true;
                switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
                {
                    case 1:
                        Temp._cs.BackColor = System.Drawing.Color.Black;
                        Color_Black.Checked = true;
                        break;
                    case 2:
                        Temp._cs.BackColor = System.Drawing.Color.Green;
                        Color_Green.Checked = true;
                        break;
                    case 3:
                        Temp._cs.BackColor = System.Drawing.Color.Indigo;
                        Color_Indigo.Checked = true;
                        break;
                    case 4:
                        Temp._cs.BackColor = System.Drawing.Color.Snow;
                        Color_Snow.Checked = true;
                        break;
                    case 5:
                        Temp._cs.BackColor = System.Drawing.Color.Tomato;
                        Color_Tomato.Checked = true;
                        break;
                    case 6:
                        Temp._cs.BackColor = System.Drawing.Color.Purple;
                        Color_Purple.Checked = true;
                        break;
                    case 7:
                        Temp._cs.BackColor = System.Drawing.Color.SkyBlue;
                        Color_SkyBlue.Checked = true;
                        break;
                    case 8:
                        Temp._cs.BackColor = System.Drawing.Color.Tan;
                        Color_Tan.Checked = true;
                        break;
                    case 9:
                        Temp._cs.BackColor = System.Drawing.Color.Red;
                        Color_Red.Checked = true;
                        break;
                    case 10:
                        Temp._cs.BackColor = System.Drawing.Color.Orange;
                        Color_Org.Checked = true;
                        break;
                }
            }
            else if (var == "mLevel")
            {
                mLevel_Last.Checked = false;
                mLevel_Later.Checked = false;
                mLevel_Mid.Checked = false;
                mLevel_More.Checked = false;
                mLevel_Most.Checked = false;

                Level_Last.Checked = false;
                Level_Later.Checked = false;
                Level_Mid.Checked = false;
                Level_More.Checked = false;
                Level_Most.Checked = false;

                ((ToolStripMenuItem)sender).Checked = true;

                switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
                {
                    case 1:
                        Temp._cs.Opacity = 0.05;
                        Level_Last.Checked = true;
                        break;
                    case 2:
                        Temp._cs.Opacity = 0.1;
                        Level_Later.Checked = true;
                        break;
                    case 3:
                        Temp._cs.Opacity = 0.15;
                        Level_Mid.Checked = true;
                        break;
                    case 4:
                        Temp._cs.Opacity = 0.2;
                        Level_More.Checked = true;
                        break;
                    case 5:
                        Temp._cs.Opacity = 0.25;
                        Level_Most.Checked = true;
                        break;
                }

            }
            #endregion

        }   

        void menuCS(object sender, EventArgs e)   //窗体菜单中执行完毕后，设置右键菜单
        {
            string var = ((ToolStripMenuItem)sender).Name.ToString();
            var = var.Substring(0, var.IndexOf("_"));
            #region 执行 窗体菜单相应事件
            if (var == "Color")  //如果为 右键菜单，执行他自己的判断
            {
                Color_Black.Checked = false;
                Color_Green.Checked = false;
                Color_Indigo.Checked = false;
                Color_Purple.Checked = false;
                Color_SkyBlue.Checked = false;
                Color_Snow.Checked = false;
                Color_Tan.Checked = false;
                Color_Tomato.Checked = false;
                Color_Red.Checked = false;
                Color_Org.Checked = false;

                mColor_Black.Checked = false;
                mColor_Green.Checked = false;
                mColor_Indigo.Checked = false;
                mColor_Purple.Checked = false;
                mColor_SkyBlue.Checked = false;
                mColor_Snow.Checked = false;
                mColor_Tan.Checked = false;
                mColor_Tomato.Checked = false;
                mColor_Red.Checked = false;
                mColor_Org.Checked = false;

                ((ToolStripMenuItem)sender).Checked = true;
                switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
                {
                    case 1:
                        Temp._cs.BackColor = System.Drawing.Color.Black;
                        mColor_Black.Checked = true;
                        break;
                    case 2:
                        Temp._cs.BackColor = System.Drawing.Color.Green;
                        mColor_Green.Checked = true;
                        break;
                    case 3:
                        Temp._cs.BackColor = System.Drawing.Color.Indigo;
                        mColor_Indigo.Checked = true;
                        break;
                    case 4:
                        Temp._cs.BackColor = System.Drawing.Color.Snow;
                        mColor_Snow.Checked = true;
                        break;
                    case 5:
                        Temp._cs.BackColor = System.Drawing.Color.Tomato;
                        mColor_Tomato.Checked = true;
                        break;
                    case 6:
                        Temp._cs.BackColor = System.Drawing.Color.Purple;
                        mColor_Purple.Checked = true;
                        break;
                    case 7:
                        Temp._cs.BackColor = System.Drawing.Color.SkyBlue;
                        mColor_SkyBlue.Checked = true;
                        break;
                    case 8:
                        Temp._cs.BackColor = System.Drawing.Color.Tan;
                        mColor_Tan.Checked = true;
                        break;
                    case 9:
                        Temp._cs.BackColor = System.Drawing.Color.Red;
                        mColor_Red.Checked = true;
                        break;
                    case 10:
                        Temp._cs.BackColor = System.Drawing.Color.Orange;
                        mColor_Org.Checked = true;
                        break;
                }
            }
            else if (var == "Level")
            {
                Level_Last.Checked = false;
                Level_Later.Checked = false;
                Level_Mid.Checked = false;
                Level_More.Checked = false;
                Level_Most.Checked = false;

                mLevel_Last.Checked = false;
                mLevel_Later.Checked = false;
                mLevel_Mid.Checked = false;
                mLevel_More.Checked = false;
                mLevel_Most.Checked = false;

                ((ToolStripMenuItem)sender).Checked = true;

                switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
                {
                    case 1:
                        Temp._cs.Opacity = 0.05;
                        mLevel_Last.Checked = true;
                        break;
                    case 2:
                        Temp._cs.Opacity = 0.1;
                        mLevel_Later.Checked = true;
                        break;
                    case 3:
                        Temp._cs.Opacity = 0.15;
                        mLevel_Mid.Checked = true;
                        break;
                    case 4:
                        Temp._cs.Opacity = 0.2;
                        mLevel_More.Checked = true;
                        break;
                    case 5:
                        Temp._cs.Opacity = 0.25;
                        mLevel_Most.Checked = true;
                        break;

                }

            }
            #endregion
        }   //右键菜单

        private void button5_Click(object sender, EventArgs e)
        {
            StartScreenShot();
        }
        public void StartScreenShot()
        {
            //ScreenShot.exe
            Process pro = new Process();
            pro.StartInfo.FileName = @"application\ScreenShot\screenshot.exe";
            pro.Start();
        }

        private void 开始截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartScreenShot();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            toolbar();
        }
        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }
        }

        private void 屏幕截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartScreenShot();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
            this.Enabled = false;
        }

        private void 色彩帷幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenColorScreen();
        }

        private void 局部放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsOpenEnlarge();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Record();
            
        }

        public void Record() {

            Process pro = new Process();
            pro.StartInfo.FileName = @"application\Record\Record.exe";
            pro.Start();
        }

        private void 程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 打开录制工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record();


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 工具条模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolbar();
        }
        public void toolbar() {
            if (tool.Checked == false)
            {

                Temp._fm5.Show();
                tool.Checked = true;
                tuopan_toolbar.Checked = true;
            }
            else
            {
                Temp._fm5.Hide();
                tool.Checked = false;
                tuopan_toolbar.Checked = false;
            }
        }

        private void 操作说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fm4 = new Form4();
            fm4.Show();
            this.Enabled = false;
        }

        private void topmost_Click(object sender, EventArgs e)
        {
            if (topmost.Checked == true)
            {

                this.TopMost = false;
                topmost.Checked = false;
            }
            else
            {
                this.TopMost = true;
                topmost.Checked = true;
            }
        }

        private void tool_Click(object sender, EventArgs e)
        {
            toolbar();
        }

        private void 工具条ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolbar();
        }
    }
}