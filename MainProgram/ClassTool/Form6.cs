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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temp.drawKey = "";
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Temp.isLeftDown = true;
            Temp.drawKey = "Control";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Temp.isLeftDown = true;
            Temp.drawKey = "Alt";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
        }
    }
}
