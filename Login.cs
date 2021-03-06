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
using System.Configuration;

namespace Proyek_UAS
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Proyek_UAS.Properties.Settings.InventoryConnectionString"].ToString());

        public Login()
        {
            InitializeComponent();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Run when loading
        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        //Login button clicked
        private void loginButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Username, Password FROM Users WHERE Username='" + UsernameBox.Text + "' AND Password='"+ PasswordBox.Text +"' AND Status='TRUE'";
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
                User_Log.Username = UsernameBox.Text;

                this.Hide();
                Form form = new Home();
                form.Show();
            }
        }
     }
}
