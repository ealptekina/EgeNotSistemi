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
namespace EgeNotSistemi
{
    public partial class FrmOgrenciGiris : Form
    {
        public FrmOgrenciGiris()
        {
            InitializeComponent();
        }

        DbContext dbContext = new DbContext();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbContext.Adres);
            conn.Open();
            SqlCommand komutGiris = new SqlCommand("select * from Ogrenci where OkulNo=@a1 and Sifre=@a2", conn);
            komutGiris.Parameters.AddWithValue("@a1", textBox1.Text);
            komutGiris.Parameters.AddWithValue("@a2",textBox2.Text);

            SqlDataReader dr = komutGiris.ExecuteReader();

            // Eğer eşleşen kayıt bulunursa giriş başarılı
            if (dr.Read())
            {
                FrmOgrenci frmOgrenci = new FrmOgrenci();
                frmOgrenci.numara = textBox1.Text; // Girişteki okul numarasını aktar
                frmOgrenci.Show();
                this.Hide(); // Şu anki formu gizle
            }
            else
            {
                //Hatalı giriş mesajı verilir
                MessageBox.Show("Hatalı Giriş. Lütfen Bilgilerinizi Kontrol Ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmOgrNotSis frmOgrNotSis = new FrmOgrNotSis();
            frmOgrNotSis.Show();
            this.Hide();
        }

    }
}
