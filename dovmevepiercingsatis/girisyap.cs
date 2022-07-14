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
    public partial class girisyap : Form
    {
        public girisyap()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kullanici.mdb");
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide(); 
            kayitol kol = new kayitol();
            kol.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi doldurunuz.");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from kayit where kad='" + textBox1.Text.ToString() + "'", baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text.ToString() == okuyucu["kad"].ToString() && textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                       
                        this.Hide();
                        profil pr = new profil();
                        pr.ShowDialog();
                        

                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı. Lütfen kontrol ediniz.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı. Lütfen kontrol ediniz.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                baglanti.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Checked )
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "gizle";
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "göster";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void girisyap_Load(object sender, EventArgs e)
        {

        }
    }
}
