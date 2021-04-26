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
    public partial class Purchase_Stocks : Form
    {
        //Establish koneksi sama database
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

        public Purchase_Stocks()
        {
            InitializeComponent();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Run when loading
        private void Add_Stocks_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Display data
            display();

            //Combo Box
            fill_product_name_box();
            fill_dealer_name_box();
        }

        //Display datagrid
        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT Purchases.Purchase_ID," +
                                          "Purchase_Product.Product_ID," +
                                          "Products.Product_Name," +
                                          "Purchases.Purchase_Price," +
                                          "Purchases.Quantity," +
                                          "Purchases.Total," +
                                          "Purchases.Sell_Price," +
                                          "Purchases.Purchase_Date," +
                                          "Purchases.Dealer_ID," +
                                          "Dealers.Dealer_Name " +
                                  "FROM Dealers, Purchases, Purchase_Product, Products " +
                                  "WHERE Purchase_Product.Purchase_ID = Purchases.Purchase_ID " +
                                          "AND Purchase_Product.Product_ID = Products.Product_ID " +
                                          "AND Dealers.Dealer_ID = Purchases.Dealer_ID";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        //Go to Stocks List
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Stocks_Name = new Stocks_List();
            Stocks_Name.Show();
        }

        //Back to Home
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        //Set textbox drawitem
        private void Product_Name_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Product_Name_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Dealer_Name_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Dealer_Name_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        //Fill combo box
        public void fill_product_name_box()
        {
            Product_Name_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT * FROM Products";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Product_Name_Box.Items.Add(dr["Product_Name"].ToString());
            }
        }

        public void fill_dealer_name_box()
        {
            Dealer_Name_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT * FROM Dealers";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Dealer_Name_Box.Items.Add(dr["Dealer_Name"].ToString());
            }
        }

        //Index changed
        private void Product_Name_Box_SelectionIndexChanged (object sender, EventArgs e)
        {
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT Product_ID FROM Products WHERE Product_Name='"
                + Product_Name_Box.Text + "'";
            fill.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Product_ID_Box.Text = Convert.ToString(dr["Product_ID"]);
            }   
        }

        private void Dealer_Name_Box_SelectionIndexChanged(object sender, EventArgs e)
        {
            SqlCommand fill1 = con.CreateCommand();
            fill1.CommandType = CommandType.Text;
            fill1.CommandText = "SELECT Dealer_ID FROM Dealers WHERE Dealer_Name='"
                + Dealer_Name_Box.Text + "'";
            fill1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(fill1);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                Dealer_ID_Box.Text = Convert.ToString(dr["Dealer_ID"]);
            }
        }

        //Only accept number
        private void Only_Accept_Number_Key_Press (object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                e.Handled = true;
                MessageBox.Show("Oops! Input Number Only! (No letters, ',' and '.')");
            }
        }

        //Auto count
        private void Total_Box_Value_Textbox_Leave(object sender, EventArgs e)
        {
            bool a = string.IsNullOrEmpty(Purchase_Price_Box.Text); //true
            bool b = string.IsNullOrEmpty(Quantity_Box.Text); //true
            if (a)
            {
                Purchase_Price_Box.Text = "0";
                Selling_Price_Box.Text = "0";
            } 

            if (b)
            {
                Quantity_Box.Text = "0";
            }

            if (a || b == false)
            {
                Total_Box.Text = Convert.ToString(Convert.ToInt32(Purchase_Price_Box.Text) * Convert.ToInt32(Quantity_Box.Text));
                if (string.IsNullOrEmpty(Selling_Price_Box.Text))
                {
                    Selling_Price_Box.Text = Convert.ToString(Purchase_Price_Box.Text);
                }

                if (Convert.ToInt32(Selling_Price_Box.Text) < Convert.ToInt32(Purchase_Price_Box.Text))
                {
                    Selling_Price_Box.Text = Purchase_Price_Box.Text;
                }
            }
        }

        private void Selling_Price_Leave(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(Selling_Price_Box.Text) || string.IsNullOrEmpty(Purchase_Price_Box.Text)))
            {
                int sell_price = Convert.ToInt32(Selling_Price_Box.Text);
                int purchase_price = Convert.ToInt32(Purchase_Price_Box.Text);
                if (sell_price < purchase_price)
                {
                    MessageBox.Show("Selling price must higher than Purchase price!");
                    Selling_Price_Box.Text = Purchase_Price_Box.Text;
                }
            }
        }

        //Add Stocks
        private void button1_Click(object sender, EventArgs e)
        {
            //Do all textbox filled
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //If there is empty textbox, do this
            {
                MessageBox.Show("All input must be filled!");
            }
            else //If all filled, do this
            {
                LinkedList<string> confirm = new LinkedList<string>();
                confirm.AddLast("Product ID:");
                confirm.AddLast(Product_ID_Box.Text);

                confirm.AddLast("Product Name:");
                confirm.AddLast(Product_Name_Box.Text);

                confirm.AddLast("Purchase Price:");
                confirm.AddLast(Purchase_Price_Box.Text);

                confirm.AddLast("Quantity:");
                confirm.AddLast(Quantity_Box.Text);

                confirm.AddLast("Dealer ID:");
                confirm.AddLast(Dealer_ID_Box.Text);

                confirm.AddLast("Dealer Name:");
                confirm.AddLast(Dealer_Name_Box.Text);

                confirm.AddLast("Selling Price:");
                confirm.AddLast(Selling_Price_Box.Text);

                confirm.AddLast("Purchase Date:");
                confirm.AddLast(Purchase_Date.Text);

                confirm.AddLast("Total:");
                confirm.AddLast(Total_Box.Text);

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
                    //Insert data ke dalam PURCHASE
                    SqlCommand purchase = con.CreateCommand();
                    purchase.CommandType = CommandType.Text;
                    purchase.CommandText = "INSERT INTO Purchases VALUES ('" + Purchase_Price_Box.Text + "','"
                                                                            + Quantity_Box.Text + "', '"
                                                                            + Total_Box.Text + "', '"
                                                                            + Selling_Price_Box.Text + "', '"
                                                                            + Purchase_Date.Value.Date + "', '"
                                                                            + Dealer_ID_Box.Text + "')";
                    purchase.ExecuteNonQuery();

                    //Insert data ke dalam Purchase Stocks
                    int Purchase_ID = 0;
                    SqlCommand temp = con.CreateCommand();
                    temp.CommandType = CommandType.Text;
                    temp.CommandText = "SELECT TOP 1 Purchase_ID FROM Purchases ORDER BY Purchase_ID DESC";
                    temp.ExecuteNonQuery();

                    DataTable temp_table = new DataTable();
                    SqlDataAdapter temp_da = new SqlDataAdapter(temp);
                    temp_da.Fill(temp_table);

                    foreach (DataRow dr in temp_table.Rows)
                    {
                        Purchase_ID = Convert.ToInt32(dr["Purchase_ID"]);
                    }

                    SqlCommand purchase_stock = con.CreateCommand();
                    purchase_stock.CommandType = CommandType.Text;
                    purchase_stock.CommandText = "INSERT INTO Purchase_Product VALUES ('" + Purchase_ID + "','"
                                                                                        + Product_ID_Box.Text + "')";
                    purchase_stock.ExecuteNonQuery();

                    //Add Quantity
                    SqlCommand quantity = con.CreateCommand();
                    quantity.CommandType = CommandType.Text;
                    quantity.CommandText = "UPDATE Products SET Product_Quantity = Product_Quantity + "
                        + Quantity_Box.Text + " WHERE Product_ID = '" + Product_ID_Box.Text + "'";
                    quantity.ExecuteNonQuery();

                    //Menghapus teks yang ada di textbox
                    Product_ID_Box.Text = ""; Product_Name_Box.Text = "";
                    Quantity_Box.Text = ""; Purchase_Price_Box.Text = "";
                    Dealer_ID_Box.Text = ""; Dealer_Name_Box.Text = "";
                    Selling_Price_Box.Text = ""; Purchase_Date.Text = "";
                    Total_Box.Text = "";

                    //Refresh Table
                    display();

                    //Menunjukkan data sudah added
                    MessageBox.Show("New Purchase Added!");
                }
                else
                {
                    MessageBox.Show("Oops! Try Again!");
                }
            }
        }

        //Delete Stocks
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this purchase?",
                "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //Delete from Purchase
                var Purchase_ID = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand purchase = con.CreateCommand();
                purchase.CommandType = CommandType.Text;
                purchase.CommandText = "DELETE FROM Purchases where Purchase_ID='" + Purchase_ID + "'";
                purchase.ExecuteNonQuery();

                //Delete from Purchase_Stock
                SqlCommand purchase_stock = con.CreateCommand();
                purchase_stock.CommandType = CommandType.Text;
                purchase_stock.CommandText = "DELETE FROM Purchase_Product where Purchase_ID='" + Purchase_ID + "'";
                purchase_stock.ExecuteNonQuery();

                //Minus Quantity from Products
                var Product_ID = dataGridView1.SelectedCells[1].Value.ToString();
                var Quantity = dataGridView1.SelectedCells[4].Value.ToString();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "UPDATE Products SET Product_Quantity = Product_Quantity - "
                    + Quantity + " WHERE Product_ID = '" + Product_ID + "'";
                cmd1.ExecuteNonQuery();

                display();

                MessageBox.Show("Item deleted!");
            }
        }
    }
}
