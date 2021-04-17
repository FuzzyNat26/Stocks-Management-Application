
namespace Proyek_UAS
{
    partial class Sales_History
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
            this.Data_Sales_History_View = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Data_SalesID_ProductHistory_View = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.Print_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Sales_History_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data_SalesID_ProductHistory_View)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_Sales_History_View
            // 
            this.Data_Sales_History_View.AllowUserToAddRows = false;
            this.Data_Sales_History_View.AllowUserToDeleteRows = false;
            this.Data_Sales_History_View.AllowUserToOrderColumns = true;
            this.Data_Sales_History_View.AllowUserToResizeColumns = false;
            this.Data_Sales_History_View.AllowUserToResizeRows = false;
            this.Data_Sales_History_View.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Data_Sales_History_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Sales_History_View.Location = new System.Drawing.Point(85, 134);
            this.Data_Sales_History_View.Name = "Data_Sales_History_View";
            this.Data_Sales_History_View.ReadOnly = true;
            this.Data_Sales_History_View.RowHeadersWidth = 51;
            this.Data_Sales_History_View.RowTemplate.Height = 24;
            this.Data_Sales_History_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data_Sales_History_View.Size = new System.Drawing.Size(567, 417);
            this.Data_Sales_History_View.TabIndex = 71;
            this.Data_Sales_History_View.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_Sales_History_View_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Proyek_UAS.Properties.Resources.Back_Arrow_smallhitbox;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(32, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 40);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 45);
            this.label1.TabIndex = 64;
            this.label1.Text = "SALES HISTORY";
            this.label1.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Data_SalesID_ProductHistory_View
            // 
            this.Data_SalesID_ProductHistory_View.AllowUserToAddRows = false;
            this.Data_SalesID_ProductHistory_View.AllowUserToDeleteRows = false;
            this.Data_SalesID_ProductHistory_View.AllowUserToOrderColumns = true;
            this.Data_SalesID_ProductHistory_View.AllowUserToResizeColumns = false;
            this.Data_SalesID_ProductHistory_View.AllowUserToResizeRows = false;
            this.Data_SalesID_ProductHistory_View.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Data_SalesID_ProductHistory_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_SalesID_ProductHistory_View.Location = new System.Drawing.Point(720, 134);
            this.Data_SalesID_ProductHistory_View.Name = "Data_SalesID_ProductHistory_View";
            this.Data_SalesID_ProductHistory_View.ReadOnly = true;
            this.Data_SalesID_ProductHistory_View.RowHeadersWidth = 51;
            this.Data_SalesID_ProductHistory_View.RowTemplate.Height = 24;
            this.Data_SalesID_ProductHistory_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data_SalesID_ProductHistory_View.Size = new System.Drawing.Size(567, 546);
            this.Data_SalesID_ProductHistory_View.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 19);
            this.label3.TabIndex = 67;
            this.label3.Text = "Sales History";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(716, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 69;
            this.label5.Text = "Product List";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(85, 567);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(567, 51);
            this.deleteButton.TabIndex = 77;
            this.deleteButton.Text = "DELETE SALES";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(204)))), ((int)(((byte)(236)))));
            this.Print_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Print_Button.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Button.ForeColor = System.Drawing.Color.White;
            this.Print_Button.Location = new System.Drawing.Point(85, 629);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(567, 51);
            this.Print_Button.TabIndex = 78;
            this.Print_Button.Text = "PRINT SELECTED";
            this.Print_Button.UseVisualStyleBackColor = false;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // Sales_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1328, 713);
            this.Controls.Add(this.Print_Button);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.Data_SalesID_ProductHistory_View);
            this.Controls.Add(this.Data_Sales_History_View);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Sales_History";
            this.Text = "Sales History";
            this.Load += new System.EventHandler(this.Sales_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Sales_History_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data_SalesID_ProductHistory_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Data_Sales_History_View;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Data_SalesID_ProductHistory_View;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button Print_Button;
    }
}