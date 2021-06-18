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
    public partial class Users : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Proyek_UAS.Properties.Settings.InventoryConnectionString"].ToString());


        public Users()
        {
            InitializeComponent();
        }

        //Run when loading
        private void Users_Load(object sender, EventArgs e)
        {
            //If connection are open, closed it
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            //Open the connection
            con.Open();

            //Call table
            display();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Method for connecting datagrid with database
        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT First_Name, Last_Name, Username, Password, Email, Phone FROM Users WHERE Status='TRUE'";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        //Return to home
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        //Add Users
        private void addButton_Click(object sender, EventArgs e)
        {
            //Do all textbox are filled?
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //Do this when there's null or empty
            {
                MessageBox.Show("All input must be filled!");
            }
            else //Do this when all textbox are filled
            {
                LinkedList<string> confirm = new LinkedList<string>();
                confirm.AddLast("First Name:");
                confirm.AddLast(FirstNameBox.Text);
                confirm.AddLast("Last Name:");
                confirm.AddLast(LastNameBox.Text);
                confirm.AddLast("Username:");
                confirm.AddLast(UsernameBox.Text);
                confirm.AddLast("Password:");
                confirm.AddLast(PasswordBox.Text);
                confirm.AddLast("Email Address:");
                confirm.AddLast(EmailBox.Text);
                confirm.AddLast("Phone Number:");
                confirm.AddLast(PhoneBox.Text);

                var Texts = "";
                foreach (var text in confirm)
                {
                    Texts += text + Environment.NewLine;
                }

                Texts = "Are all the data correct?" + Environment.NewLine + Texts;


                //Check if the datas are correct
                var confirmResult = MessageBox.Show(Texts, "Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int i = 0;

                    //Check if there are the same username
                    SqlCommand check = con.CreateCommand();
                    check.CommandType = CommandType.Text;
                    check.CommandText = "SELECT Username, Status FROM Users WHERE Username='" + UsernameBox.Text + "'";
                    check.ExecuteNonQuery();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(check);
                    dataAdapter.Fill(dataTable);
                    i = Convert.ToInt32(dataTable.Rows.Count.ToString());

                    if (i == 0) //If no, do this
                    {
                        //Insert data to Users table
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Users VALUES ('" + FirstNameBox.Text + "','"
                                                                        + LastNameBox.Text + "', '"
                                                                        + UsernameBox.Text + "', '"
                                                                        + PasswordBox.Text + "', '"
                                                                        + EmailBox.Text + "', '"
                                                                        + PhoneBox.Text + "', '"
                                                                        + "TRUE" + "')";
                        cmd.ExecuteNonQuery();

                        //Reset text
                        FirstNameBox.Text = ""; LastNameBox.Text = ""; UsernameBox.Text = "";
                        PasswordBox.Text = ""; EmailBox.Text = ""; PhoneBox.Text = "";

                        //Refresh Table
                        display();

                        //Show user added
                        MessageBox.Show("New User Added!");
                    }
                    else //If there is the same username, do this
                    {
                        MessageBox.Show("Oops! There is a similar or disabled username." + Environment.NewLine + "Try another one!");
                    }
                }
                else
                {
                    MessageBox.Show("Try again!");
                }
            }
        }

        //Delete Users
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var username = dataGridView1.SelectedCells[2].Value.ToString();
            if (User_Log.Username == username)
            {
                MessageBox.Show("You can't disable yourself!");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to disable this user?", "Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Users SET Status = 'FALSE' WHERE username='" + username + "';";
                    cmd.ExecuteNonQuery();

                    display();

                    MessageBox.Show("User disabled!");
                }
            }
        }
    }
}