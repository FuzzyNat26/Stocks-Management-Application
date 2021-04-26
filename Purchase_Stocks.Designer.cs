
namespace Proyek_UAS
{
    partial class Purchase_Stocks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.Total_Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Quantity_Box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Product_ID_Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Purchase_Price_Box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.Purchase_Date = new System.Windows.Forms.DateTimePicker();
            this.Dealer_Name_Box = new System.Windows.Forms.ComboBox();
            this.Product_Name_Box = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.Dealer_ID_Box = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Selling_Price_Box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(745, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 19);
            this.label8.TabIndex = 59;
            this.label8.Text = "Total";
            // 
            // Total_Box
            // 
            this.Total_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(96)))));
            this.Total_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Box.Location = new System.Drawing.Point(780, 287);
            this.Total_Box.Multiline = true;
            this.Total_Box.Name = "Total_Box";
            this.Total_Box.Size = new System.Drawing.Size(236, 35);
            this.Total_Box.TabIndex = 58;
            this.Total_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Accept_Number_Key_Press);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(745, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 19);
            this.label9.TabIndex = 57;
            this.label9.Text = "Purchase Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(418, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 55;
            this.label6.Text = "Quantity";
            // 
            // Quantity_Box
            // 
            this.Quantity_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Quantity_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity_Box.Location = new System.Drawing.Point(419, 287);
            this.Quantity_Box.Multiline = true;
            this.Quantity_Box.Name = "Quantity_Box";
            this.Quantity_Box.Size = new System.Drawing.Size(267, 35);
            this.Quantity_Box.TabIndex = 54;
            this.Quantity_Box.Text = "0";
            this.Quantity_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Accept_Number_Key_Press);
            this.Quantity_Box.Leave += new System.EventHandler(this.Total_Box_Value_Textbox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(416, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 19);
            this.label7.TabIndex = 53;
            this.label7.Text = "Product ID";
            // 
            // Product_ID_Box
            // 
            this.Product_ID_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Product_ID_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product_ID_Box.Location = new System.Drawing.Point(419, 198);
            this.Product_ID_Box.Multiline = true;
            this.Product_ID_Box.Name = "Product_ID_Box";
            this.Product_ID_Box.ReadOnly = true;
            this.Product_ID_Box.Size = new System.Drawing.Size(267, 35);
            this.Product_ID_Box.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "Purchase Price";
            // 
            // Purchase_Price_Box
            // 
            this.Purchase_Price_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Purchase_Price_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchase_Price_Box.Location = new System.Drawing.Point(122, 287);
            this.Purchase_Price_Box.Multiline = true;
            this.Purchase_Price_Box.Name = "Purchase_Price_Box";
            this.Purchase_Price_Box.Size = new System.Drawing.Size(232, 35);
            this.Purchase_Price_Box.TabIndex = 50;
            this.Purchase_Price_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Accept_Number_Key_Press);
            this.Purchase_Price_Box.Leave += new System.EventHandler(this.Total_Box_Value_Textbox_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1068, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 51);
            this.button1.TabIndex = 45;
            this.button1.Text = "PURCHASE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(91, 355);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1244, 343);
            this.dataGridView1.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(415, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 43;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 41;
            this.label3.Text = "Dealer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 45);
            this.label1.TabIndex = 38;
            this.label1.Text = "PURCHASE STOCKS";
            this.label1.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Proyek_UAS.Properties.Resources.Back_Arrow_smallhitbox;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(38, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 40);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(1068, 281);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(267, 51);
            this.deleteButton.TabIndex = 62;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Purchase_Date
            // 
            this.Purchase_Date.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Purchase_Date.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchase_Date.Location = new System.Drawing.Point(748, 113);
            this.Purchase_Date.Name = "Purchase_Date";
            this.Purchase_Date.Size = new System.Drawing.Size(267, 28);
            this.Purchase_Date.TabIndex = 63;
            // 
            // Dealer_Name_Box
            // 
            this.Dealer_Name_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Dealer_Name_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Dealer_Name_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Dealer_Name_Box.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Dealer_Name_Box.DropDownHeight = 110;
            this.Dealer_Name_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dealer_Name_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F);
            this.Dealer_Name_Box.FormattingEnabled = true;
            this.Dealer_Name_Box.IntegralHeight = false;
            this.Dealer_Name_Box.ItemHeight = 25;
            this.Dealer_Name_Box.Location = new System.Drawing.Point(91, 113);
            this.Dealer_Name_Box.MaxDropDownItems = 4;
            this.Dealer_Name_Box.Name = "Dealer_Name_Box";
            this.Dealer_Name_Box.Size = new System.Drawing.Size(266, 31);
            this.Dealer_Name_Box.Sorted = true;
            this.Dealer_Name_Box.TabIndex = 64;
            this.Dealer_Name_Box.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Dealer_Name_Box_DrawItem);
            this.Dealer_Name_Box.SelectedIndexChanged += new System.EventHandler(this.Dealer_Name_Box_SelectionIndexChanged);
            // 
            // Product_Name_Box
            // 
            this.Product_Name_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Product_Name_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Product_Name_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Product_Name_Box.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Product_Name_Box.DropDownHeight = 110;
            this.Product_Name_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F);
            this.Product_Name_Box.FormattingEnabled = true;
            this.Product_Name_Box.IntegralHeight = false;
            this.Product_Name_Box.ItemHeight = 25;
            this.Product_Name_Box.Location = new System.Drawing.Point(418, 113);
            this.Product_Name_Box.MaxDropDownItems = 4;
            this.Product_Name_Box.Name = "Product_Name_Box";
            this.Product_Name_Box.Size = new System.Drawing.Size(266, 31);
            this.Product_Name_Box.Sorted = true;
            this.Product_Name_Box.TabIndex = 65;
            this.Product_Name_Box.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Product_Name_Box_DrawItem);
            this.Product_Name_Box.SelectedIndexChanged += new System.EventHandler(this.Product_Name_Box_SelectionIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 19);
            this.label10.TabIndex = 66;
            this.label10.Text = "Rp";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(745, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 19);
            this.label11.TabIndex = 67;
            this.label11.Text = "Rp";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(138)))), ((int)(((byte)(111)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1068, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(267, 104);
            this.button2.TabIndex = 47;
            this.button2.Text = "STOCK LIST";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(87, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 19);
            this.label12.TabIndex = 69;
            this.label12.Text = "Dealer ID";
            // 
            // Dealer_ID_Box
            // 
            this.Dealer_ID_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Dealer_ID_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dealer_ID_Box.Location = new System.Drawing.Point(90, 200);
            this.Dealer_ID_Box.Multiline = true;
            this.Dealer_ID_Box.Name = "Dealer_ID_Box";
            this.Dealer_ID_Box.ReadOnly = true;
            this.Dealer_ID_Box.Size = new System.Drawing.Size(267, 35);
            this.Dealer_ID_Box.TabIndex = 68;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(750, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 19);
            this.label13.TabIndex = 71;
            this.label13.Text = "Selling Price";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(749, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 19);
            this.label14.TabIndex = 73;
            this.label14.Text = "Rp";
            // 
            // Selling_Price_Box
            // 
            this.Selling_Price_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.Selling_Price_Box.Font = new System.Drawing.Font("Roboto Condensed Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Selling_Price_Box.Location = new System.Drawing.Point(784, 200);
            this.Selling_Price_Box.Multiline = true;
            this.Selling_Price_Box.Name = "Selling_Price_Box";
            this.Selling_Price_Box.Size = new System.Drawing.Size(232, 35);
            this.Selling_Price_Box.TabIndex = 72;
            this.Selling_Price_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Accept_Number_Key_Press);
            this.Selling_Price_Box.Leave += new System.EventHandler(this.Selling_Price_Leave);
            // 
            // Purchase_Stocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1372, 726);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Selling_Price_Box);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Dealer_ID_Box);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Product_Name_Box);
            this.Controls.Add(this.Dealer_Name_Box);
            this.Controls.Add(this.Purchase_Date);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Total_Box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Quantity_Box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Product_ID_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Purchase_Price_Box);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Purchase_Stocks";
            this.Text = "Purchase Stocks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Add_Stocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Total_Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Quantity_Box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Product_ID_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Purchase_Price_Box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DateTimePicker Purchase_Date;
        private System.Windows.Forms.ComboBox Dealer_Name_Box;
        private System.Windows.Forms.ComboBox Product_Name_Box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Dealer_ID_Box;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Selling_Price_Box;
    }
}