using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.ham
{
    public static class Globals
    {
        public static System.Drawing.Size _2d;
        public static System.Drawing.Size sizePerPoint = new System.Drawing.Size(5, 5);
        public static bool _btn_isShowDetails = true;

        public static int i = 0;
        public static System.Drawing.Size sizeOfNewCoor_2D;
        public static System.Drawing.Size sizeOfNewCoor_3D;
        public static Stack<Object> sObject_2D = new Stack<object>();
       
        private static Xe xe;
        internal static Xe Xe { get => xe; set => xe = value; }


        private static Cay cay;
        internal static Cay Cay { get => cay; set => cay = value; }

        public static bool flagXe = false;
        //public static Clock clock;


        //public static XeProperties xe;
        //public static HinhHopChuNhatProperties hinhHopChuNhatProperties;
        //public static ClockProperties clockProperties;
    }
}
