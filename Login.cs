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

namespace Proyek_UAS
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Users where Username='"+UsernameBox.Text+"' and Password='"+PasswordBox.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            i = Convert.ToInt32(dataTable.Rows.Count.ToString());

            if (i==0)
            {
                MessageBox.Show("This username and password does not match");
            }
            else
            {
                this.Hide();
                Form form = new Home();
                form.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
     }
}
