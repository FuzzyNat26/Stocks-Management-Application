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
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

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

                //Delete data from Sold_Product_History
                SqlCommand del1 = con.CreateCommand();
                del1.CommandType = CommandType.Text;
                del1.CommandText = "DELETE FROM Sold_Product_History WHERE Sales_ID ='" + Sales_ID + "'";
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
            Data_SalesID_ProductHistory_View.DataSource = null;
            Data_SalesID_ProductHistory_View.Rows.Clear();

            int Sales_ID = Convert.ToInt32(Data_Sales_History_View.SelectedCells[0].Value.ToString());

            SqlCommand find = con.CreateCommand();
            find.CommandType = CommandType.Text;
            find.CommandText = "SELECT Product_ID, Product_Name, Product_Price, Quantity, Total_Price " +
                "FROM Sold_Product_History WHERE Sales_ID = '" + Sales_ID + "'";
            find.ExecuteNonQuery();

            DataTable found = new DataTable();
            SqlDataAdapter da_found = new SqlDataAdapter(find);
            da_found.Fill(found);
            Data_SalesID_ProductHistory_View.DataSource = found;
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            //Kalau mau print order
            var confirmResult1 = MessageBox.Show("Do you want to print this sales?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult1 == DialogResult.Yes)
            {
                int Sales_ID = Convert.ToInt32(Data_Sales_History_View.SelectedCells[0].Value.ToString());
                Sales_Report report = new Sales_Report();
                report.Get_Sales_ID(Convert.ToInt32(Sales_ID.ToString()));
                report.Show();
            }
        }
    }
}
