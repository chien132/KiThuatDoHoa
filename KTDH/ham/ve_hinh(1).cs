using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.ham
{
    class hinh_tron
    {
        private Point point;
        private int radius;
        private Color color;

        public Point Point
        {
            get => point;
            set
            {
                if (value != point)
                {
                    point = value;
                    OnPropertyChanged("point");
                }
            }
        }

        public int Radius
        {
            get => radius;
            set
            {
                if (value != radius)
                {
                    radius = value;
                    OnPropertyChanged("radius");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public void Drawn8Point(int x, int y, Graphics g, Color color)
        {
            ToaDo.HienThi(x + point.X, y + point.Y, g, color);
            ToaDo.HienThi(y + point.X, x + point.Y, g, color);
            ToaDo.HienThi(-x + point.X, -y + point.Y, g, color);
            ToaDo.HienThi(-y + point.X, -x + point.Y, g, color);
            ToaDo.HienThi(-x + point.X, y + point.Y, g, color);
            ToaDo.HienThi(-y + point.X, x + point.Y, g, color);
            ToaDo.HienThi(x + point.X, -y + point.Y, g, color);
            ToaDo.HienThi(y + point.X, -x + point.Y, g, color);
        }

        public hinh_tron(int bk, Point tamht, Color m)
        {
            Radius = bk;
            point = new Point(tamht.X, tamht.Y);
            color = m;
        }

        public hinh_tron(Point point, int R)
        {
            this.point = point;
            this.radius = R * 5;
            this.color = Color.Black;
        }
        public void Draw(Graphics g)
        {
            int x = 0,
             y = Radius,
             p = 3 - 2 * Radius;
            while (x <= y)
            {
                if (p < 0)
                    p = p + 4 * x - 6;
                else
                {
                    y -= 5;
                    p = p + 4 * (x - y) + 10;
                }
                Drawn8Point(x, y, g, color);
                x += 5;
            }
        }

        public void Draw(Graphics g, Color c)
        {
            FillColor(g, c);
            int x = 0,
             y = Radius,
             p = 3 - 2 * Radius;
            while (x <= y)
            {
                if (p < 0)
                    p = p + 4 * x - 6;
                else
                {
                    y -= 5;
                    p = p + 4 * (x - y) + 10;
                }
                Drawn8Point(x, y, g, color);
                x += 5;
            }
        }

        private void FillColor(Graphics g, Color c)
        {
            //Point p = ToaDo
            g.FillEllipse(new SolidBrush(c), this.point.X - radius, this.point.Y - radius, radius * 2 + 3, radius * 2 + 3);
        }

        public void Shifting(int dx, int dy)
        {
            this.Point = this.Point.tinhTien(dx, dy);
        }


    }
    class hinh_cn
    {
        private Point _a;
        private Point _b;
        private Point _c;
        private Point _d;
        private Color color;

        public Point A { get => _a; set => _a = value; }
        public Point B { get => _b; set => _b = value; }
        public Point C { get => _c; set => _c = value; }
        public Point D { get => _d; set => _d = value; }

        public void Draw(Graphics g)
        {
            duong_thang line;
            line = new duong_thang(this.A, this.B);
            line.Draw(g);
            line = new duong_thang(this.B, this.C);
            line.Draw(g);
            line = new duong_thang(this.D, this.C);
            line.Draw(g);
            line = new duong_thang(this.A, this.D);
            line.Draw(g);

        }

        public void Draw(Graphics g, Color c)
        {
            FillColor(g, c);
            duong_thang line;
            line = new duong_thang(this.A, this.B);
            line.Draw(g);
            line = new duong_thang(this.B, this.C);
            line.Draw(g);
            line = new duong_thang(this.D, this.C);
            line.Draw(g);
            line = new duong_thang(this.A, this.D);
            line.Draw(g);
        }

        public void FillColor(Graphics g, Color c)
        {
            Point[] curvePoints = { this.A, this.B, this.C, this.D };
            g.FillPolygon(new SolidBrush(c), curvePoints);
        }

        public hinh_cn(Point start, Point end)
        {
            this.A = start;
            this.B = new Point(end.X, start.Y);
            this.C = end;
            this.D = new Point(start.X, end.Y);
            this.color = Color.Black;
        }
        public hinh_cn(Point start, Point end, Color color)
        {
            this.A = start;
            this.B = new Point(end.X, start.Y);
            this.C = end;
            this.D = new Point(start.X, end.Y);
            this.color = color;
        }

        public void Init(Point start, Point end, Size sizeOfLine, Color color)
        {
            throw new NotImplementedException();
        }

        public void Rotate(Point p, double alpha)
        {
            this.A = this.A.RotateAt(p, (int)alpha);
            this.B = this.B.RotateAt(p, (int)alpha);
            this.C = this.C.RotateAt(p, (int)alpha);
            this.D = this.D.RotateAt(p, (int)alpha);

        }
        public void Scale(SizeF scaleSize)
        {
            this.A = this.A.Scale(scaleSize.Width);
            this.B = this.B.Scale(scaleSize.Width);
            this.C = this.C.Scale(scaleSize.Width);
            this.D = this.D.Scale(scaleSize.Width);

        }

        public void Shifting(int dx, int dy)
        {
            this.A = this.A.tinhTien(dx, dy);
            this.B = this.B.tinhTien(dx, dy);
            this.C = this.C.tinhTien(dx, dy);
            this.D = this.D.tinhTien(dx, dy);
        }

    }
    class duong_thang
    {
        private Point _a, _b;
        private Size sizeOfLine;
        private Color color;

        public Point A { get => _a; set => _a = value; }
        public Point B { get => _b; set => _b = value; }
        public Size SizeOfLine { get => sizeOfLine; set => sizeOfLine = value; }
        public Color ColorOfLine { get => color; set => color = value; }

        public duong_thang(Point a, Point b, Size sizeOfLine, Color color)
        {
            this.A = a;
            this.B = b;
            this.SizeOfLine = sizeOfLine;
            this.ColorOfLine = color;
        }
        public duong_thang(Point a, Point b)
        {
            this.A = a;
            this.B = b;
            this.ColorOfLine = Color.Black;
        }
        public duong_thang(Point a, Point b, Color color)
        {
            this.A = a;
            this.B = b;
            this.SizeOfLine = sizeOfLine;
            this.ColorOfLine = color;
        }
        public void SwapPoint()
        {
            Point p = this.A;
            this.A = this.B;
            this.B = p;
        }
        public void Draw(Graphics g)
        {
            this.A = ToaDo.roundPixel(this.A);
            this.B = ToaDo.roundPixel(this.B);

            int Dx = this.B.X - this.A.X,
                Dy = this.B.Y - this.A.Y,
                x = this.A.X,
                y = this.A.Y,
                p;
            // Trùng Ox
            if (this.A.X == this.B.X)
            {
                if (this.A.Y > this.B.Y)
                    SwapPoint();
                y = this.A.Y;
                while (y <= this.B.Y)
                {
                    ToaDo.HienThi(new Point(this.A.X, y), g, ColorOfLine);
                    y += 5;
                }
                return;
            }
            // Trùng Oy
            if (this.A.Y == this.B.Y)
            {
                if (this.A.X > this.B.X)
                    SwapPoint();
                x = this.A.X;
                while (x <= this.B.X)
                {
                    ToaDo.HienThi(new Point(x, this.A.Y), g, ColorOfLine);
                    x += 5;
                }
                return;
            }
            float m = (float)Dy / Dx;
            if (m > 0 && m <= 1)
            {
                if (this.A.X > this.B.X)
                {
                    SwapPoint();
                    Dx = this.B.X - this.A.X;
                    Dy = this.B.Y - this.A.Y;
                    x = this.A.X;
                    y = this.A.Y;
                }
                p = 2 * Dy - Dx;
                while (x <= this.B.X)
                {
                    ToaDo.HienThi(new Point(x, y), g, ColorOfLine);
                    x += 5;
                    if (p < 0)
                        p = p + 2 * Dy;
                    else
                    {
                        p = p + 2 * (Dy - Dx);
                        y += 5;
                    }
                }
                return;
            }
            if (m >= -1 && m < 0)
            {
                if (this.A.X > this.B.X)
                {
                    SwapPoint();
                    Dx = this.B.X - this.A.X;
                    Dy = this.B.Y - this.A.Y;
                    x = this.A.X;
                    y = this.A.Y;
                }
                p = 2 * Dy + Dx;
                while (x <= this.B.X)
                {
                    ToaDo.HienThi(new Point(x, y), g, ColorOfLine);
                    x += 5;
                    if (p < 0)
                    {
                        y -= 5;
                        p = p + 2 * (Dx + Dy);
                    }
                    else
                        p = p + 2 * Dy;
                }
                return;
            }
            if (m > 1)
            {
                if (this.A.Y > this.B.Y)
                {
                    SwapPoint();
                    Dx = this.B.X - this.A.X;
                    Dy = this.B.Y - this.A.Y;
                    x = this.A.X;
                    y = this.A.Y;
                }
                p = 2 * Dx - Dy;
                while (y <= this.B.Y)
                {
                    ToaDo.HienThi(new Point(x, y), g, ColorOfLine);
                    y += 5;
                    if (p < 0)
                        p = p + 2 * Dx;
                    else
                    {
                        x += 5;
                        p = p + 2 * (Dx - Dy);
                    }
                }
                return;
            }
            if (m < -1)
            {
                if (this.A.Y > this.B.Y)
                {
                    SwapPoint();
                    Dx = this.B.X - this.A.X;
                    Dy = this.B.Y - this.A.Y;
                    x = this.A.X;
                    y = this.A.Y;
                }
                p = 2 * Dx + Dy;
                while (y <= this.B.Y)
                {
                    ToaDo.HienThi(new Point(x, y), g, ColorOfLine);
                    y += 5;
                    if (p < 0)
                    {
                        x -= 5;
                        p = p + 2 * (Dx + Dy);
                    }
                    else
                        p = p + 2 * Dx;
                }
                return;
            }
        }
    }

    public class hinh_tamgiac
    {
        private Point point1 { get; set; }
        private Point point2 { get; set; }
        private Point point3 { get; set; }
        public hinh_tamgiac(Point point1, Point point2, Point point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }
        public void Draw(Graphics g)
        {
            duong_thang line;
            line = new duong_thang(this.point1, this.point2, Color.Black);
            line.Draw(g);
            line = new duong_thang(this.point2, this.point3, Color.Black);
            line.Draw(g);
            line = new duong_thang(this.point3, this.point1, Color.Black);
            line.Draw(g);
        }

        public void Draw(Graphics g, Color c)
        {
            FillColor(g, c);
            duong_thang line;
            line = new duong_thang(this.point1, this.point2);
            line.Draw(g);
            line = new duong_thang(this.point2, this.point3);
            line.Draw(g);
            line = new duong_thang(this.point3, this.point1);
            line.Draw(g);
        }

        public void FillColor(Graphics g, Color c)
        {

            Point[] curvePoints = { this.point1, this.point2, this.point3 };
            g.FillPolygon(new SolidBrush(c), curvePoints);
        }
    }

    class Hinh_Elip
    {
        private Point point { get; set; }
        private int a { get; set; }
        private int b { get; set; }

        private Color color { get; set; }
        public void Drawn4Point(int x, int y, Graphics g)
        {
            x = ToaDo.roundPixel(x);
            y = ToaDo.roundPixel(y);
            ToaDo.HienThi(new Point(point.X + x, point.Y + y), g, color);
            ToaDo.HienThi(new Point(point.X - x, point.Y + y), g, color);
            ToaDo.HienThi(new Point(point.X - x, point.Y - y), g, color);
            ToaDo.HienThi(new Point(point.X + x, point.Y - y), g, color);
        }
        public void Drawn4Point_3D(int x, int y, Graphics g)
        {
            if (x % 10 != 0)
            {
                ToaDo.HienThi(new Point(point.X - x, point.Y - y), g, color);
                ToaDo.HienThi(new Point(point.X + x, point.Y - y), g, color);
            }

            ToaDo.HienThi(new Point(point.X + x, point.Y + y), g, color);
            ToaDo.HienThi(new Point(point.X - x, point.Y + y), g, color);
        }
        public void Draw(Graphics g)
        {
            int x, y, fx, fy, a, b,xc,yc,a2,b2,p;
            xc = this.point.X;
            yc = this.point.Y;
            a = this.a;
            b = this.b;
            x = 0;
            y = b;
            x = 0;
            y = b;
            a2 = a * a;
            b2 = b * b;
            fx = 0;
            fy = 2 * a2 * y;
            Drawn4Point( x, y, g);
            p = (int)Math.Round(b2 - (a2 * b) + (0.25 * a2));//p=b2 - a2*b +a2/4
            while (fx < fy)
            {
                x++;
                fx += 2 * b2;
                if (p < 0)
                {
                    p += b2 * (2 * x + 3);//p=p + b2*(2x +3)
                }
                else
                {
                    y--;
                    p += b2 * (2 * x + 3) + a2 * (2 - 2 * y);//p=p +b2(2x +3) +a2(2-2y)
                    fy -= 2 * a2;
                }
                Drawn4Point(x, y, g);
            }
            p = (int)Math.Round(b2 * (x + 0.5) * (x + 0.5) + a2 * (y - 1) * (y - 1) - a2 * b2);
            //
            while (y > 0)
            {
                y--;
                fy -= 2 * a2;
                //        delay(50);
                if (p >= 0)
                {
                    p += a2 * (3 - 2 * y); //p=p +a2(3-2y)
                }
                else
                {
                    x++;
                    fx += 2 * b2;
                    p += b2 * (2 * x + 2) + a2 * (3 - 2 * y);//p=p+ b2(2x +2) + a2(3-2y)
                }
                Drawn4Point(x, y, g);
            }
        }
        public void NetDut(Graphics g)
        {
            int x, y, cx, cy, a, b;
            cx = this.point.X;
            cy = this.point.Y;
            a = this.a;
            b = this.b;
            x = 0;
            y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            Drawn4Point_3D(x, y, g);

            while (Dx <= Dy)
            {
                x += 1;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y -= 1;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                if (x % 5 == 0)
                    Drawn4Point_3D(x, ToaDo.roundPixel(y), g);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y >= 0)
            {
                y -= 1;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x += 1;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                if (x % 5 == 0)
                    Drawn4Point_3D(x, ToaDo.roundPixel(y), g);

            }
        }
        public Hinh_Elip(Point point, int a, int b, Color color)
        {
            this.point = point;
            this.a = a * 5;
            this.b = b * 5;
            this.color = color;
        }
        public Hinh_Elip(Point point, int a, int b)
        {
            this.point = point;
            this.a = a * 5;
            this.b = b * 5;
            this.color = Color.Black;
        }
    }
}
