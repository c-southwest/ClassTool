namespace ViewTool
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness_smallmost = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness_small = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness_middle = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness_wide = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness_widemost = new System.Windows.Forms.ToolStripMenuItem();
            this.color = new System.Windows.Forms.ToolStripMenuItem();
            this.color_black = new System.Windows.Forms.ToolStripMenuItem();
            this.color_red = new System.Windows.Forms.ToolStripMenuItem();
            this.color_yellow = new System.Windows.Forms.ToolStripMenuItem();
            this.color_blue = new System.Windows.Forms.ToolStripMenuItem();
            this.color_green = new System.Windows.Forms.ToolStripMenuItem();
            this.color_cyan = new System.Windows.Forms.ToolStripMenuItem();
            this.color_orange = new System.Windows.Forms.ToolStripMenuItem();
            this.color_purple = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.置剪切板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem,
            this.thickness,
            this.color,
            this.保存文件ToolStripMenuItem,
            this.置剪切板ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 176);
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.清除ToolStripMenuItem.Text = "Clear";
            this.清除ToolStripMenuItem.Click += new System.EventHandler(this.清除ToolStripMenuItem_Click);
            // 
            // thickness
            // 
            this.thickness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thickness_smallmost,
            this.thickness_small,
            this.thickness_middle,
            this.thickness_wide,
            this.thickness_widemost});
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(210, 24);
            this.thickness.Text = "Thickness";
            // 
            // thickness_smallmost
            // 
            this.thickness_smallmost.Name = "thickness_smallmost";
            this.thickness_smallmost.Size = new System.Drawing.Size(257, 26);
            this.thickness_smallmost.Tag = "1";
            this.thickness_smallmost.Text = "Smallest  ▁▁▁▁▁▁▁";
            this.thickness_smallmost.Click += new System.EventHandler(this.Menue_Click);
            // 
            // thickness_small
            // 
            this.thickness_small.Name = "thickness_small";
            this.thickness_small.Size = new System.Drawing.Size(257, 26);
            this.thickness_small.Tag = "2";
            this.thickness_small.Text = "Small     ▂▂▂▂▂▂▂";
            this.thickness_small.Click += new System.EventHandler(this.Menue_Click);
            // 
            // thickness_middle
            // 
            this.thickness_middle.Checked = true;
            this.thickness_middle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.thickness_middle.Name = "thickness_middle";
            this.thickness_middle.Size = new System.Drawing.Size(257, 26);
            this.thickness_middle.Tag = "3";
            this.thickness_middle.Text = "Middle     ▃▃▃▃▃▃▃";
            this.thickness_middle.Click += new System.EventHandler(this.Menue_Click);
            // 
            // thickness_wide
            // 
            this.thickness_wide.Name = "thickness_wide";
            this.thickness_wide.Size = new System.Drawing.Size(257, 26);
            this.thickness_wide.Tag = "4";
            this.thickness_wide.Text = "Large     ▅▅▅▅▅▅▅";
            this.thickness_wide.Click += new System.EventHandler(this.Menue_Click);
            // 
            // thickness_widemost
            // 
            this.thickness_widemost.Name = "thickness_widemost";
            this.thickness_widemost.Size = new System.Drawing.Size(257, 26);
            this.thickness_widemost.Tag = "5";
            this.thickness_widemost.Text = "Largest  ▆▆▆▆▆▆▆";
            this.thickness_widemost.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color
            // 
            this.color.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.color_black,
            this.color_red,
            this.color_yellow,
            this.color_blue,
            this.color_green,
            this.color_cyan,
            this.color_orange,
            this.color_purple});
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(210, 24);
            this.color.Text = "Color";
            // 
            // color_black
            // 
            this.color_black.Name = "color_black";
            this.color_black.Size = new System.Drawing.Size(224, 26);
            this.color_black.Tag = "1";
            this.color_black.Text = "Black";
            this.color_black.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_red
            // 
            this.color_red.Checked = true;
            this.color_red.CheckState = System.Windows.Forms.CheckState.Checked;
            this.color_red.Name = "color_red";
            this.color_red.Size = new System.Drawing.Size(224, 26);
            this.color_red.Tag = "2";
            this.color_red.Text = "Red";
            this.color_red.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_yellow
            // 
            this.color_yellow.Name = "color_yellow";
            this.color_yellow.Size = new System.Drawing.Size(224, 26);
            this.color_yellow.Tag = "3";
            this.color_yellow.Text = "Yellow";
            this.color_yellow.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_blue
            // 
            this.color_blue.Name = "color_blue";
            this.color_blue.Size = new System.Drawing.Size(224, 26);
            this.color_blue.Tag = "4";
            this.color_blue.Text = "Blue";
            this.color_blue.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_green
            // 
            this.color_green.Name = "color_green";
            this.color_green.Size = new System.Drawing.Size(224, 26);
            this.color_green.Tag = "5";
            this.color_green.Text = "Green";
            this.color_green.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_cyan
            // 
            this.color_cyan.Name = "color_cyan";
            this.color_cyan.Size = new System.Drawing.Size(224, 26);
            this.color_cyan.Tag = "6";
            this.color_cyan.Text = "Cyan";
            this.color_cyan.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_orange
            // 
            this.color_orange.Name = "color_orange";
            this.color_orange.Size = new System.Drawing.Size(224, 26);
            this.color_orange.Tag = "7";
            this.color_orange.Text = "Orange";
            this.color_orange.Click += new System.EventHandler(this.Menue_Click);
            // 
            // color_purple
            // 
            this.color_purple.Name = "color_purple";
            this.color_purple.Size = new System.Drawing.Size(224, 26);
            this.color_purple.Tag = "8";
            this.color_purple.Text = "Purple";
            this.color_purple.Click += new System.EventHandler(this.Menue_Click);
            // 
            // 保存文件ToolStripMenuItem
            // 
            this.保存文件ToolStripMenuItem.Name = "保存文件ToolStripMenuItem";
            this.保存文件ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.保存文件ToolStripMenuItem.Text = "Save as";
            this.保存文件ToolStripMenuItem.Click += new System.EventHandler(this.保存文件ToolStripMenuItem_Click);
            // 
            // 置剪切板ToolStripMenuItem
            // 
            this.置剪切板ToolStripMenuItem.Name = "置剪切板ToolStripMenuItem";
            this.置剪切板ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.置剪切板ToolStripMenuItem.Text = "Copy";
            this.置剪切板ToolStripMenuItem.Click += new System.EventHandler(this.置剪切板ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.退出ToolStripMenuItem.Text = "Quit";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 316);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 348);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "DrawForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form3_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thickness;
        private System.Windows.Forms.ToolStripMenuItem color;
        private System.Windows.Forms.ToolStripMenuItem 置剪切板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thickness_smallmost;
        private System.Windows.Forms.ToolStripMenuItem thickness_middle;
        private System.Windows.Forms.ToolStripMenuItem thickness_widemost;
        private System.Windows.Forms.ToolStripMenuItem color_black;
        private System.Windows.Forms.ToolStripMenuItem color_red;
        private System.Windows.Forms.ToolStripMenuItem color_yellow;
        private System.Windows.Forms.ToolStripMenuItem color_blue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem thickness_small;
        private System.Windows.Forms.ToolStripMenuItem thickness_wide;
        private System.Windows.Forms.ToolStripMenuItem color_green;
        private System.Windows.Forms.ToolStripMenuItem color_cyan;
        private System.Windows.Forms.ToolStripMenuItem color_orange;
        private System.Windows.Forms.ToolStripMenuItem color_purple;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}