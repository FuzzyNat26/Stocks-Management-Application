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

        private void Data_Sales_History_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            find.CommandText = "SELECT Product_ID, Product_Name, " +
                "Product_Price, Quantity, Total_Price FROM Sales_ID_And_Product_History WHERE Sales_ID = '" + Sales_ID + "'";
            find.ExecuteNonQuery();

            DataTable found = new DataTable();
            SqlDataAdapter da_found = new SqlDataAdapter(find);
            da_found.Fill(found);
            Data_Sales_History_View.DataSource = found;
        }
    }
}
