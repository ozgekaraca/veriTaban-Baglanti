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

namespace veriTabanıBaglanti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        DataSet ds;
        SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            getir();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getir();
        }

        public void getir()
        {
            connection = new SqlConnection("server=DESKTOP-B4IN8OK\\SQLEXPRESS; Initial Catalog=Okul; Integrated Security=true"); //seçilen db'ye bağlanma
            dataAdapter = new SqlDataAdapter("Select * from okulTablosu", connection); //ürünleri getir
            ds = new DataSet(); //verilerin depolandığı alan oluşturma
            connection.Open(); //bağlanma kodu
            dataAdapter.Fill(ds, "okulTablosu");
            dataGridView1.DataSource = ds.Tables["okulTablosu"];
            connection.Close();

        }


        private void buttonGuncelle_Click(object sender, EventArgs e) //güncelleme butonu
        {
            cmd = new SqlCommand();
            connection.Open();
            cmd.Connection = connection;
            cmd.CommandText = "update okulTablosu set isim='" + textBoxIsim.Text + "',soyad='" + textBoxSoyad.Text + "',telefon='" + textBoxTelefon.Text + "',adres='" + textBoxAdres.Text + "' where id=" + textBoxId.Text + "";
            cmd.ExecuteNonQuery(); 
            connection.Close();
            getir();

        }

        private void buttonSil_Click(object sender, EventArgs e)  //silme butonu
        {
            cmd = new SqlCommand();
            connection.Open();
            cmd.Connection = connection;
            cmd.CommandText = "delete from okulTablosu where id=" + textBoxId.Text + "";
            cmd.ExecuteNonQuery();
            connection.Close();
            getir();
        }

        private void buttonEkle_Click(object sender, EventArgs e) //ekle butonu
        {
            cmd = new SqlCommand();
            connection.Open();
            cmd.Connection = connection;
            cmd.CommandText = "Insert into okulTablosu(id,isim,soyad,telefon,adres) values (" + textBoxId.Text + ",'" + textBoxIsim.Text + "','" + textBoxSoyad.Text + "','" + textBoxTelefon.Text + "' ,'" + textBoxAdres.Text + "')";
            cmd.ExecuteNonQuery ();
            connection.Close();
            getir();
        }
    }
}
