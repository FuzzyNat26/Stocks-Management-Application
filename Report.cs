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
    public partial class Sales_Report : Form
    {
        //Establish connection with database
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Proyek_UAS.Properties.Settings.InventoryConnectionString"].ToString());

        //Set int as Order_ID
        int Order_ID;

        public Sales_Report()
        {
            InitializeComponent();
        }

        //Get Order_ID from Sales and Sales_History
        public void Get_Order_ID (int i)
        {
            Order_ID = i;
        }

        //Load connection
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Call dataset
            DataSet1 dataset = new DataSet1();

            //Select Orders
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Orders WHERE Order_ID = " + Order_ID + "";
            cmd.ExecuteNonQuery();

            //Fill table "Orders" in dataset
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataset.Orders);

            //Select Sell and Products
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT A.Product_ID, B.Product_Name, A.Quantity, A.Total, A.Order_ID, A.Total/A.Quantity AS Sell_Price " +
                                    "FROM Sell AS A, Products AS B " +
                                    "WHERE A.Product_ID = B.Product_ID AND A.Order_ID ='" + Order_ID + "'";
            cmd1.ExecuteNonQuery();

            //Fill table "Sell" in dataset
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd1);
            dataAdapter1.Fill(dataset.Sell);

            //Call report
            CrystalReport1 Report = new CrystalReport1();
            Report.SetDataSource(dataset);
            Print_Report.ReportSource = Report;
        }
    }
}