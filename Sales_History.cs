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
        //Establish connection with database
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

        public Sales_History()
        {
            InitializeComponent();
        }

        //Run when loading
        private void Sales_History_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            call_sales_history();
        }

        //Display left datagrid
        private void call_sales_history()
        {
            SqlCommand call_sales = con.CreateCommand();
            call_sales.CommandType = CommandType.Text;
            call_sales.CommandText = "SELECT * FROM Orders";
            call_sales.ExecuteNonQuery();

            DataTable sales_history = new DataTable();
            SqlDataAdapter da_sales = new SqlDataAdapter(call_sales);
            da_sales.Fill(sales_history);
            Data_Sales_History_View.DataSource = sales_history;
        }

        //Display right datagrid for every left datagrid row clicked
        private void Data_Sales_History_View_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Data_SalesID_ProductHistory_View.DataSource = null;
            Data_SalesID_ProductHistory_View.Rows.Clear();

            int Sales_ID = Convert.ToInt32(Data_Sales_History_View.SelectedCells[0].Value.ToString());

            SqlCommand find = con.CreateCommand();
            find.CommandType = CommandType.Text;
            find.CommandText = "SELECT A.Product_ID, B.Product_Name, A.Quantity, A.Total " +
                                    "FROM Sell AS A, Products AS B " +
                                    "WHERE A.Product_ID = B.Product_ID AND A.Sales_ID ='" + Sales_ID +"'";
            find.ExecuteNonQuery();

            DataTable found = new DataTable();
            SqlDataAdapter da_found = new SqlDataAdapter(find);
            da_found.Fill(found);

            found.Columns.Add("Sell_Price");

            foreach (DataRow temp_dr in found.Rows)
            {
                temp_dr["Sell_Price"] = Convert.ToInt32(temp_dr["Total"])/Convert.ToInt32(temp_dr["Quantity"]);
            }

            Data_SalesID_ProductHistory_View.DataSource = found;

            AdjustColumnOrder();
        }

        //Back to Sales
        private void Back_Button_Click (object sender, EventArgs e)
        {
            this.Hide();
            Form Sales = new Sales();
            Sales.Show();
        }

        //Adjust collumn order
        private void AdjustColumnOrder()
        {
            Data_SalesID_ProductHistory_View.Columns["Product_ID"].DisplayIndex = 0;
            Data_SalesID_ProductHistory_View.Columns["Product_Name"].DisplayIndex = 1;
            Data_SalesID_ProductHistory_View.Columns["Sell_Price"].DisplayIndex = 2;
            Data_SalesID_ProductHistory_View.Columns["Quantity"].DisplayIndex = 3;
            Data_SalesID_ProductHistory_View.Columns["Total"].DisplayIndex = 4;
        }

        //Print button clicked
        private void Print_Button_Click(object sender, EventArgs e)
        {
            var confirmResult1 = MessageBox.Show("Do you want to print this sales?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult1 == DialogResult.Yes)
            {
                int Sales_ID = Convert.ToInt32(Data_Sales_History_View.SelectedCells[0].Value.ToString());
                Sales_Report report = new Sales_Report();
                report.Get_Sales_ID(Convert.ToInt32(Sales_ID.ToString()));
                report.Show();
            }
        }

        //Delete Sales
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this sales?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //Delete data from Sales_History
                var Sales_ID = Data_Sales_History_View.SelectedCells[0].Value.ToString();

                SqlCommand del = con.CreateCommand();
                del.CommandType = CommandType.Text;
                del.CommandText = "DELETE FROM Orders WHERE Sales_ID ='" + Sales_ID + "'";
                del.ExecuteNonQuery();

                //Delete data from Sold_Product_History
                SqlCommand del1 = con.CreateCommand();
                del1.CommandType = CommandType.Text;
                del1.CommandText = "DELETE FROM Sell WHERE Sales_ID ='" + Sales_ID + "'";
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
                    temp1.CommandText = "UPDATE Products SET Product_Quantity = Product_Quantity + "
                        + Convert.ToInt32(Quantity) + " WHERE Product_ID = '" + Product_ID.ToString() + "'";
                    temp1.ExecuteNonQuery();
                }

                //refresh view
                call_sales_history();

                MessageBox.Show("User deleted!");
            }
        }
    }
}