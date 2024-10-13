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
using System.Reflection.Emit;

namespace EgeNotSistemi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DbContext dbContext = new DbContext();

        public string numara,adsoyad,sinav1,sinav2,sinav3;
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            labelOkulNo.Text = numara;
            labelAdSoyad.Text = adsoyad;
            labelSinav1.Text = sinav1;
            labelSinav2.Text = sinav2;
            labelSinav3.Text = sinav3;

            SqlConnection conn = new SqlConnection(dbContext.Adres);

            conn.Open();

            SqlCommand komutGetir = new SqlCommand("select * from Ogrenci where OkulNo=@p1", conn);

            komutGetir.Parameters.AddWithValue("@p1", numara);

            SqlDataReader dr = komutGetir.ExecuteReader();

            while (dr.Read())
            {
                labelAdSoyad.Text = dr[1] + " " + dr[2];
                labelSinav1.Text = dr[5].ToString();
                labelSinav2.Text = dr[6].ToString();
                labelSinav3.Text = dr[7].ToString();
                labelProje.Text = dr[8].ToString();
                labelOrtalama.Text = dr[9].ToString();
                labelDurum.Text = dr[10].ToString();
            }
            conn.Close();
        }


    }
}
