using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void BtnKulup_Click(object sender, EventArgs e)
        {
            FrmKulüpİşlemleri fr = new FrmKulüpİşlemleri();
            fr.Show();
            this.Hide();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }
    }
}
