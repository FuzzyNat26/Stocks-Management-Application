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
    public partial class Sales_History : Form
    {
        //Establish koneksi sama database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                            AttachDbFilename=C:\PROJECT C DRIVE\VS 2019\Proyek UAS\Inventory.mdf;
                            Integrated Security=True");

        public Sales_History()
        {
            InitializeComponent();
        }

        private void Back_Button_Click (object sender, EventArgs e)
        {
            this.Hide();
            Form Sales = new Sales();
            Sales.Show();
        }

        private void Sales_History_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            call_sales_history();
        }

        private void call_sales_history()
        {
            SqlCommand call_sales = con.CreateCommand();
            call_sales.CommandType = CommandType.Text;
            call_sales.CommandText = "SELECT * FROM Sales_History";
            call_sales.ExecuteNonQuery();

            DataTable sales_history = new DataTable();
            SqlDataAdapter da_sales = new SqlDataAdapter(call_sales);
            da_sales.Fill(sales_history);
            Data_Sales_History_View.DataSource = sales_history;
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this sales?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //Delete data from Sales_History
                var Sales_ID = Data_Sales_History_View.SelectedCells[0].Value.ToString();

                SqlCommand del = con.CreateCommand();
                del.CommandType = CommandType.Text;
                del.CommandText = "DELETE FROM Sales_History WHERE Sales_ID ='" + Sales_ID + "'";
                del.ExecuteNonQuery();

                //Delete data from Sales_ID_And_Product_History
                SqlCommand del1 = con.CreateCommand();
                del1.CommandType = CommandType.Text;
                del1.CommandText = "DELETE FROM Sales_ID_And_Product_History WHERE Sales_ID ='" + Sales_ID + "'";
                del1.ExecuteNonQuery();


                //Return Sold Quantity
                //Temporary Datatable
                DataTable temp_data = new DataTable();
                temp_data.Columns.Add("Product_ID");
                temp_data.Columns.Add("Quantity");
                foreach (DataGridViewRow row in Data_SalesID_ProductHistory_View.Rows)
                {
                    DataRow temp_dr = temp_data.NewRow();
                    temp_dr["Product_ID"] = row.Cells["Product_ID"].Value;
                    temp_dr["Quantity"] = Convert.ToInt32(row.Cells["Quantity"].Value);
                    temp_data.Rows.Add(temp_dr);
                }

                foreach (DataRow temp_dataRow in temp_data.Rows)
                {
                    var Quantity = temp_dataRow["Quantity"].ToString();
                    var Product_ID = temp_dataRow["Product_ID"].ToString();

                    SqlCommand temp1 = con.CreateCommand();
                    temp1.CommandType = CommandType.Text;
                    temp1.CommandText = "UPDATE Product_Name SET Product_Quantity = Product_Quantity + "
                        + Convert.ToInt32(Quantity) + " WHERE Product_ID = '" + Product_ID.ToString() + "'";

                    temp1.ExecuteNonQuery();
                }




                //refresh view
                call_sales_history();

                MessageBox.Show("User deleted!");
            }
        }

        private void Data_Sales_History_View_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand temp_sales_id = con.CreateCommand();
            temp_sales_id.CommandType = CommandType.Text;
            temp_sales_id.CommandText = "SELECT Sales_ID FROM Sales_History";
            temp_sales_id.ExecuteNonQuery();

            DataTable temp_dataTable = new DataTable();
            SqlDataAdapter temp_dataAdapter = new SqlDataAdapter(temp_sales_id);
            temp_dataAdapter.Fill(temp_dataTable);

            int Sales_ID = 0;

            foreach (DataRow temp in temp_dataTable.Rows)
            {
                Sales_ID = Convert.ToInt32(temp["Sales_ID"].ToString());
            }

            SqlCommand find = con.CreateCommand();
            find.CommandType = CommandType.Text;
            find.CommandText = "SELECT Product_ID, Product_Name, Product_Price, Quantity, Total_Price " +
                "FROM Sales_ID_And_Product_History WHERE Sales_ID = '" + Sales_ID + "'";
            find.ExecuteNonQuery();

            DataTable found = new DataTable();
            SqlDataAdapter da_found = new SqlDataAdapter(find);
            da_found.Fill(found);
            Data_SalesID_ProductHistory_View.DataSource = found;
        }
    }
}
