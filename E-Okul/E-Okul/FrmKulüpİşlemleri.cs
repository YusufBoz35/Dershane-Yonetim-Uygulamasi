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
    public partial class FrmKulüpİşlemleri : Form
    {
        public FrmKulüpİşlemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-JPBDURM\\SQLEXPRESS;Initial Catalog=Okul_DB;Integrated Security=True");
       
        
        void listele()
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("SELECT KULUPID,KULUPAD FROM Tbl_Kulup", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }
        
        
        
        private void FrmKulüpİşlemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Kulup (KULUPAD) VALUES (@p1)",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("kulup listeye eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();
            listele();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Black;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Pink;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Delete FROM Tbl_Kulup WHERE KULUPID = @p1",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("kulup listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Kulup SET KULUPAD = @p1 WHERE KULUPID = @p2 ",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKulupId.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            listele();
            MessageBox.Show("kulup güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
