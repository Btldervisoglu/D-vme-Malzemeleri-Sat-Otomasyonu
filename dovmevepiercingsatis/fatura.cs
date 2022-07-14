using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace dovmevepiercingsatis
{
    public partial class fatura : Form
    {
        public fatura()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kullanici.mdb");
        private void fatura_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kayit where ad LIKE'" + textBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox1.Text = okuyucu["ad"].ToString();
                textBox2.Text = okuyucu["soyad"].ToString();
                textBox3.Text = okuyucu["eposta"].ToString();
                
            }
            baglanti.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" )
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi doldurunuz.");
            }
            else
            {
                MessageBox.Show("Siparişiniz Onaylanmıştır. 2-3 iş günü içerisinde mail adresinizi kontrol etmeyi unutmayın");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            profil pr = new profil();
            pr.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
