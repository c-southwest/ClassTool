using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewTool;

namespace ViewTool
{
    public class Temp
    {
        public static string _temptext;
        public static int _tempint;

        public static Form1 _fm1;       //储存Form1对象
        public static ColorScreen _cs;
        public static Form3 _fm3;
        public static Form5 _fm5;        //工具条窗口
        public static Form6 _fm6;        //圈圈点点工具条窗口

        public static Point _mPoint;        //储存鼠标位置
        public static string _menu;        //储存菜单项目
        public static ToolStripMenuItem _menu1; //储存子菜单 鼠标光晕 运行状态
        public static ToolStripMenuItem _menu2_con; //右键菜单，控制光晕状态
        public static bool _isDraw;             //储存是否进行绘图
        public static bool _isOpenColorScreen;  //储存是否开启色彩帷幕

        public static bool _timer;       //是否启动TopMost控制时钟

        public static Color _csColor=System.Drawing.Color.Snow;       //关于ColorScreen
        public static float _csOp=10;

        public static string drawKey = "";      //用来为圈点工具作图时，作为画箭头或矩形的判断标记
        public static bool isLeftDown;      //用来判断画图
    }
}
