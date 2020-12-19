using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace KTDH.ham
{
    class Xe
    {

        public Point[] lsPoint = new Point[25];
        private int bkBanh;
        private int bkBanh2;

        public Point[] LsPoint
        {
            get => lsPoint;
            set
            {
                lsPoint = value;
            }
        }
        public int BkBanh { get => bkBanh; set => bkBanh = value; }
        public int LopXe { get => bkBanh2; set => bkBanh2 = value; }


        public Xe()
        {
            //than xe
            LsPoint[0] = new Point(20, 0);
            LsPoint[3] = new Point(20, 200);
            LsPoint[1] = new Point(350, 0);
            LsPoint[2] = new Point(350, 200);
            //Dau xe
            LsPoint[4] = new Point(350, 200);
            LsPoint[5] = new Point(420, 70);

            LsPoint[6] = new Point(420, 70);
            LsPoint[7] = new Point(350, 70);
            LsPoint[8] = new Point(350, 20);

            //cuaxe
            LsPoint[9] = new Point(380, 80);
            LsPoint[10] = new Point(410, 100);

            // tâm bánh xe sau
            LsPoint[13] = new Point(100, 200);
            // tâm bánh xe trước
            LsPoint[14] = new Point(310, 200);

            //tăm bánh xe
            LsPoint[19] = new Point(100, 180);
            LsPoint[20] = new Point(120, 215);
            LsPoint[21] = new Point(80, 215);
            LsPoint[22] = new Point(310, 180);
            LsPoint[23] = new Point(330, 215);
            LsPoint[24] = new Point(290, 215);

            BkBanh = 25;
            LopXe = 35;

            for (int i = 0; i < 25; i++)
            {
                LsPoint[i].Y += 150;
            }

        }
        public void Draw(Graphics g)
        {
            ToMau(g);

            //than xe
            hinh_cn than = new hinh_cn(this.LsPoint[2], this.LsPoint[0]);
            than.Draw(g);
            //dauxe
            hinh_cn dauxe = new hinh_cn(this.LsPoint[4], this.LsPoint[5]);
            dauxe.Draw(g);
            dauxe.FillColor(g, Color.Orange);

            //cuaxe
            hinh_cn cuaxe = new hinh_cn(this.LsPoint[9], this.LsPoint[10]);
            cuaxe.Draw(g);
            cuaxe.FillColor(g, Color.White);

            hinh_tamgiac nocxe = new hinh_tamgiac(this.LsPoint[6], this.LsPoint[7], this.LsPoint[8]);
            nocxe.Draw(g);
            nocxe.FillColor(g, Color.Orange);

           

            //banh truoc
            hinh_tron banh_Truoc = new hinh_tron(this.BkBanh, this.LsPoint[14], Color.Black);
            banh_Truoc.Draw(g);
            hinh_tron banh_Truoc2 = new hinh_tron(this.LopXe, this.LsPoint[14], Color.Black);
            banh_Truoc2.Draw(g);

            //banh sau
            hinh_tron banh_Sau = new hinh_tron(this.BkBanh, this.LsPoint[13], Color.Black);
            banh_Sau.Draw(g);
            hinh_tron banh_Sau2 = new hinh_tron(this.LopXe, this.LsPoint[13], Color.Black);
            banh_Sau2.Draw(g);

            

            duong_thang tamTruoc1 = new duong_thang(this.LsPoint[14], this.LsPoint[22], Color.Black);
            tamTruoc1.ColorOfLine = Color.DarkRed;
            tamTruoc1.Draw(g);
            duong_thang tamTruoc2 = new duong_thang(this.LsPoint[14], this.LsPoint[23], Color.Black);
            tamTruoc2.ColorOfLine = Color.DarkRed;
            tamTruoc2.Draw(g);
            duong_thang tamTruoc3 = new duong_thang(this.LsPoint[14], this.LsPoint[24], Color.Black);
            tamTruoc3.ColorOfLine = Color.DarkRed;
            tamTruoc3.Draw(g);

            

            duong_thang tamSau1 = new duong_thang(this.LsPoint[13], this.LsPoint[19], Color.Black);
            tamSau1.ColorOfLine = Color.DarkRed;
            tamSau1.Draw(g);
            duong_thang tamSau2 = new duong_thang(this.LsPoint[13], this.LsPoint[20], Color.Black);
            tamSau2.ColorOfLine = Color.DarkRed;
            tamSau2.Draw(g);
            duong_thang tamSau3 = new duong_thang(this.LsPoint[13], this.LsPoint[21], Color.Black);
            tamSau3.ColorOfLine = Color.DarkRed;
            tamSau3.Draw(g);

            

        }
        public void ToMau(Graphics g)
        {
            SolidBrush brush3 = new SolidBrush(Color.White);
            SolidBrush brush2 = new SolidBrush(Color.Red);
            SolidBrush brush1 = new SolidBrush(Color.Gray);

            //to mau than xe
            Point[] curvePoints2 = { this.LsPoint[3], this.LsPoint[0], this.LsPoint[1], this.LsPoint[2] };
            g.FillPolygon(brush2, curvePoints2);

            //to mau banh xe
            g.FillEllipse(brush1, this.LsPoint[13].X - 36, this.LsPoint[13].Y - 36, 72, 72);
            g.FillEllipse(brush3, this.LsPoint[13].X - 26, this.LsPoint[13].Y - 26, 52, 52);
            g.FillEllipse(brush1, this.LsPoint[14].X - 36, this.LsPoint[14].Y - 36, 72, 72);
            g.FillEllipse(brush3, this.LsPoint[14].X - 26, this.LsPoint[14].Y - 26, 52, 52);

        }
        public void quayBanhXe(int goc)
        {

            LsPoint[19] = LsPoint[19].RotateAt(LsPoint[13], goc);
            LsPoint[20] = LsPoint[20].RotateAt(LsPoint[13], goc);
            LsPoint[21] = LsPoint[21].RotateAt(LsPoint[13], goc);

            LsPoint[22] = LsPoint[22].RotateAt(LsPoint[14], goc);
            LsPoint[23] = LsPoint[23].RotateAt(LsPoint[14], goc);
            LsPoint[24] = LsPoint[24].RotateAt(LsPoint[14], goc);

        }
        public void tinhTienXe(int x, int y)
        {
            for (int i = 0; i < this.LsPoint.Length; i++)
            {
                tinhTien(ref this.LsPoint[i], x, y);
            }

        }
        private void tinhTien(ref Point pn, int xDonVi, int yDonVi)
        {
            double[] matran1 = new double[3] { pn.X, pn.Y, 1 };
            // khởi tạo ma trận tịnh tiến
            double[,] matran2 = new double[3, 3] { { 1,  0 , 0 },
                                             { 0,  1 , 0 },
                                             { xDonVi,  yDonVi, 1} };

            pn = nhanMT(matran2, matran1);
        }
        private Point nhanMT(double[,] matran, double[] mang)
        {
            double[] mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
    }
    class Cay
    {
        public Point[] lsPoint = new Point[25];
        private int chieuCao_la;
        private int chieuRong_la;
        private int bk_tao;
        public Point[] LsPoint
        {
            get => lsPoint;
            set
            {
                lsPoint = value;
            }
        }
        public int ChieuCao_la { get => this.chieuCao_la; set => this.chieuCao_la = value; }
        public int ChieuRong_la { get => chieuRong_la; set => chieuRong_la = value; }
        public int Bk_tao { get => bk_tao; set => bk_tao = value; }


        public Cay()
        {
            //than cay
            LsPoint[0] = new Point(1200, 400);
            LsPoint[1] = new Point(1240, 400);
            LsPoint[2] = new Point(1220, 100);
            //La cay
            LsPoint[3] = new Point(1220, 100);
            //qua orange
            LsPoint[4] = new Point(1260, 140);
            //cuon orange
            LsPoint[5] = new Point(1260, 120);
            LsPoint[6] = new Point(1240, 100);
            LsPoint[7] = new Point(1260, 100);
            ChieuCao_la = 20;
            ChieuRong_la = 16;
            bk_tao = 4;
        }

        public void Draw(Graphics g)
        {
            ToMau(g);
            //than xe
            hinh_tamgiac than = new hinh_tamgiac(this.LsPoint[0], this.LsPoint[1], this.LsPoint[2]);
            than.Draw(g);
            //la cay
            Hinh_Elip elip = new Hinh_Elip(this.LsPoint[3], ChieuRong_la, ChieuCao_la);
            elip.Draw(g);
            //qua orange
            hinh_tron tron = new hinh_tron(this.lsPoint[4], bk_tao);
            tron.Draw(g);
            //cuon orange 
            duong_thang duong1 = new duong_thang(this.lsPoint[5], this.lsPoint[6]);
            duong1.Draw(g);
            duong_thang duong2 = new duong_thang(this.lsPoint[5], this.lsPoint[7]);
            duong2.Draw(g);

        }
        public void ToMau(Graphics g)
        {
            SolidBrush brush3 = new SolidBrush(Color.Orange);
            SolidBrush brush2 = new SolidBrush(Color.Green);
            SolidBrush brush1 = new SolidBrush(Color.Brown);

            //to mau than xe
            Point[] curvePoints1 = {this.LsPoint[0], this.LsPoint[1], this.LsPoint[2] };
            g.FillEllipse(brush2, this.LsPoint[3].X - 80, this.LsPoint[2].Y - 100, ChieuRong_la * 10, ChieuCao_la * 10);
            g.FillPolygon(brush1, curvePoints1);
            g.FillEllipse(brush3, this.LsPoint[4].X - 20, this.LsPoint[4].Y - 20, 40,40);
            //to mau banh xe
            //g.FillEllipse(brush3, this.LsPoint[14].X - 26, this.LsPoint[14].Y - 26, 52, 52);
        }
        public void taoRoi(int x, int y)
        {
            for (int i = 4; i <= 7; i++)
            {
                tinhTien(ref this.LsPoint[i], x, y);
            }

        }
        private void tinhTien(ref Point pn, int xDonVi, int yDonVi)
        {
            double[] matran1 = new double[3] { pn.X, pn.Y, 1 };
            // khởi tạo ma trận tịnh tiến
            double[,] matran2 = new double[3, 3] { { 1,  0 , 0 },
                                             { 0,  1 , 0 },
                                             { xDonVi,  yDonVi, 1} };

            pn = nhanMT(matran2, matran1);
        }
        private Point nhanMT(double[,] matran, double[] mang)
        {
            double[] mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
    }
}
