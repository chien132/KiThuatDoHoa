﻿namespace KTDH
{
    partial class Form_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_thongtin = new System.Windows.Forms.Button();
            this.lbl_HienThiToaDo2D = new System.Windows.Forms.Label();
            this.checkBox_Luoipixel = new System.Windows.Forms.CheckBox();
            this.btn_3D = new System.Windows.Forms.Button();
            this.btn_2d = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ptb_3D = new System.Windows.Forms.PictureBox();
            this.ptb_2D = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cylinder_Parameter1 = new KTDH.UserC.Cylinder_Parameter();
            this.cube_Parameter1 = new KTDH.UserC.Cube_Parameter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cube = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.thongTinXe1 = new KTDH.UserC.ThongTinXe();
            this.user_Mode2D1 = new KTDH.UserC.user_Mode2D();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_2D)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.bt_thongtin);
            this.panel1.Controls.Add(this.lbl_HienThiToaDo2D);
            this.panel1.Controls.Add(this.checkBox_Luoipixel);
            this.panel1.Controls.Add(this.btn_3D);
            this.panel1.Controls.Add(this.btn_2d);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 42);
            this.panel1.TabIndex = 0;
            // 
            // bt_thongtin
            // 
            this.bt_thongtin.Location = new System.Drawing.Point(343, 10);
            this.bt_thongtin.Name = "bt_thongtin";
            this.bt_thongtin.Size = new System.Drawing.Size(75, 23);
            this.bt_thongtin.TabIndex = 4;
            this.bt_thongtin.Text = "Thong tin";
            this.bt_thongtin.UseVisualStyleBackColor = true;
            this.bt_thongtin.Click += new System.EventHandler(this.bt_thongtin_Click);
            // 
            // lbl_HienThiToaDo2D
            // 
            this.lbl_HienThiToaDo2D.Image = ((System.Drawing.Image)(resources.GetObject("lbl_HienThiToaDo2D.Image")));
            this.lbl_HienThiToaDo2D.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_HienThiToaDo2D.Location = new System.Drawing.Point(240, 14);
            this.lbl_HienThiToaDo2D.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_HienThiToaDo2D.Name = "lbl_HienThiToaDo2D";
            this.lbl_HienThiToaDo2D.Size = new System.Drawing.Size(66, 20);
            this.lbl_HienThiToaDo2D.TabIndex = 3;
            this.lbl_HienThiToaDo2D.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox_Luoipixel
            // 
            this.checkBox_Luoipixel.AutoSize = true;
            this.checkBox_Luoipixel.Location = new System.Drawing.Point(148, 14);
            this.checkBox_Luoipixel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_Luoipixel.Name = "checkBox_Luoipixel";
            this.checkBox_Luoipixel.Size = new System.Drawing.Size(71, 17);
            this.checkBox_Luoipixel.TabIndex = 2;
            this.checkBox_Luoipixel.Text = "Lưới Pixel";
            this.checkBox_Luoipixel.UseVisualStyleBackColor = true;
            this.checkBox_Luoipixel.CheckedChanged += new System.EventHandler(this.CheckBox_Luoipixel_CheckedChanged);
            // 
            // btn_3D
            // 
            this.btn_3D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_3D.FlatAppearance.BorderSize = 0;
            this.btn_3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_3D.ForeColor = System.Drawing.Color.White;
            this.btn_3D.Image = ((System.Drawing.Image)(resources.GetObject("btn_3D.Image")));
            this.btn_3D.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_3D.Location = new System.Drawing.Point(70, 2);
            this.btn_3D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_3D.Name = "btn_3D";
            this.btn_3D.Size = new System.Drawing.Size(58, 37);
            this.btn_3D.TabIndex = 1;
            this.btn_3D.Text = "3D";
            this.btn_3D.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_3D.UseVisualStyleBackColor = false;
            this.btn_3D.Click += new System.EventHandler(this.btn_3D_Click);
            // 
            // btn_2d
            // 
            this.btn_2d.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_2d.FlatAppearance.BorderSize = 0;
            this.btn_2d.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_2d.ForeColor = System.Drawing.Color.White;
            this.btn_2d.Image = ((System.Drawing.Image)(resources.GetObject("btn_2d.Image")));
            this.btn_2d.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_2d.Location = new System.Drawing.Point(2, 2);
            this.btn_2d.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_2d.Name = "btn_2d";
            this.btn_2d.Size = new System.Drawing.Size(48, 37);
            this.btn_2d.TabIndex = 0;
            this.btn_2d.Text = "2D";
            this.btn_2d.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_2d.UseVisualStyleBackColor = false;
            this.btn_2d.Click += new System.EventHandler(this.btn_2d_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ptb_3D);
            this.panel2.Controls.Add(this.ptb_2D);
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 484);
            this.panel2.TabIndex = 1;
            // 
            // ptb_3D
            // 
            this.ptb_3D.BackColor = System.Drawing.Color.Gray;
            this.ptb_3D.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.ptb_3D.Location = new System.Drawing.Point(278, 76);
            this.ptb_3D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptb_3D.Name = "ptb_3D";
            this.ptb_3D.Size = new System.Drawing.Size(165, 178);
            this.ptb_3D.TabIndex = 1;
            this.ptb_3D.TabStop = false;
            this.ptb_3D.SizeChanged += new System.EventHandler(this.Picb_3DArea_SizeChanged);
            this.ptb_3D.Click += new System.EventHandler(this.ptb_3D_Click);
            this.ptb_3D.Paint += new System.Windows.Forms.PaintEventHandler(this.Picb_3D_Paint);
            // 
            // ptb_2D
            // 
            this.ptb_2D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ptb_2D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb_2D.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptb_2D.Location = new System.Drawing.Point(27, 85);
            this.ptb_2D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptb_2D.Name = "ptb_2D";
            this.ptb_2D.Size = new System.Drawing.Size(120, 113);
            this.ptb_2D.TabIndex = 0;
            this.ptb_2D.TabStop = false;
            this.ptb_2D.Click += new System.EventHandler(this.ptb_2D_Click);
            this.ptb_2D.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_2D_Paint);
            this.ptb_2D.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mousemove_2D);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.cylinder_Parameter1);
            this.panel3.Controls.Add(this.cube_Parameter1);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.thongTinXe1);
            this.panel3.Controls.Add(this.user_Mode2D1);
            this.panel3.Location = new System.Drawing.Point(551, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 483);
            this.panel3.TabIndex = 2;
            // 
            // cylinder_Parameter1
            // 
            this.cylinder_Parameter1.BackColor = System.Drawing.SystemColors.Info;
            this.cylinder_Parameter1.Dinh = null;
            this.cylinder_Parameter1.Location = new System.Drawing.Point(2, 12);
            this.cylinder_Parameter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cylinder_Parameter1.Name = "cylinder_Parameter1";
            this.cylinder_Parameter1.Size = new System.Drawing.Size(267, 468);
            this.cylinder_Parameter1.TabIndex = 3;
            // 
            // cube_Parameter1
            // 
            this.cube_Parameter1.BackColor = System.Drawing.SystemColors.Info;
            this.cube_Parameter1.Dinh = null;
            this.cube_Parameter1.Location = new System.Drawing.Point(2, 8);
            this.cube_Parameter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cube_Parameter1.Name = "cube_Parameter1";
            this.cube_Parameter1.Size = new System.Drawing.Size(267, 468);
            this.cube_Parameter1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_cube);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 131);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(271, 222);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3D Shapes";
            // 
            // btn_cube
            // 
            this.btn_cube.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_cube.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_cube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cube.Image = global::KTDH.Properties.Resources.hinhHopCN;
            this.btn_cube.Location = new System.Drawing.Point(34, 41);
            this.btn_cube.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_cube.Name = "btn_cube";
            this.btn_cube.Size = new System.Drawing.Size(86, 77);
            this.btn_cube.TabIndex = 0;
            this.btn_cube.Tag = "Cube";
            this.btn_cube.UseVisualStyleBackColor = false;
            this.btn_cube.Click += new System.EventHandler(this.btn_cube_Click_1);
            this.btn_cube.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN3D_MouseDown);
            this.btn_cube.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btn_cube.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::KTDH.Properties.Resources.hinhTru;
            this.button1.Location = new System.Drawing.Point(142, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 81);
            this.button1.TabIndex = 1;
            this.button1.Tag = "Cylinder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN3D_MouseDown);
            this.button1.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // thongTinXe1
            // 
            this.thongTinXe1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.thongTinXe1.Location = new System.Drawing.Point(0, -1);
            this.thongTinXe1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.thongTinXe1.Name = "thongTinXe1";
            this.thongTinXe1.Size = new System.Drawing.Size(273, 484);
            this.thongTinXe1.TabIndex = 1;
            // 
            // user_Mode2D1
            // 
            this.user_Mode2D1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.user_Mode2D1.Location = new System.Drawing.Point(2, 2);
            this.user_Mode2D1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.user_Mode2D1.Name = "user_Mode2D1";
            this.user_Mode2D1.Size = new System.Drawing.Size(273, 292);
            this.user_Mode2D1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 70;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(824, 531);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_main";
            this.Text = "Kỹ Thuật Đồ Họa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_2D)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_2d;
        private System.Windows.Forms.Button btn_3D;
        private System.Windows.Forms.CheckBox checkBox_Luoipixel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox ptb_2D;
        private UserC.user_Mode2D user_Mode2D1;
        private System.Windows.Forms.Label lbl_HienThiToaDo2D;
        private System.Windows.Forms.Timer timer1;
        private UserC.ThongTinXe thongTinXe1;
        private System.Windows.Forms.Button bt_thongtin;
        private System.Windows.Forms.PictureBox ptb_3D;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cube;
        private System.Windows.Forms.Button button1;
        private UserC.Cube_Parameter cube_Parameter1;
        private UserC.Cylinder_Parameter cylinder_Parameter1;
    }
}

