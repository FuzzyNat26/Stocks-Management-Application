using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek_UAS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //Click untuk stocks
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Add_Stocks();
            stocks.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Add_Stocks();
            stocks.Show();
        }

        //Click untuk Users
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Users = new Users();
            Users.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Users = new Users();
            Users.Show();
        }

        //Click untuk Dealers
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Dealers = new Dealers();
            Dealers.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Dealers = new Dealers();
            Dealers.Show();
        }

        //Click untuk Sales
        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Sales = new Sales();
            Sales.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Sales = new Sales();
            Sales.Show();
        }
    }
    
}
