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
    public partial class Dealers : Form
    {
        //Establish connection with database
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Proyek_UAS.Properties.Settings.InventoryConnectionString"].ToString());


        public Dealers()
        {
            InitializeComponent();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Run when loading
        private void Dealers_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            display();

            Inserted_By_Box.Text = User_Log.Username;
        }

        //Display
        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT Dealer_ID, Dealer_Name, Email_Address, Address, Telephone, Inserted_By FROM Dealers WHERE Status='TRUE'";
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

        //Add Dealers
        private void addButton_Click(object sender, EventArgs e)
        {
            //Do all textbox filled
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //If no, do this
            {
                MessageBox.Show("All input must be filled!");
            }
            else //if yes, do this
            {
                LinkedList<string> confirm = new LinkedList<string>();
                confirm.AddLast("Dealer Name:");
                confirm.AddLast(DealerNameBox.Text);
                confirm.AddLast("Dealer Email Address:");
                confirm.AddLast(DealerEmailBox.Text);
                confirm.AddLast("Dealer Address:");
                confirm.AddLast(DealerAddressBox.Text);
                confirm.AddLast("Dealer Phone Number:");
                confirm.AddLast(DealerPhoneBox.Text);
                confirm.AddLast("Inserted By:");
                confirm.AddLast(Inserted_By_Box.Text);

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
                    check.CommandText = "SELECT Dealer_Name FROM Dealers WHERE Dealer_Name='" + DealerNameBox.Text + "'";
                    check.ExecuteNonQuery();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(check);
                    dataAdapter.Fill(dataTable);
                    i = Convert.ToInt32(dataTable.Rows.Count.ToString());

                    if (i == 0) //If no, do this
                    {
                        //Insert data to Dealers
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Dealers VALUES ('" + DealerNameBox.Text + "','" +
                                                                            DealerEmailBox.Text + "','" +
                                                                            DealerAddressBox.Text + "','" +
                                                                            DealerPhoneBox.Text + "','" +
                                                                            Inserted_By_Box.Text + "','" +
                                                                            "TRUE" + "')";
                        cmd.ExecuteNonQuery();

                        //Reset text
                        DealerNameBox.Text = ""; DealerEmailBox.Text = "";
                        DealerAddressBox.Text = ""; DealerPhoneBox.Text = "";

                        //Refresh Table
                        display();

                        MessageBox.Show("New Dealer Added!");
                    }
                    else //If yes, do this
                    {
                        MessageBox.Show("Oops! Try Again!");
                    }
                }
                else //If there is the same username, do this
                {
                    MessageBox.Show("There is a similar or disabled dealer name." + Environment.NewLine + "Try change to a new dealer name!");
                }
            }
        }

        //Delete dealers
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to disable this dealer?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var Dealer_ID = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Dealers SET Status='FALSE' WHERE Dealer_ID='" + Dealer_ID + "';";
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("Dealer disabled!");
            }
        }
    }
}
