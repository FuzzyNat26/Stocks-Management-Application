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
        //Establish koneksi sama database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                            AttachDbFilename=C:\PROJECT C DRIVE\VS 2019\Proyek UAS\Inventory.mdf;
                            Integrated Security=True");

        DataTable temp_dataTable = new DataTable();

        int Total = 0;

        public Sales()
        {
            InitializeComponent();
        }

        //Return to Home

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        //Go to sales history
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Sales_History = new Sales_History();
            Sales_History.Show();
        }

        private void Username_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Username_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Bill_Type_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Bill_Type_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        //Atur Combo Box

        public void fill_username_box()
        {
            Username_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT Username FROM Users";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Username_Box.Items.Add(dr["Username"].ToString());
            }
        }

        public void fill_product_name_box()
        {
            Product_Name_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT Product_Name FROM Product_Name";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Product_Name_Box.Items.Add(dr["Product_Name"].ToString());
            }
        }

        private void Product_Name_Box_SelectionIndexChanged(object sender, EventArgs e)
        {
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT Product_ID FROM Product_Name WHERE Product_Name='"
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

        private void Total_Box_Value_Textbox_Leave(object sender, EventArgs e)
        {
            bool a = string.IsNullOrEmpty(Product_Price_Box.Text); //true
            bool b = string.IsNullOrEmpty(Quantity_Box.Text); //true
            if (a)
            {
                Product_Price_Box.Text = "0";
            }

            if (b)
            {
                Quantity_Box.Text = "0";
            }

            if (a || b == false)
            {
                Total_Box.Text = Convert.ToString(Convert.ToInt32(Product_Price_Box.Text) * Convert.ToInt32(Quantity_Box.Text));
            }

        }

        private void Sales_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            
            fill_username_box();
            fill_product_name_box();

            temp_dataTable.Clear();
            temp_dataTable.Columns.Add("Product_ID");
            temp_dataTable.Columns.Add("Product_Name");
            temp_dataTable.Columns.Add("Product_Price");
            temp_dataTable.Columns.Add("Quantity");
            temp_dataTable.Columns.Add("Total_Price");
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
                quantity.CommandText = "SELECT Product_Quantity FROM Product_Name WHERE Product_ID='" + Product_ID_Box.Text + "'";

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
                    temp_dr["Product_Price"] = Product_Price_Box.Text;
                    temp_dr["Quantity"] = Quantity_Box.Text;
                    temp_dr["Total_Price"] = Total_Box.Text;

                    temp_dataTable.Rows.Add(temp_dr);
                    dataGridView1.DataSource = temp_dataTable;

                    Total = Total + Convert.ToInt32(temp_dr["Total_Price"].ToString());
                    Total_Payment_Box.Text = Convert.ToString(Total);

                    //Menunjukkan data sudah added
                    MessageBox.Show("New Data Added!");
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
                    //input ke sales_history
                    SqlCommand input = con.CreateCommand();
                    input.CommandType = CommandType.Text;
                    input.CommandText = "INSERT INTO Sales_History VALUES('" + Customer_Box.Text + "','"
                                                                             + Total_Box.Text + "', '"
                                                                             + Sale_Date_Box.Text + "', '"
                                                                             + Username_Box.Text + "', '"
                                                                             + Bill_Type_Box.Text + "')";
                    input.ExecuteNonQuery();

                    //input ke sales_id_and_product_history dengan mengambil sales_id dari tabel sales_History
                    int Sales_ID = 0;

                    SqlCommand input2 = con.CreateCommand();
                    input2.CommandType = CommandType.Text;
                    input2.CommandText = "SELECT TOP 1 * FROM Sales_History ORDER BY Sales_ID DESC";
                    input2.ExecuteNonQuery();

                    DataTable dataTable2 = new DataTable();
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(input2);
                    dataAdapter2.Fill(dataTable2);

                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        Sales_ID = Convert.ToInt32(dataRow2["Sales_ID"].ToString());
                    }

                    foreach (DataRow temp_dataRow in temp_dataTable.Rows)
                    {
                        SqlCommand temp = con.CreateCommand();
                        temp.CommandType = CommandType.Text;
                        temp.CommandText = "INSERT INTO Sales_ID_And_Product_History VALUES('" + Sales_ID + "','"
                                                                                               + temp_dataRow["Product_ID"] + "', '"
                                                                                               + temp_dataRow["Product_Name"] + "', '"
                                                                                               + temp_dataRow["Product_Price"] + "', '"
                                                                                               + temp_dataRow["Quantity"] + "', '"
                                                                                               + temp_dataRow["Total_Price"] + "')";

                        temp.ExecuteNonQuery();

                        //Kurangkan quantity
                        int Quantity = Convert.ToInt32(temp_dataRow["Quantity"].ToString());
                        string Product_ID = temp_dataRow["Product_ID"].ToString();

                        SqlCommand temp1 = con.CreateCommand();
                        temp1.CommandType = CommandType.Text;
                        temp1.CommandText = "UPDATE Product_Name SET Product_Quantity = Product_Quantity - "
                            + Quantity + " WHERE Product_ID = '" + Product_ID.ToString() + "'";

                        temp1.ExecuteNonQuery();
                    }

                    //Reset Textbox
                    Customer_Box.Text = ""; Username_Box.Text = ""; Bill_Type_Box.Text = "";
                    Product_Name_Box.Text = ""; Product_ID_Box.Text = ""; Quantity_Box.Text = "0";
                    Product_Price_Box.Text = ""; Total_Box.Text = ""; Total_Payment_Box.Text = "";

                    //Reset datagrid
                    temp_dataTable.Clear();
                    dataGridView1.DataSource = temp_dataTable;

                    MessageBox.Show("Sales Added!");
                }

                var confirmResult1 = MessageBox.Show("Confirm Order?", "Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {

                }
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
    }
}
