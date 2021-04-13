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
        //Establish koneksi sama database
        SqlConnection con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename='C:\PROJECT C DRIVE\VS 2019\Proyek UAS\R_Inventory.mdf';
                                                Integrated Security = True");

        int j;
        public Sales_Report()
        {
            InitializeComponent();
        }

        public void Get_Sales_ID (int i)
        {
            j = i;
        }

        //load connection
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            DataSet1 dataset = new DataSet1();

            //Sales_History
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Sales_History WHERE Sales_ID = " + j + "";
            cmd.ExecuteNonQuery();

            //DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataset.Sales_History);
            //dataAdapter.Fill(dataTable);

            //Sold_Product_History
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT * FROM Sold_Product_History WHERE Sales_ID = " + j + "";
            cmd1.ExecuteNonQuery();

            //DataTable dataTable1 = new DataTable();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd1);
            dataAdapter1.Fill(dataset.Sold_Product_History);
            //dataAdapter1.Fill(dataTable1);

            CrystalReport1 Report = new CrystalReport1();
            Report.SetDataSource(dataset);
            Print_Report.ReportSource = Report;
        }
    }
}
