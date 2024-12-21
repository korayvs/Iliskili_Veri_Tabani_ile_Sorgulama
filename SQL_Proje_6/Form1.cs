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

namespace SQL_Proje_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-F1A12T8\KORAY;Initial Catalog=Proje6;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Execute Proje6", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand urun = new SqlCommand("Select * From URUNLER", baglanti);
            SqlDataAdapter da1 = new SqlDataAdapter(urun);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            CmbUrun.ValueMember = "ID";           
            CmbUrun.DisplayMember = "AD";
            CmbUrun.DataSource = dt1;
            CmbUrun.SelectedIndex = -1;

            SqlCommand musteri = new SqlCommand("Select * From MUSTERILER", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(musteri);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            CmbMusteri.ValueMember = "ID";
            CmbMusteri.DisplayMember = "ADSOYAD";
            CmbMusteri.DataSource = dt2;
            CmbMusteri.SelectedIndex = -1;

            SqlCommand personel = new SqlCommand("Select * From PERSONELLER", baglanti);
            SqlDataAdapter da3 = new SqlDataAdapter(personel);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            CmbPersonel.ValueMember = "ID";
            CmbPersonel.DisplayMember = "AD";
            CmbPersonel.DataSource = dt3;
            CmbPersonel.SelectedIndex = -1;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into HAREKETLER (URUN, MUSTERI, PERSONEL, FIYAT) Values (@p1, @p2, @p3, @p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", CmbUrun.SelectedValue);
            komut.Parameters.AddWithValue("@p2", CmbMusteri.SelectedValue);
            komut.Parameters.AddWithValue("@p3", CmbPersonel.SelectedValue);
            komut.Parameters.AddWithValue("@p4", TxtFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
