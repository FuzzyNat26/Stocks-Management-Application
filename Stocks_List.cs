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
    public partial class Stocks_List : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

        public Stocks_List()
        {
            InitializeComponent();
        }
        private void Stocks_Name_Load(object sender, EventArgs e)
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

        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT * FROM Stocks";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        //Return Home
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Purchase_Stocks();
            stocks.Show();
        }


        private void Username_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Username_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        //Add Item Name
        private void button1_Click(object sender, EventArgs e)
        {
            //Apakah textbox terisi?
            if (!(String.IsNullOrEmpty(Product_Name_Box.Text)) == false) //Kalau tidak, lakukan ini.
            {
                MessageBox.Show("All input must be filled!");
            }
            else //Apabila semua berisi, lakukan ini
            {
                LinkedList<string> confirm = new LinkedList<string>();
                confirm.AddLast("Product Name:");
                confirm.AddLast(Product_Name_Box.Text);
                confirm.AddLast("Inserted By:");
                confirm.AddLast(Username_Box.Text);
                confirm.AddLast("Input Date:");
                confirm.AddLast(Input_Date_Box.Text);

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
                    //Insert data yang ada di textbox ke dalam database
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Stocks (Product_Name, Product_Quantity, Input_Date, Inserted_By)" +
                        "VALUES ('" + Product_Name_Box.Text + "','"
                                    + 0 + "','"
                                    + Input_Date_Box.Text + "','"
                                    + Username_Box.Text + "')";
                    cmd.ExecuteNonQuery();

                    //Menghapus teks yang ada di textbox
                    Product_Name_Box.Text = ""; Username_Box.Text = ""; Input_Date_Box.Text = "";

                    //Refresh Table
                    display();

                    //Menunjukkan data sudah added
                    MessageBox.Show("New Product Name Added!");
                }
                else //Apabila ada, lanjut ke sini.
                {
                    MessageBox.Show("Oops! Try Again!");
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var Product_ID = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Stocks WHERE Product_ID='" + Product_ID + "'";
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("Item deleted!");
            }
        }
    }
}