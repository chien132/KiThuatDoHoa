using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.ham
{
    public static class Trancsformation
    {

        public static Point ToSmall(this Point p)
        {
            return (new Point(p.X / 5 - 40, 40 - p.Y / 5));//voi x va y deu chia het cho 5
        }

        public static Point ToBig(this Point p)//nho ra lon
        {

            return (new Point(p.X * 5 + 200, 200 - 5 * p.Y));
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

        //public static double[] ConvertToMatrix(this Point p)
        //{
        //    return new double[] { p.X, p.Y, 1 };
        //}

        public static Point ConvertToPoint(this double[] matrix)
        {
            if (matrix.Length == 0 || matrix.Length > 3)
                throw new Exception("The matrix doesn't match with format");
            return new Point((int)matrix[0], (int)matrix[1]);
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

        public static Point Translate(this Point d1, int dx, int dy)
        {
            double[] arr = new double[3];
            double[,] matrix = new double[3, 3];

            arr = d1.ConvertToMatrix();
            matrix = matrix.SetUpForMatrixTranslate(new Point(dx, dy));
            Point p = GetNewPointByMulMatixs(matrix, arr);

            return p;
        }


    }
}
