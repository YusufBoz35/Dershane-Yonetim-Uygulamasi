using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_Okul
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JPBDURM\\SQLEXPRESS;Initial Catalog=Okul_DB;Integrated Security=True");

        public string numara;

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM Tbl_Notlar INNER JOIN Tbl_Dersler ON Tbl_Notlar.DERSID = Tbl_Dersler.DERSID WHERE OGRID= @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            
            
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT OGRAD FROM Tbl_Ogrenci WHERE OGRID = @p2", baglanti);
            komut2.Parameters.AddWithValue("@p2",Convert.ToInt32(numara) );
            SqlDataReader dr = komut2.ExecuteReader();
            string mesaj = "";
            while(dr.Read())
            {
                  mesaj = dr[0].ToString();
            }
            this.Text =mesaj;
            
            baglanti.Close();

        }
    }
}
