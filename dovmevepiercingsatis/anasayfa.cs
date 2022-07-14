using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dovmevepiercingsatis
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dovmemalzemeleri dvmalz = new dovmemalzemeleri();
            dvmalz.ShowDialog();
            
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Text = "ÜRÜNLERE GÖZ AT";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Text = "HOŞGELDİNİZ";
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
