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
    public partial class Team_Member : Form
    {
        public Team_Member()
        {
            InitializeComponent();
        }

        //Back Button
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

    }
}
