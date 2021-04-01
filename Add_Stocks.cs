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
    public partial class Add_Stocks : Form
    {
        public Add_Stocks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Stocks_Name = new Stocks_Name();
            Stocks_Name.Show();
        }

        private void Add_Stocks_Load(object sender, EventArgs e)
        {

        }
    }
}
