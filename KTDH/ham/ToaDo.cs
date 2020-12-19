using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace KTDH.ham
{
    public static class ToaDo
    {
        // tọa độ người dùng nhập từ ngoài 
        public static Point toaDoNguoiDung_2D(Point p)
        {
            int width = ham.Mode._2d.Width,
                height = ham.Mode._2d.Height,
                x = p.X,
                y = p.Y;
            x = x > 0 ? (x + width / 2) * 5 : (width / 2 - Math.Abs(x)) * 5;
            y = y > 0 ? (height / 2 - y) * 5 : y = (height / 2 + Math.Abs(y)) * 5;
            return new Point(x, y);
        }
        // tọa độ máy tính trả ra ngoài màn hình
        public static Point toaDoMayTinh_2D(Point p)
        {
            p = roundPixel(p);
            int width = ham.Mode._2d.Width,
                height = ham.Mode._2d.Height,
                x = p.X / 5,
                y = p.Y / 5;
            x = x > width / 2 ? x - width / 2 : (width / 2 - x) * -1;
            y = y > height / 2 ? (height / 2 - y) : height / 2 - y;
            //Console.WriteLine(p.X + "," + p.Y + " to " + x + " " + y);
            return new Point(x, y);
        }
        /// Làm tròn tọa độ khi hiển thị trên lưới pixel.
        public static Point roundPixel(Point p)
        {
            int x = p.X % 5,
                y = p.Y % 5;
            x = x >= 3 ? (p.X - x + 5) : (p.X - x);
            y = y >= 3 ? (p.Y - y + 5) : (p.Y - y);
            return new Point(x, y);
        }
        public static int roundPixel(int p)
        {
            int d = p % 5;
            if (d >= 3)
                return (int)(p - d + 5);

            return (int)(p - d);
        }
        public static void HienThi(Point p, Graphics g, Color color)
        {
            if (g == null)
                return;
            SolidBrush b = new SolidBrush(color);
            g.FillRectangle(b, p.X - 2, p.Y - 2, 5, 5);

        }
        public static void HienThi(int x, int y, Graphics g, Color color)
        {
            if (g == null)
                return;
            Point p = new Point(x, y);
            SolidBrush b = new SolidBrush(color);
            g.FillRectangle(b, p.X - 2, p.Y - 2, 5, 5);
        }
        public static double[] ConvertToMatrix(this Point p)
        {
            return new double[] { p.X, p.Y, 1 };
        }
        private static double[,] SetUpForMatrixTranslate(this double[,] matrix, Point d)
        {
            if (matrix.Length == 0 || matrix == null)
            {
                matrix = new double[3, 3] {
                   { 1, 0, d.X},
                   { 0, 1, d.Y},
                   { 0, 0, 1}
                };
                return matrix;
            }

            matrix[0, 0] = 1; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = 0; matrix[1, 1] = 1; matrix[1, 2] = 0;
            matrix[2, 0] = d.X; matrix[2, 1] = d.Y; matrix[2, 2] = 1;
            return matrix;
        }
        public static Point GetNewPointByMulMatixs(double[,] matran, double[] mang)
        {
            //Multiply two matrics: 3x3 and 3x1. Else => result false.
            double[] mangtam;
            mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        public static Point tinhTien(this Point d1, int dx, int dy)
        {
            double[] arr = new double[3];
            double[,] matrix = new double[3, 3];

            arr = ConvertToMatrix(d1);
            matrix = SetUpForMatrixTranslate(matrix, new Point(dx, dy));
            Point p = GetNewPointByMulMatixs(matrix, arr);

            return p;
        }
        private static double[,] SetUpForMatrixScale(this double[,] matrix, double x)
        {
            if (matrix.Length == 0 || matrix == null)
            {
                matrix = new double[3, 3] {
                   { 1, 0, 0},
                   { 0, 1, 0},
                   { 0, 0, 1}
                };
                return matrix;
            }

            matrix[0, 0] = x; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = 0; matrix[1, 1] = x; matrix[1, 2] = 0;
            matrix[2, 0] = 0; matrix[2, 1] = 0; matrix[2, 2] = 1;
            return matrix;
        }
        public static Point Scale(this Point d1, double x)
        {
            double[] arr = new double[3];
            double[,] matrix = new double[3, 3];

            arr = d1.ConvertToMatrix();
            matrix = matrix.SetUpForMatrixScale(x);
            Point p = GetNewPointByMulMatixs(matrix, arr);

            return p;
        }

        private static double[,] SetUpForMatrixTransToOriCoor(this double[,] matrix, Point p)
        {
            if (matrix.Length == 0 || matrix == null)
            {
                matrix = new double[3, 3] {
                   { 1, 0, 0},
                   { 0, 1, 0},
                   { -p.X, -p.Y, 1}
                };
                return matrix;
            }

            matrix[0, 0] = 1; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = 0; matrix[1, 1] = 1; matrix[1, 2] = 0;
            matrix[2, 0] = -p.X; matrix[2, 1] = -p.Y; matrix[2, 2] = 1;
            return matrix;
        }

        private static double[,] SetUpForMatrixRotate(this double[,] matrix, int alpha)
        {
            double s = Math.Sin((Math.PI * alpha) / 180),
                    c = Math.Cos((Math.PI * alpha) / 180);

            if (matrix.Length == 0 || matrix == null)
            {
                matrix = new double[3, 3] {
                   { c, -s, 0},
                   { s, c, 0},
                   { 0, 0, 1}
                };
                return matrix;
            }

            matrix[0, 0] = c; matrix[0, 1] = -s; matrix[0, 2] = 0;
            matrix[1, 0] = s; matrix[1, 1] = c; matrix[1, 2] = 0;
            matrix[2, 0] = 0; matrix[2, 1] = 0; matrix[2, 2] = 1;
            return matrix;
        }

        public static Point RotateAt(this Point d1, Point d2, int alpha)
        {
            int xo, yo;
            xo = d2.X; yo = d2.Y;

            double[] mang = new double[3];

            double[,] matran1 = new double[3, 3],
                      matran2 = new double[3, 3],
                      matran3 = new double[3, 3];

            matran1.SetUpForMatrixTransToOriCoor(d2);
            mang = d1.ConvertToMatrix();

            Point pt = GetNewPointByMulMatixs(matran1, mang);

            matran2.SetUpForMatrixRotate(alpha);
            mang = pt.ConvertToMatrix();

            Point pt1 = GetNewPointByMulMatixs(matran2, mang);

            // ma tran doi diem ve toa do cu
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;

            mang = pt1.ConvertToMatrix();
            Point pt2 = GetNewPointByMulMatixs(matran3, mang);
            Point kq = pt2;
            return kq;
        }


        //3D toa do

        public static int RoundPixel(int p)
        {
            int d = p % 5;
            if (d >= 3)
                return (int)(p - d + 5);

            return (int)(p - d);
        }

        public static Point RoundPixel(Point p)
        {
            int x = p.X % 5,
                y = p.Y % 5;

            x = (x >= 3 ? p.X - x + 5 : p.X - x);
            y = (y >= 3 ? p.Y - y + 5 : p.Y - y);

            return new Point(x, y);
        }


        /// Chuyển từ tọa độ máy tính về tọa độ người dùng trong 3D
        public static Point MayTinhNguoiDung_3D(Point p)
        {
            p = RoundPixel(p);
            int width = Mode.sizeOfNewCoor_3D.Width,
                height = Mode.sizeOfNewCoor_3D.Height,
                x = p.X / 5,
                y = p.Y / 5;

            x = x > width * 2 / 5 ? x - width * 2 / 5 : (width * 2 / 5 - x) * -1;
            y = y > height / 2 ? (height / 2 - y) : height / 2 - y;

            return new Point(x, y);
        }


        /// Chuyển điểm 3D về điểm 2D dùng Cavalier
        /// </summary>
        /// <param name="X">Tọa độ trên Ox</param>
        /// <param name="Y">Tọa độ trên Oy</param>
        /// <param name="Z">Tọa độ trên Oz</param>
        /// <param name="Xp">Tọa độ đã chuyển trên Ox</param>
        /// <param name="Yp">Tọa độ đã chuyển trên Oy</param>
        public static Point Chuyen3DThanh2D(float X, float Y, float Z)
        {
            float alpha = (float)Math.PI / 4,
                  phi = (float)Math.PI / 4,
                  L,
                  Xp,
                  Yp;
            L = Z / (float)Math.Tan(alpha);
            //Xp = (float)(X + L * (float)Math.Cos(phi));
            //Yp = (float)(Y + L * (float)Math.Sin(phi));


            Xp = (float)(X - (float)Z * Math.Sqrt(2) / 2);
            Yp = (float)(Y - (float)Z * Math.Sqrt(2) / 2);

            return new Point((int)Xp, (int)Yp);
        }



        public static Point NguoiDungMayTinh_3D(int X, int Y, int Z)
        {
            Point point = new Point();
            point = Chuyen3DThanh2D(X, Y, Z);
            int width = Mode.sizeOfNewCoor_3D.Width,
                height = Mode.sizeOfNewCoor_3D.Height,
                x = point.X,
                y = point.Y;

            x = x > 0 ? (x + width * 2 / 5) * 5 : (width * 2 / 5 - Math.Abs(x)) * 5;
            y = y > 0 ? (height / 2 - y) * 5 : y = (height / 2 + Math.Abs(y)) * 5;

            return new Point(x, y);
        }

        public static void HienThi1(Point p, Graphics g, Color color)
        {
            if (g == null)
                return;
            int pointX = RoundPixel(p.X),
                pointY = RoundPixel(p.Y);
            // Pen p1 = new Pen(Color.Green);
            SolidBrush b = new SolidBrush(color);

            g.FillRectangle(b, p.X - 2, p.Y - 2, 5, 5);
        }
    }

}
