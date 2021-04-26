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
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

        public Dealers()
        {
            InitializeComponent();
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
            display.CommandText = "SELECT * FROM Dealers";
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
                    //Insert data to Dealers
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Dealers VALUES ('" + DealerNameBox.Text + "','" +
                                                                        DealerEmailBox.Text + "','" +
                                                                        DealerAddressBox.Text + "','" +
                                                                        DealerPhoneBox.Text + "','" +
                                                                        Inserted_By_Box.Text + "')";
                    cmd.ExecuteNonQuery();

                    //Reset text
                    DealerNameBox.Text = ""; DealerEmailBox.Text = "";
                    DealerAddressBox.Text = ""; DealerPhoneBox.Text = "";
                    Inserted_By_Box.Text = "";

                    //Refresh Table
                    display();

                    MessageBox.Show("New Dealer Added!");
                }
                else //If yes, do this
                {
                    MessageBox.Show("Oops! Try Again!");
                }
            }
        }

        //Delete dealers
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var Dealer_ID = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Dealers where Dealer_ID='" + Dealer_ID + "';";
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("User deleted!");
            }
        }
    }
}
