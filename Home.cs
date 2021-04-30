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

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Hello <log in user>
        private void Home_Load(object sender, EventArgs e)
        {
            label6.Text = "Hello " + User_Log.Username;
        }

        //To Users
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

        //To Dealers
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

        //To Products
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Purchase_Product();
            stocks.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Purchase_Product();
            stocks.Show();
        }

        //To Sales
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

        //Log Out
        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Login = new Login();
            Login.Show();
        }

        //Team Member Page
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Team_Member = new Team_Member();
            Team_Member.Show();
        }
    }
}
