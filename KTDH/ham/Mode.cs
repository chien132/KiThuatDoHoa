using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTDH._3D;
using KTDH.UserC;

namespace KTDH.ham
{
    public static class Mode
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


        //3d

        public static Cylinder_Parameter cylinder_Parameter;
        public static Cube_Parameter cube_Parameter;

 

        /// Size của hệ tòa độ người dùng khi chuyển từ tọa độ máy sang. Hệ tòa độ 3D.
        private static Cube cube;
        private static Cylinder cylinder;
        internal static Cube Cube { get => cube; set => cube = value; }
        internal static Cylinder Cylinder { get => cylinder; set => cylinder = value; }
    }
}
