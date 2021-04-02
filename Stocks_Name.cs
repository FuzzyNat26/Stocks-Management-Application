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
    public partial class Stocks_Name : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                            AttachDbFilename=C:\PROJECT C DRIVE\VS 2019\Proyek UAS\Inventory.mdf;
                            Integrated Security=True");

        public Stocks_Name()
        {
            InitializeComponent();
        }
        private void Stocks_Name_Load(object sender, EventArgs e)
        {
            //If connection buka, tutup dulu baru buka kembali
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Call table
            display();
        }

        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT * FROM Product_Name";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Add_Stocks();
            stocks.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form stocks = new Add_Stocks();
            stocks.Show();
        }

        //Add Item Name
        private void button1_Click(object sender, EventArgs e)
        {
            //Apakah textbox terisi?
            if (!(String.IsNullOrEmpty(Product_ID_Box.Text) || String.IsNullOrEmpty(Product_Name_Box.Text)) == false) //Kalau tidak, lakukan ini.
            {
                MessageBox.Show("All input must be filled!");
            }
            else //Apabila semua berisi, lakukan ini
            {
                LinkedList<string> confirm = new LinkedList<string>();
                confirm.AddLast("Product ID:");
                confirm.AddLast(Product_ID_Box.Text);
                confirm.AddLast("Product Name:");
                confirm.AddLast(Product_Name_Box.Text);

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
                    int i = 0;

                    //Membuat command untuk mencari apakah ada username yang sama
                    SqlCommand check = con.CreateCommand();
                    check.CommandType = CommandType.Text;
                    check.CommandText = "SELECT * from Product_Name where Product_ID='" + Product_ID_Box.Text + "'";
                    check.ExecuteNonQuery();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(check);
                    dataAdapter.Fill(dataTable);
                    i = Convert.ToInt32(dataTable.Rows.Count.ToString());

                    if (i == 0) //Apabila tidak ada, lanjut ke sini.
                    {
                        //Insert data yang ada di textbox ke dalam database
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Product_Name values ('" + Product_ID_Box.Text    + "','"
                                                                               + Product_Name_Box.Text  + "','"
                                                                               + 0 + "')";
                        cmd.ExecuteNonQuery();

                        //Menghapus teks yang ada di textbox
                        Product_ID_Box.Text = ""; Product_Name_Box.Text = "";

                        //Refresh Table
                        display();

                        //Menunjukkan data sudah added
                        MessageBox.Show("New Product Name Added!");
                    }
                    else //Apabila ada, lanjut ke sini.
                    {
                        //Menunjukkan ada Product_ID yang sama
                        MessageBox.Show("Oops! Seems like there is already a similar Product_ID. Try another one!");
                    }
                }
                else
                {
                    MessageBox.Show("Try again!");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_Panel.Visible = true;

            if (dataGridView1.SelectedCells[0].Value.ToString() != null)
            {
                var i = dataGridView1.SelectedCells[0].Value.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Product_Name WHERE Product_ID ='" + i + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    U_Product_ID_Box.Text = dr["Product_ID"].ToString();
                    U_Product_Name_Box.Text = dr["Product_Name"].ToString();
                }
            }
        }

        //Update Button
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells[0].Value.ToString() != null)
            {
                var i = dataGridView1.SelectedCells[0].Value.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Product_Name SET Product_ID='" + U_Product_ID_Box.Text + "', Product_Name='"
                                                                         + U_Product_Name_Box.Text +
                                  "' WHERE Product_ID='" + i + "'";
                cmd.ExecuteNonQuery();

                Update_Panel.Visible = false;

                display();
            }
        }
    }
}