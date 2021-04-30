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
    public partial class Products_List : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

        public Products_List()
        {
            InitializeComponent();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Run when loading
        private void Stocks_Name_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            Username_Box.Text = User_Log.Username;

            //Call table
            display();
        }

        //Display
        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT D.Product_ID, D.Product_Name, D.Product_Quantity, D.Input_Date, D.Inserted_By, E.Sell_Price " +
                "                       FROM Products AS D " +
                "                           LEFT OUTER JOIN (SELECT B.Product_ID, Sell_Price " +
                "                                               FROM Purchases AS A " +
                "                                                   INNER JOIN (SELECT MAX(Purchase_ID) AS Purchase_ID, Product_ID AS Product_ID " +
                "                                                       FROM Purchase_Product GROUP BY Product_ID) " +
                "                                                       AS B ON A.Purchase_ID = B.Purchase_ID, " +
                "                                           Products AS C WHERE C.Product_ID = B.Product_ID) " +
                "                   AS E ON D.Product_ID = E.Product_ID";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        //Return Purchase_Stocks
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Purchase_Product();
            stocks.Show();
        }

        //Add Item Name
        private void button1_Click(object sender, EventArgs e)
        {
            //Do all textbox empty
            if (!((String.IsNullOrEmpty(Product_Name_Box.Text))|| string.IsNullOrEmpty(Username_Box.Text)) == false) //Kalau tidak, lakukan ini.
            {
                MessageBox.Show("All input must be filled!");
            }
            else
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
                    //Insert data into Products Table
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Products (Product_Name, Product_Quantity, Input_Date, Inserted_By)" +
                        "VALUES ('" + Product_Name_Box.Text + "','"
                                    + 0 + "','"
                                    + Input_Date_Box.Value.Date + "','"
                                    + Username_Box.Text + "')";
                    cmd.ExecuteNonQuery();

                    //Reset text
                    Product_Name_Box.Text = ""; Username_Box.Text = ""; Input_Date_Box.Text = "";

                    //Refresh Table
                    display();

                    MessageBox.Show("New Product Name Added!");
                }
                else
                {
                    MessageBox.Show("Oops! Try Again!");
                }
            }
        }

        //Delete Item
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var Product_ID = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Products WHERE Product_ID='" + Product_ID + "'";
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("Item deleted!");
            }
        }
    }
}