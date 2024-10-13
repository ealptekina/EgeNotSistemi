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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EgeNotSistemi
{
    public partial class FrmOgrNotSis : Form
    {
        public FrmOgrNotSis()
        {
            InitializeComponent();
        }

        DbContext dbContext = new DbContext();

        void Listele()
        {
            SqlConnection conn = new SqlConnection(dbContext.Adres);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from ogrenci", dbContext.Adres);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            textBoxAd.Text = "";
            textBoxSoyad.Text = "";
            textBoxSifre.Text = "";
            textBoxOkulNo.Text = "";
            textBoxSinav1.Text = "";
            textBoxSinav2.Text = "";
            textBoxSinav3.Text = "";
            textBoxProje.Text = "";
            textBoxOrtalama.Text = "";
            textBoxDurum.Text = "";
        }
        private void FrmOgrNotSis_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbContext.Adres);
            conn.Open();
            SqlCommand komutEkle = new SqlCommand("insert into Ogrenci (OgrenciAd,OgrenciSoyad,OkulNo,Sifre) values (@d1,@d2,@d3,@d4)", conn);
            komutEkle.Parameters.AddWithValue("@d1", textBoxAd.Text);
            komutEkle.Parameters.AddWithValue("@d2", textBoxSoyad.Text);
            komutEkle.Parameters.AddWithValue("@d3", textBoxOkulNo.Text);
            komutEkle.Parameters.AddWithValue("@d4", textBoxSifre.Text);

            komutEkle.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBoxOkulNo.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBoxSifre.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBoxSinav1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBoxSinav2.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            textBoxSinav3.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            textBoxProje.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            textBoxOrtalama.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            textBoxDurum.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();

        }

        private void buttonListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbContext.Adres);
            conn.Open();
            SqlCommand komutGuncelle = new SqlCommand("update Ogrenci set Sinav1=@d1,Sinav2=@d2,Sinav3=@d3,Proje=@d4,Ortalama=@d5,Durum=@d6 where OkulNo=@d7", conn);
            komutGuncelle.Parameters.AddWithValue("@d1", textBoxSinav1.Text);
            komutGuncelle.Parameters.AddWithValue("@d2", textBoxSinav2.Text);
            komutGuncelle.Parameters.AddWithValue("@d3", textBoxSinav3.Text);
            komutGuncelle.Parameters.AddWithValue("@d4", textBoxProje.Text);
            komutGuncelle.Parameters.AddWithValue("@d5", textBoxOrtalama.Text);
            komutGuncelle.Parameters.AddWithValue("@d6", textBoxDurum.Text);
            komutGuncelle.Parameters.AddWithValue("@d7", textBoxOkulNo.Text);
            komutGuncelle.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Öğrenci Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbContext.Adres);
            conn.Open();
            SqlCommand komutSil = new SqlCommand("delete from Ogrenci where OkulNo=@p1", conn);
            komutSil.Parameters.AddWithValue("@p1", textBoxOkulNo.Text);
            komutSil.ExecuteNonQuery();


            conn.Close();

            MessageBox.Show("Öğrenci Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {

            Temizle();

        }

        private void buttonHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje, ortalama;
            s1 = Convert.ToInt16(textBoxSinav1.Text);
            s2 = Convert.ToInt16(textBoxSinav2.Text);
            s3 = Convert.ToInt16(textBoxSinav3.Text);
            proje = Convert.ToInt16(textBoxProje.Text);
            ortalama = (s1 + s2 + s3 + proje) / 4;
            textBoxOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                textBoxDurum.Text = "True";
            }
            else
            {
                textBoxDurum.Text = "False";

            }
        }
    }
}
