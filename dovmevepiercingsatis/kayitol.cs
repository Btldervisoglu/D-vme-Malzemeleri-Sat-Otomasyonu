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
    public partial class kayitol : Form
    {
        public kayitol()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kullanici.mdb");


        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kayitol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi doldurunuz.");
            }
            else if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("şifreleriniz uyuşmuyor");
            }


            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into kayit (ad,soyad,eposta,kad,sifre,sifretekrar) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Aramıza Hoşgeldin");
                baglanti.Close();

                this.Hide();
                dovmemalzemeleri dvmalz = new dovmemalzemeleri();
                dvmalz.ShowDialog();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            dovmemalzemeleri dvmalz = new dovmemalzemeleri();
            dvmalz.ShowDialog();
        }
    }
}
