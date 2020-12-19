using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTDH.ham;
using KTDH.UserC;
using System.Threading;
using KTDH._3D;
namespace KTDH
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();

            Mode.Cylinder = new Cylinder(10, -10, 0, 30, 10);
            Mode.cylinder_Parameter = new Cylinder_Parameter();
            Mode.cylinder_Parameter.Visible = false;

            Mode.Cube = new Cube(0, 0, 0, 10, 10, 10);
            Mode.cube_Parameter = new Cube_Parameter();
            Mode.cube_Parameter.Visible = false;
            ptb_2D.Hide();
            this.timer1.Start();
            hienThiMode();
        }


        private void Form_main_Load(object sender, EventArgs e)
        {
            ham.Mode._2d.Width = traGiaTriChan(ptb_2D.Width / ham.Mode.sizePerPoint.Width);
            ham.Mode._2d.Height = traGiaTriChan(ptb_2D.Height / ham.Mode.sizePerPoint.Height);
            this.ptb_2D.BackgroundImage = veToaDo(new System.Drawing.Size(ptb_2D.Width, ptb_2D.Height));
        }

        #region veToaDO

        private Bitmap veToaDo(System.Drawing.Size size)
        {
            Bitmap trucToaDo = new Bitmap(size.Width, size.Height);

            veLuoiPixel(trucToaDo, new Pen(Color.Red, 1));
            return trucToaDo;
        }

        private void veLuoiPixel(Bitmap bm, Pen pen)
        {
            Graphics g = Graphics.FromImage(bm);

            int width = ham.Mode._2d.Width,
                height = ham.Mode._2d.Height;

            if (checkBox_Luoipixel.Checked)
            {
                // vẽ các đường dọc 
                for (int i = 0; i <= width; i++)
                {
                    if (i == width / 2)
                        continue;
                    g.DrawLine(new Pen(Color.Black), 5 * i, 0, 5 * i, ptb_2D.Height);
                }
                // vẽ các đường ngang
                for (int i = 0; i <= height; i++)
                {
                    if (i == height / 2)
                        continue;
                    g.DrawLine(new Pen(Color.Black), 0, 5 * i, ptb_2D.Width, 5 * i);
                }
            }
            // vẽ trục tọa độ 0xy
            g.DrawLine(pen, 5 * width / 2, 0, 5 * width / 2, ptb_2D.Height);
            g.DrawLine(pen, 0, 5 * height / 2, ptb_2D.Width, 5 * height / 2);
            g.DrawString("X", new Font("Time New Roman", 10), Brushes.White, width * 5 - 10, height * 5 / 2);
            g.DrawString("Y", new Font("Time New Roman", 10), Brushes.White, width * 5 / 2, 5);
        }

        // trả về giá trị chẵn 
        public int traGiaTriChan(int number)
        {
            if (number % 2 == 0)
                return number;
            return number - 1;
        }

        private void CheckBox_Luoipixel_CheckedChanged(object sender, EventArgs e)
        {
            // gán giá trị vào mode 2d theo tỉ lệ 1 ô là 5x5
            ham.Mode._2d.Width = traGiaTriChan(ptb_2D.Width / ham.Mode.sizePerPoint.Width);
            ham.Mode._2d.Height = traGiaTriChan(ptb_2D.Height / ham.Mode.sizePerPoint.Height);

            this.ptb_2D.BackgroundImage = veToaDo(new System.Drawing.Size(ptb_2D.Width, ptb_2D.Height));
        }

        #endregion

        //hien thi che do
        private void hienThiMode()
        {
            ptb_2D.Show();
            ptb_2D.Dock = DockStyle.Fill;
            ptb_2D.BringToFront();
            user_Mode2D1.Show();
            user_Mode2D1.Dock = DockStyle.Right;
            user_Mode2D1.BringToFront();

        }

        #region eventmouse
        private void mousemove_2D(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            p = ham.ToaDo.toaDoMayTinh_2D(p);
            lbl_HienThiToaDo2D.Text = p.X + ", " + p.Y;
        }
        #endregion
        int dem = 0;
        bool flagtao = true;
        private void update()
        {
            for (int i = 0; i < 25; i++)
            {
                thongTinXe1.lsPointXe[i] = ham.Mode.Xe.lsPoint[i];
                thongTinXe1.lsPointCay[i] = ham.Mode.Cay.lsPoint[i];
            }
            thongTinXe1.bankinh = ham.Mode.Xe.BkBanh;
            thongTinXe1.lopxe = ham.Mode.Xe.LopXe;

            thongTinXe1.ChieuCao_la = ham.Mode.Cay.ChieuCao_la;
            thongTinXe1.ChieuRong_la = ham.Mode.Cay.ChieuRong_la;
            thongTinXe1.bk_tao = ham.Mode.Cay.Bk_tao;



            thongTinXe1.HienThiThongTin();
        }
        private void ptb_2D_Paint(object sender, PaintEventArgs e)
        {
            if (ham.Mode.flagXe)       // cờ xe = true => hiện xe 
            {
                if (dem < 75)
                {
                    ham.Mode.Xe.tinhTienXe(10, 0);
                    ham.Mode.Xe.quayBanhXe(-30);
                    ham.Mode.Xe.Draw(e.Graphics);
                    ham.Mode.Cay.Draw(e.Graphics);
                    update();
                    dem += 1;
                    if (dem >= 75) dem = 149;
                }
                else if (dem < 150)
                {
                    ham.Mode.Cay.taoRoi(0, 5);
                    ham.Mode.Xe.tinhTienXe(-10, 0);
                    ham.Mode.Xe.quayBanhXe(30);
                    ham.Mode.Xe.Draw(e.Graphics);
                    ham.Mode.Cay.Draw(e.Graphics);

                    //cho trai tao xoay
                    if (ham.Mode.Cay.LsPoint[6].X >= 1240 && ham.Mode.Cay.LsPoint[6].X <= 1280)
                    {
                        if (flagtao) ham.Mode.Cay.LsPoint[6].X += 5;
                        else ham.Mode.Cay.LsPoint[6].X -= 5;
                        if (ham.Mode.Cay.LsPoint[6].X == 1240 || ham.Mode.Cay.LsPoint[6].X == 1280) flagtao = !flagtao;
                    }

                    update();
                    dem -= 1;
                    if (dem < 95 && dem > 80)
                    {
                        ham.Mode.Cay.drawNuoc1(e.Graphics);
                        if (dem % 2 == 0)
                        {
                            ham.Mode.Cay.ChieuCao_nuoc += 3;
                            ham.Mode.Cay.ChieuRong_nuoc += 2;
                        }
                        if (dem < 90)
                        {
                            ham.Mode.Cay.drawNuoc2(e.Graphics);
                        }
                        if (dem < 85)
                        {
                            ham.Mode.Cay.drawNuoc3(e.Graphics);
                        }
                    }
                    //refresh tat ca 
                    if (dem < 75)
                    {
                        dem = 0;
                        ham.Mode.Cay.LsPoint[4] = new Point(1260, 140);
                        ham.Mode.Cay.LsPoint[5] = new Point(1260, 120);
                        ham.Mode.Cay.LsPoint[6] = new Point(1240, 100);
                        ham.Mode.Cay.LsPoint[7] = new Point(1260, 100);
                        ham.Mode.Cay.ChieuRong_nuoc = 0;
                        ham.Mode.Cay.ChieuCao_nuoc = 0;
                        flagtao = true;
                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ptb_2D.Refresh();
        }


        bool flagxe2 = false;

        private void bt_thongtin_Click(object sender, EventArgs e)
        {            
            if (ham.Mode.flagXe ==true&& flagxe2 == false)
            {
                flagxe2 = true;
                user_Mode2D1.Hide();
                thongTinXe1.Show();
                thongTinXe1.Dock = DockStyle.Right;
                thongTinXe1.BringToFront();
            }
            else if (flagxe2==true)
            {
                flagxe2 = false;
                thongTinXe1.Hide();
                user_Mode2D1.Show();
                user_Mode2D1.Dock = DockStyle.Right;
                user_Mode2D1.BringToFront();
            }
        }

        private void ptb_2D_Click(object sender, EventArgs e)
        {

        }

        private void user_Mode2D1_Load(object sender, EventArgs e)
        {

        }

        private void btn_2d_Click(object sender, EventArgs e)
        {
            ptb_3D.Hide();
            groupBox1.Hide();
            ptb_2D.Show();
            ptb_2D.Dock = DockStyle.Fill;
            ptb_2D.BringToFront();
            user_Mode2D1.Show();
            user_Mode2D1.Dock = DockStyle.Right;
            user_Mode2D1.BringToFront();
        }

        private void ptb_3D_Click(object sender, EventArgs e)
        {

        }
        /// Trả về giá trị chẵn của pnl_WorkStation
        /// </summary>
        public int ReturnEvenNumber(int number)
        {
            if (number % 2 == 0)
                return number;
            return number - 1;
        }

        private void Picb_3DArea_SizeChanged(object sender, EventArgs e)
        {
            Mode.sizeOfNewCoor_3D.Width = ReturnEvenNumber(ptb_3D.Width / Mode.sizePerPoint.Width);
            Mode.sizeOfNewCoor_3D.Height = ReturnEvenNumber(ptb_3D.Height / Mode.sizePerPoint.Height);

            ptb_3D.Width = Mode.sizeOfNewCoor_3D.Width * 5;
            ptb_3D.Height = Mode.sizeOfNewCoor_3D.Height * 5;
        }


        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1; //Resize border
        }

        /// <summary>
        /// Event Handl whent mouse leave this button.
        /// </summary>
        /// <param name="sender">Button clicked.</param>
        /// <param name="e">Event</param>
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 0; //Resize border
        }

        //Draw 3D


        //#region Vẽ trên picb_3DArea sử dụng Cavalier
        private void Picb_3D_Paint(object sender, PaintEventArgs e)
        {
            VeLuoi3D(e.Graphics);

            if (Mode.cylinder_Parameter.Visible == true)
            {
                Mode.Cylinder.Draw(e.Graphics);
                Mode.cylinder_Parameter.Dinh = Mode.Cylinder.TamDay;
            }
            if (Mode.cube_Parameter.Visible == true)
            {
                Mode.Cube.Draw(e.Graphics);
                Mode.cube_Parameter.Dinh = Mode.Cube.Dinh;
            }
        }


        //private void ptb_3d_click(object sender, mouseeventargs e)
        //{
        //    toado.hienthi(e.location, ptb_3d.creategraphics(), color.red);
        //}

        public void VeLuoi3D(Graphics g)
        {
            Pen pen = new Pen(Color.Red);

            // Vẽ trục tọa độ
            pen = new Pen(Color.Black);
            int x = ptb_3D.Width * 2 / 5,//365,
               y = ptb_3D.Height / 2; //305,

            g.DrawLine(pen, new Point(x, y), new Point(ptb_3D.Width, y));         // trục Ox
            g.DrawLine(pen, new Point(x, y), new Point(x, 0));                          // trục Oy
            g.DrawLine(pen, new Point(x, y), new Point(x - y, y + y));                      // trục Oz
            System.Console.WriteLine((x - y) + " " + (y));

            g.DrawString("Y", new Font("Time New Roman", 10), Brushes.Cyan, new Point(620, 25));

            g.DrawString("X", new Font("Time New Roman", 10), Brushes.Cyan, new Point(1550, 420));
            g.DrawString("Z", new Font("Time New Roman", 10), Brushes.Cyan, new Point(280, 880));
        }

        private void HinhTruProperties_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            string[] str = e.PropertyName.Split(',');
            int x = Int16.Parse(str[0]),
                y = Int16.Parse(str[1]),
                z = Int16.Parse(str[2]),
                chieuCao = Int16.Parse(str[3]),
                banKinhDay = Int16.Parse(str[4]);

            Mode.Cylinder = new Cylinder(x, y, z, chieuCao, banKinhDay);

            ptb_3D.Refresh();
            Mode.Cylinder.Draw(ptb_3D.CreateGraphics());
        }
        private void HinhHopChuNhatProperties_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string[] str = e.PropertyName.Split(',');
            int x = Int16.Parse(str[0]),
                y = Int16.Parse(str[1]),
                z = Int16.Parse(str[2]),
                chieuDai = Int16.Parse(str[3]),
                chieuCao = Int16.Parse(str[4]),
                chieuRong = Int16.Parse(str[5]);

            Mode.Cube = new Cube(x, y, z, chieuDai, chieuCao, chieuRong);

            ptb_3D.Refresh();
            Mode.Cube.Draw(ptb_3D.CreateGraphics());
        }

        private void BTN3D_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.Equals("Cylinder"))
            {
                this.panel3.Controls.Add(Mode.cylinder_Parameter);
                Mode.cylinder_Parameter.PropertyChanged += HinhTruProperties_PropertyChanged;
                //if (Variables.Globals.flagXe == false)
                //{
                //    Variables.Globals.hinhTruProperties.Refresh();
                //}

                Mode.cylinder_Parameter.BringToFront();
                Mode.cylinder_Parameter.Visible = true;
                Mode.cube_Parameter.Visible = false;
            }
            else if (btn.Tag.Equals("Cube"))
            {
                this.panel3.Controls.Add(Mode.cube_Parameter);
                Mode.cube_Parameter.PropertyChanged += HinhHopChuNhatProperties_PropertyChanged;
                //if (Variables.Globals.flagXe == false)
                //{
                //    Variables.Globals.hinhHopChuNhatProperties.Refresh();
                //}

                Mode.cube_Parameter.BringToFront();
                Mode.cube_Parameter.Visible = true;
                Mode.cylinder_Parameter.Visible = false;
            }
        }

        private void mode3D1_Load(object sender, EventArgs e)
        {
            //this.pnl_ToolBox.Controls.Add(Mode.cylinder_Parameter);
            Mode.cylinder_Parameter.PropertyChanged += HinhTruProperties_PropertyChanged;
            //if (Variables.Globals.flagXe == false)
            //{
            //    Variables.Globals.hinhTruProperties.Refresh();
            //}

            Mode.cylinder_Parameter.BringToFront();
            Mode.cylinder_Parameter.Visible = true;
            Mode.cube_Parameter.Visible = false;
        }


        private void btn_cube_Click_1(object sender, EventArgs e)
        {
            //this.pnl_ToolBox.Controls.Add(Mode.cube_Parameter);
            //Mode.cube_Parameter.PropertyChanged += HinhHopChuNhatProperties_PropertyChanged;
            //if (Variables.Globals.flagXe == false)
            //{
            //    Variables.Globals.hinhHopChuNhatProperties.Refresh();
            //}

            //Mode.cube_Parameter.BringToFront();
            //Mode.cube_Parameter.Visible = true;
            //Mode.cylinder_Parameter.Visible = false;


            groupBox1.Hide();
            cube_Parameter1.Show();
            cube_Parameter1.Dock = DockStyle.Right;
            cube_Parameter1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mode.cylinder_Parameter.PropertyChanged += HinhTruProperties_PropertyChanged;
            //if (Variables.Globals.flagXe == false)
            //{
            //    Variables.Globals.hinhTruProperties.Refresh();
            //}

            //Mode.cylinder_Parameter.BringToFront();
            //Mode.cylinder_Parameter.Visible = true;
            //Mode.cube_Parameter.Visible = false;


            groupBox1.Hide();
            cylinder_Parameter1.Show();
            cylinder_Parameter1.Dock = DockStyle.Right;
            cylinder_Parameter1.BringToFront();
        }

        private void cylinder_Parameter1_Load(object sender, EventArgs e)
        {

        }

        private void cube_Parameter1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_3D_Click(object sender, EventArgs e)
        {
            ptb_2D.Hide();
            //Picb_3DArea_Paint(e1);
            user_Mode2D1.Hide();
            ptb_3D.Show();
            ptb_3D.Dock = DockStyle.Fill;
            ptb_3D.BringToFront();
            groupBox1.Show();
            groupBox1.Dock = DockStyle.Right;
            groupBox1.BringToFront();
        }
    }
}
