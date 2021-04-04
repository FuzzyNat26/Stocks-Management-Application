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
    }
}
