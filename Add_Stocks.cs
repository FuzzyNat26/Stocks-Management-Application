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
    public partial class Add_Stocks : Form
    {
        //Establish koneksi sama database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                            AttachDbFilename=C:\PROJECT C DRIVE\VS 2019\Proyek UAS\Inventory.mdf;
                            Integrated Security=True");

        public Add_Stocks()
        {
            InitializeComponent();
        }

        private void Product_Name_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Product_Name_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Username_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Username_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Dealer_Name_Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1)
            {
                e.Graphics.DrawString(Dealer_Name_Box.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        //Atur Combo Box
        public void fill_product_name_box()
        {
            Product_Name_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT * FROM Product_Name";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Product_Name_Box.Items.Add(dr["Product_Name"].ToString());
            }
        }

        public void fill_dealer_name_box()
        {
            Dealer_Name_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT * FROM Dealers";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Dealer_Name_Box.Items.Add(dr["Dealer_Name"].ToString());
            }
        }

        public void fill_username_box()
        {
            Username_Box.Items.Clear();
            SqlCommand fill = con.CreateCommand();
            fill.CommandType = CommandType.Text;
            fill.CommandText = "SELECT * FROM Users";
            fill.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Username_Box.Items.Add(dr["Username"].ToString());
            }
        }

        private void Product_Name_Box_SelectionIndexChanged (object sender, EventArgs e)
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

        public void display()
        {
            SqlCommand display = con.CreateCommand();
            display.CommandType = CommandType.Text;
            display.CommandText = "SELECT * FROM Add_Stocks";
            display.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(display);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Home = new Home();
            Home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Stocks_Name = new Stocks_Name();
            Stocks_Name.Show();
        }

        private void Add_Stocks_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Display data di tabel
            display();

            //Combo Box
            fill_product_name_box();
            fill_username_box();
            fill_dealer_name_box();
        }

        //Add Item
        private void button1_Click(object sender, EventArgs e)
        {
            //Apakah semua control berbentuk textbox berisi?
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text))) //Apabila ada yang tidak diisi, lakukan ini
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
                confirm.AddLast("Quantity:");
                confirm.AddLast(Quantity_Box.Text);
                confirm.AddLast("Product Price:");
                confirm.AddLast(Product_Price_Box.Text);
                confirm.AddLast("Dealer Name:");
                confirm.AddLast(Dealer_Name_Box.Text);
                confirm.AddLast("Inserted By:");
                confirm.AddLast(Username_Box.Text);
                confirm.AddLast("Purchase Date:");
                confirm.AddLast(Purchase_Date.Text);
                confirm.AddLast("Profit:");
                confirm.AddLast(Profit_Box.Text);

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
                    //Insert data yang ada di textbox ke dalam database
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Add_Stocks VALUES ('" + Product_ID_Box.Text + "','"
                                                                         + Product_Name_Box.Text + "', '"
                                                                         + Quantity_Box.Text + "', '"
                                                                         + Product_Price_Box.Text + "', '"
                                                                         + Dealer_Name_Box.Text + "', '"
                                                                         + Username_Box.Text + "', '"
                                                                         + Purchase_Date.Value.Date + "', '"
                                                                         + Profit_Box.Text + "')";
                    cmd.ExecuteNonQuery();

                    //Menghapus teks yang ada di textbox
                    Product_ID_Box.Text = ""; Product_Name_Box.Text = ""; Quantity_Box.Text = "";
                    Product_Price_Box.Text = ""; Dealer_Name_Box.Text = ""; Username_Box.Text = "";
                    Purchase_Date.Text = ""; Profit_Box.Text = "";

                    //Refresh Table
                    display();

                    //Menunjukkan data sudah added
                    MessageBox.Show("New Data Added!");
                }
                else
                {
                    //Menunjukkan ada username yang sama
                    MessageBox.Show("Try Again");
                };
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                "Confirmation", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var Purchase_ID = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Add_Stocks where Purchase_ID='" + Purchase_ID + "'";
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("Item deleted!");
            }
        }
    }
}
