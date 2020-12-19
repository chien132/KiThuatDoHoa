using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTDH.UserC
{
    public partial class Cylinder_Parameter : UserControl, INotifyPropertyChanged
    {
        public Cylinder_Parameter()
        {
            InitializeComponent();
        }

        private void Cylinder_Parameter_Load(object sender, EventArgs e)
        {

        }


        private int[,] _dinh;
        public int[,] Dinh
        {
            get => _dinh;
            set
            {
                if (value != null)
                {
                    _dinh = value;
                    txtDinhA.Text = _dinh[0, 0] + "," + _dinh[0, 1] + "," + _dinh[0, 2];
                    txtDinhB.Text = value[1, 0].ToString() + "," + value[1, 1].ToString() + "," + value[1, 2].ToString();
                    txtDinhC.Text = value[2, 0].ToString() + "," + value[2, 1].ToString() + "," + value[2, 2].ToString();
                    txtDinhD.Text = value[3, 0].ToString() + "," + value[3, 1].ToString() + "," + value[3, 2].ToString();
                    txtDinhE.Text = value[4, 0].ToString() + "," + value[4, 1].ToString() + "," + value[4, 2].ToString();
                    txtDinhF.Text = value[5, 0].ToString() + "," + value[5, 1].ToString() + "," + value[5, 2].ToString();

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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        private void txtTamY_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTamX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTamZ_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtBanKinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtChieuDai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTamX_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTamZ_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;

        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            int x = Int16.Parse(txtTamX.Text),
                y = Int16.Parse(txtTamY.Text),
                z = Int16.Parse(txtTamZ.Text),
                chieuCao = Int16.Parse(txtChieuCao.Text),
                banKinhDay = Int16.Parse(txtBanKinh.Text);

            OnPropertyChanged(x + "," + y + "," + z + "," + chieuCao + "," + banKinhDay);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTamY_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtChieuCao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
