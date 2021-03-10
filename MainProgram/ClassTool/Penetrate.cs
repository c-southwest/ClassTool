using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ViewTool
{
    public class Penetrate
    {
        public const uint WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int GWL_EXSTYLE = (-20);

        /// <summary>
        /// 根据句柄获取DC函数
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public extern static IntPtr GetDC(System.IntPtr hWnd);

        /// <summary>
        /// 在窗口结构中为指定的窗口设置信息
        /// </summary>
        /// <param name="hwnd">欲为其取得信息的窗口的句柄</param>
        /// <param name="nIndex">欲取回的信息</param>
        /// <param name="dwNewLong">由nIndex指定的窗口信息的新值</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        public static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        /// <summary>
        /// 从指定窗口的结构中取得信息
        /// </summary>
        /// <param name="hwnd">欲为其获取信息的窗口的句柄</param>
        /// <param name="nIndex">欲取回的信息</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern uint GetWindowLong(IntPtr hwnd, int nIndex);


        /// <summary>
        /// 是否可以穿透
        /// </summary>
        public void CanPenetrate(IntPtr FormHandle)
        {
            uint intExTemp = GetWindowLong(FormHandle, GWL_EXSTYLE);
            uint oldGWLEx = SetWindowLong(FormHandle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }
    }
}
