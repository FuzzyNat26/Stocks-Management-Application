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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                            AttachDbFilename=C:\PROJECT C DRIVE\VS 2019\Proyek UAS\Inventory.mdf;
                            Integrated Security=True");
        public Users()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Apakah semua control berbentuk textbox berisi?
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //Apabila ada yang tidak diisi, lakukan ini
            {
                MessageBox.Show("All input must be filled!");
            }
            else //Apabila semua berisi, lakukan ini
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

                    //Membuat command untuk mencari apakah ada username yang sama
                    SqlCommand check = con.CreateCommand();
                    check.CommandType = CommandType.Text;
                    check.CommandText = "SELECT * from Users where Username='" + UsernameBox.Text + "'";
                    check.ExecuteNonQuery();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(check);
                    dataAdapter.Fill(dataTable);
                    i = Convert.ToInt32(dataTable.Rows.Count.ToString());

                    if (i == 0) //Apabila tidak ada, lanjut ke sini.
                    {
                        //Insert data yang ada di textbox ke dalam database
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Users VALUES ('" + FirstNameBox.Text + "','"
                                                                        + LastNameBox.Text + "', '"
                                                                        + UsernameBox.Text + "', '"
                                                                        + PasswordBox.Text + "', '"
                                                                        + EmailBox.Text + "', '"
                                                                        + PhoneBox.Text + "')";
                        cmd.ExecuteNonQuery();

                        //Menghapus teks yang ada di textbox
                        FirstNameBox.Text = ""; LastNameBox.Text = ""; UsernameBox.Text = "";
                        PasswordBox.Text = ""; EmailBox.Text = ""; PhoneBox.Text = "";

                        //Refresh Table
                        display();

                        //Menunjukkan data sudah added
                        MessageBox.Show("New User Added!");
                    }
                    else //Apabila ada, lanjut ke sini.
                    {
                        //Menunjukkan ada username yang sama
                        MessageBox.Show("Oops! Seems like there is already a similar username. Try another one!");
                    }
                }
                else
                {
                    MessageBox.Show("Try again!");
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            //If connection buka, tutup dulu baru buka kembali
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Call table
            display();
        }

        //Method for connecting datagrid with database
        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT * FROM Users";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        //Return to home
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

        private void deleteButton_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var username = dataGridView1.SelectedCells[2].Value.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Users where username='" + username + "';";
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("User deleted!");
            }
        }

    }
}
