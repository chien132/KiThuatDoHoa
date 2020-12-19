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
    public partial class user_Mode2D : UserControl
    {
        public user_Mode2D()
        {
            InitializeComponent();
        }
        private void btn_xe_Click(object sender, EventArgs e)
        {
            ham.Globals.Xe = new Xe();
            ham.Globals.Cay = new Cay();

            if (ham.Globals.flagXe)
            {
                ham.Globals.flagXe = false;
            }
            else ham.Globals.flagXe = true;
        }

    }
}
