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
    public partial class profil : Form
    {
        public profil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti =new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = kullanici.mdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        
        private void profil_Load(object sender, EventArgs e)
        {

        }
        private void listele()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new OleDbCommand("select * from sepet ", baglanti);
            adtr = new OleDbDataAdapter(komut);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fatura ft = new fatura();
            ft.label2.Text = textBox2.Text;
            ft.label14.Text = textBox6.Text;
            ft.ShowDialog();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from satin where stokno LIKE'" + textBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox5.Text = okuyucu["fiyat"].ToString();
                
                textBox3.Text = okuyucu["tur"].ToString();
                textBox4.Text = okuyucu["aciklama"].ToString();
                textBox1.Text = okuyucu["stokno"].ToString();
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            komut = new OleDbCommand("insert into sepet (fiyat,tur,aciklama,stokno)values('" + textBox5.Text.ToString() + "','" +textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+ textBox1.Text.ToString()+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new OleDbCommand  ("DELETE FROM sepet where stokno ='" + textBox1.Text.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            dataGridView1.DataSource = tablo;
            
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox6.Text = toplam.ToString();
            baglanti.Close();
            listele();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            dovmemalzemeleri dvmal = new dovmemalzemeleri();
            dvmal.ShowDialog();
        }
    }
}
