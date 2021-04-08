
namespace Proyek_UAS
{
    partial class Sales_Report
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
            this.Print_Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Print_Report
            // 
            this.Print_Report.ActiveViewIndex = -1;
            this.Print_Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Print_Report.Cursor = System.Windows.Forms.Cursors.Default;
            this.Print_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Print_Report.Location = new System.Drawing.Point(0, 0);
            this.Print_Report.Name = "Print_Report";
            this.Print_Report.Size = new System.Drawing.Size(1102, 646);
            this.Print_Report.TabIndex = 0;
            this.Print_Report.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // Sales_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 646);
            this.Controls.Add(this.Print_Report);
            this.Name = "Sales_Report";
            this.Text = "Sales Report";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Print_Report;
    }
}