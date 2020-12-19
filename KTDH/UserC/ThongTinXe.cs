using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTDH.ham;

namespace KTDH.UserC
{
    public partial class ThongTinXe : UserControl
    {
        public Point[] lsPointXe = new Point[25];
        public Point[] lsPointCay = new Point[25];
        public int bankinh;
        public int lopxe;

        public int ChieuCao_la = 20,
            ChieuRong_la = 16,
            bk_tao = 4;
        public int Chieucao_Ao = 20,
            Chieurong_Ao = 30;


        public ThongTinXe()
        {
            InitializeComponent();
        }

        public void HienThiThongTin()
        {


            // đổi tọa độ máy tính  sang người dùng
            for (int i = 0; i < this.lsPointXe.Length; i++)
            {
                this.lsPointXe[i] = ToaDo.toaDoMayTinh_2D(this.lsPointXe[i]);
                this.lsPointCay[i] = ToaDo.toaDoMayTinh_2D(this.lsPointCay[i]);
            }
            // in ra thông tin
            this.lbl_hcn1.Text = this.lsPointXe[2].ToString() + "," + this.lsPointXe[0].ToString();
            this.lbl_hcn2.Text = this.lsPointXe[2].ToString() + "," + this.lsPointXe[0].ToString();
            this.lbl_hcn3.Text = this.lsPointXe[9].ToString() + "," + this.lsPointXe[10].ToString();
            this.lbl_ht1.Text = this.lsPointXe[14].ToString() + " BK Bánh= " + this.bankinh + " BK Lốp= " + this.lopxe;
            this.lbl_ht2.Text = this.lsPointXe[13].ToString() + " BK Bánh= " + this.bankinh + " BK Lốp= " + this.lopxe;
            this.lbl_tg.Text = this.lsPointXe[6].ToString() + "," + this.lsPointXe[7].ToString() + "," + this.lsPointXe[8].ToString();
            this.lbl_dt1.Text = this.lsPointXe[13].ToString() + "," + this.lsPointXe[19].ToString();
            this.lbl_dt2.Text = this.lsPointXe[13].ToString() + "," + this.lsPointXe[20].ToString();
            this.lbl_dt3.Text = this.lsPointXe[13].ToString() + "," + this.lsPointXe[21].ToString();
            this.lbl_dt4.Text = this.lsPointXe[14].ToString() + "," + this.lsPointXe[22].ToString();
            this.lbl_dt5.Text = this.lsPointXe[14].ToString() + "," + this.lsPointXe[23].ToString();
            this.lbl_dt6.Text = this.lsPointXe[14].ToString() + "," + this.lsPointXe[24].ToString();

            this.lbl_caydt1.Text = this.lsPointCay[5].ToString() + "," + this.lsPointCay[6].ToString();
            this.lbl_caydt2.Text = this.lsPointCay[5].ToString() + "," + this.lsPointCay[7].ToString();
            this.lbl_thancay.Text = this.lsPointCay[0].ToString() + "," + this.lsPointCay[1].ToString() + "," + this.lsPointCay[2].ToString();
            this.lbl_cayelipse1.Text = this.lsPointCay[3].ToString() + ", Rộng: " + this.ChieuRong_la + ", Cao: " + this.ChieuCao_la;
            this.lbl_quatao.Text = this.lsPointCay[4].ToString() + " BK Táo= " + this.bk_tao;
            this.lbl_aonuoc.Text = this.lsPointCay[8].ToString() + ", Rộng: " + this.Chieurong_Ao + ", Cao: " + this.Chieucao_Ao;

        }
        #region eventrac
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dt6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_caydt1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dt4_Click(object sender, EventArgs e)
        {

        }

        private void ThongTinXe_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
