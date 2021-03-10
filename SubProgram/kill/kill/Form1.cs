using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcesses();
            foreach (Process pro in p) {
                if (pro.ProcessName=="DisplayTool" || pro.ProcessName == "screenshot" || pro.ProcessName == "CursorLight" || pro.ProcessName == "Enlarge") {
                    pro.Kill();
                }
            }
            Close();

        }
    }
}
