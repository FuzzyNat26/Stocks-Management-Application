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
    public partial class Sales : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Proyek_UAS.Properties.Settings.InventoryConnectionString"].ToString());

        //Temporary datatable for datagridview
        DataTable temp_dataTable = new DataTable();

        //Set default total to 0
        int Total = 0;

        public Sales()
        {
            InitializeComponent();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Run when loading
        private void Sales_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            Username_Box.Text = User_Log.Username;

            fill_product_name_box();

            temp_dataTable.Clear();
            temp_dataTable.Columns.Add("Product_ID");
            temp_dataTable.Columns.Add("Product_Name");
            temp_dataTable.Columns.Add("Product_Price", typeof(Int32));
            temp_dataTable.Columns.Add("Quantity");
            temp_dataTable.Columns.Add("Total_Price", typeof(Int32));
        }

        //Go to sales history
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Sales_History = new Sales_History();
            Sales_History.Show();
        }

        //Return to Home
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        //Set drawitem event

        private void Bill_Type_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Bill_Type_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Product_Name_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Product_Name_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        //Fill Combo Box
        public void fill_product_name_box()
        {
            Product_Name_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT Product_Name FROM Products";
            fill.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Product_Name_Box.Items.Add(dr["Product_Name"].ToString());
            }
        }

        //Set Product ID and Product Price according to what product name selected.
        private void Product_Name_Box_SelectionIndexChanged(object sender, EventArgs e)
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

            SqlCommand fill1 = con.CreateCommand();
            fill1.CommandType = CommandType.Text;
            fill1.CommandText = "SELECT Sell_Price FROM Purchases, Purchase_Product " +
                "WHERE Purchases.Purchase_ID = Purchase_Product.Purchase_ID AND Purchase_Product.Product_ID = '"
                + Product_ID_Box.Text + "'";
            fill1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(fill1);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                Sell_Price_Box.Text = Convert.ToString(dr["Sell_Price"].ToString());
            }
        }

        //Only accept number for some textbox
        private void Only_Accept_Number_Key_Press(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Oops! Input Number Only! (No letters, ',' and '.')");
            }
        }

        //Auto count total when leaving one of the textbox
        private void Total_Box_Value_Textbox_Leave(object sender, EventArgs e)
        {
            bool a = string.IsNullOrEmpty(Sell_Price_Box.Text); //true
            bool b = string.IsNullOrEmpty(Quantity_Box.Text); //true
            if (a)
            {
                Sell_Price_Box.Text = "0";
            }

            if (b)
            {
                Quantity_Box.Text = "0";
            }

            if (a || b == false)
            {
                Total_Box.Text = Convert.ToString(Convert.ToInt32(Sell_Price_Box.Text) * Convert.ToInt32(Quantity_Box.Text));
            }
        }

        //Add item to list
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //Apabila ada yang tidak diisi, lakukan ini
            {
                MessageBox.Show("All input must be filled!");
            }
            else
            {
                //Check quantity
                int Form_Product_Quantity = Convert.ToInt32(Quantity_Box.Text);
                int Stock_Product_Quantity = 0;

                SqlCommand quantity = con.CreateCommand();
                quantity.CommandType = CommandType.Text;
                quantity.CommandText = "SELECT Product_Quantity FROM Products WHERE Product_ID='" + Product_ID_Box.Text + "'";

                DataTable dataTable_quantity = new DataTable();
                SqlDataAdapter sqlDataAdapter_quantity = new SqlDataAdapter(quantity);
                sqlDataAdapter_quantity.Fill(dataTable_quantity);

                foreach (DataRow dr in dataTable_quantity.Rows)
                {
                    Stock_Product_Quantity = Convert.ToInt32(dr["Product_Quantity"].ToString());
                }

                if (Form_Product_Quantity > Stock_Product_Quantity)
                {
                    MessageBox.Show("There are only " + Convert.ToString(Stock_Product_Quantity) + " stocks left");
                }
                else
                {
                    DataRow temp_dr = temp_dataTable.NewRow();
                    temp_dr["Product_ID"] = Product_ID_Box.Text;
                    temp_dr["Product_Name"] = Product_Name_Box.Text;
                    temp_dr["Product_Price"] = Sell_Price_Box.Text;
                    temp_dr["Quantity"] = Quantity_Box.Text;
                    temp_dr["Total_Price"] = Total_Box.Text;

                    temp_dataTable.Rows.Add(temp_dr);
                    dataGridView1.DataSource = temp_dataTable;

                    dataGridView1.Columns["Product_Price"].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns["Total_Price"].DefaultCellStyle.Format = "N2";

                    Total = Total + Convert.ToInt32(temp_dr["Total_Price"].ToString());
                    Total_Payment_Box.Text = Convert.ToString(Total);

                    //Show data added
                    MessageBox.Show("New order added to list!");
                }
            }
        }

        //Delete item from list
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Total = 0;
                temp_dataTable.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));
                foreach (DataRow temp_dr in temp_dataTable.Rows)
                {
                    Total = Total + Convert.ToInt32(temp_dr["Total_Price"].ToString());
                    Total_Box.Text = Convert.ToString(Total);
                }
            }
        }

        //Save order to database
        private void Save_Order_Button_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //Apabila ada yang tidak diisi, lakukan ini
            {
                MessageBox.Show("All input must be filled!");
            }
            else
            {
                var confirmResult = MessageBox.Show("Confirm Order?", "Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    //input to Orders
                    SqlCommand input = con.CreateCommand();
                    input.CommandType = CommandType.Text;
                    input.CommandText = "INSERT INTO Orders VALUES('" + Customer_Box.Text + "','"
                                                                     + Total_Payment_Box.Text + "', '"
                                                                     + Sale_Date_Box.Text + "', '"
                                                                     + Username_Box.Text + "', '"
                                                                     + Bill_Type_Box.Text + "')";
                    input.ExecuteNonQuery();

                    //Input to Sell by taking Order_ID from Orders
                    int Order_ID = 0;

                    SqlCommand input2 = con.CreateCommand();
                    input2.CommandType = CommandType.Text;
                    input2.CommandText = "SELECT TOP 1 * FROM Orders ORDER BY Order_ID DESC";
                    input2.ExecuteNonQuery();

                    DataTable dataTable2 = new DataTable();
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(input2);
                    dataAdapter2.Fill(dataTable2);

                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        Order_ID = Convert.ToInt32(dataRow2["Order_ID"].ToString());
                    }

                    foreach (DataRow temp_dataRow in temp_dataTable.Rows)
                    {
                        SqlCommand temp = con.CreateCommand();
                        temp.CommandType = CommandType.Text;
                        temp.CommandText = "INSERT INTO Sell VALUES('" + Order_ID + "','"
                                                                    + temp_dataRow["Product_ID"] + "', '"
                                                                    + temp_dataRow["Quantity"] + "', '"
                                                                    + temp_dataRow["Total_Price"] + "')";
                        temp.ExecuteNonQuery();

                        //Minus quantity
                        int Quantity = Convert.ToInt32(temp_dataRow["Quantity"].ToString());
                        string Product_ID = temp_dataRow["Product_ID"].ToString();

                        SqlCommand temp1 = con.CreateCommand();
                        temp1.CommandType = CommandType.Text;
                        temp1.CommandText = "UPDATE Products SET Product_Quantity = Product_Quantity - "
                            + Quantity + " WHERE Product_ID = '" + Product_ID.ToString() + "'";
                        temp1.ExecuteNonQuery();
                    }

                    //Reset Textbox
                    Customer_Box.Text = ""; Username_Box.Text = ""; Bill_Type_Box.Text = "";
                    Product_Name_Box.Text = ""; Product_ID_Box.Text = ""; Quantity_Box.Text = "0";
                    Sell_Price_Box.Text = "0"; Total_Box.Text = ""; Total_Payment_Box.Text = "";

                    //Reset datagrid
                    temp_dataTable.Clear();
                    dataGridView1.DataSource = temp_dataTable;

                    MessageBox.Show("Sales Added!");

                    //Check if users want to print order
                    var confirmResult1 = MessageBox.Show("Do you want to print this sales?", "Confirmation", MessageBoxButtons.YesNo);
                    if (confirmResult1 == DialogResult.Yes)
                    {
                        Sales_Report report = new Sales_Report();
                        report.Get_Order_ID(Convert.ToInt32(Order_ID.ToString()));
                        report.Show();
                    }
                }
            }
        }
    }
}