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
namespace KTDH
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
            ptb_2D.Hide();
            this.timer1.Start();
            hienThiMode();
        }


        private void Form_main_Load(object sender, EventArgs e)
        {
            ham.Globals._2d.Width = traGiaTriChan(ptb_2D.Width / ham.Globals.sizePerPoint.Width);
            ham.Globals._2d.Height = traGiaTriChan(ptb_2D.Height / ham.Globals.sizePerPoint.Height);
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

            int width = ham.Globals._2d.Width,
                height = ham.Globals._2d.Height;

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
            ham.Globals._2d.Width = traGiaTriChan(ptb_2D.Width / ham.Globals.sizePerPoint.Width);
            ham.Globals._2d.Height = traGiaTriChan(ptb_2D.Height / ham.Globals.sizePerPoint.Height);

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
        private void update()
        {
            for (int i = 0; i < 25; i++)
            {
                thongTinXe1.lsPointXe[i] = ham.Globals.Xe.lsPoint[i];
                thongTinXe1.lsPointCay[i] = ham.Globals.Cay.lsPoint[i];
            }
            thongTinXe1.bankinh = ham.Globals.Xe.BkBanh;
            thongTinXe1.lopxe = ham.Globals.Xe.LopXe;

            thongTinXe1.ChieuCao_la = ham.Globals.Cay.ChieuCao_la;
            thongTinXe1.ChieuRong_la = ham.Globals.Cay.ChieuRong_la;
            thongTinXe1.bk_tao = ham.Globals.Cay.Bk_tao;
            thongTinXe1.HienThiThongTin();
        }
        private void ptb_2D_Paint(object sender, PaintEventArgs e)
        {
            if (ham.Globals.flagXe)       // cờ xe = true => hiện xe 
            {          
                if (dem < 75)
                {
                    ham.Globals.Xe.tinhTienXe(10, 0);
                    ham.Globals.Xe.quayBanhXe(-30);
                    ham.Globals.Xe.Draw(e.Graphics);
                    ham.Globals.Cay.Draw(e.Graphics);
                    update();
                    dem +=1;
                    if (dem >= 75) dem = 150;
                }
                else if (dem <= 150)
                {
                    ham.Globals.Cay.taoRoi(0, 5);
                    ham.Globals.Xe.tinhTienXe(-10, 0);
                    ham.Globals.Xe.quayBanhXe(30);
                    ham.Globals.Xe.Draw(e.Graphics);
                    ham.Globals.Cay.Draw(e.Graphics);
                    update();
                    dem -= 1;
                    if (dem < 75)
                    {
                        dem = 0;
                        ham.Globals.Cay.LsPoint[4] =new  Point(1260, 140);
                        ham.Globals.Cay.LsPoint[5] = new Point(1260, 120);
                        ham.Globals.Cay.LsPoint[6] = new Point(1240, 100);
                        ham.Globals.Cay.LsPoint[7] = new Point(1260, 100);
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
            if (ham.Globals.flagXe ==true&& flagxe2 == false)
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

        }
    }
}
