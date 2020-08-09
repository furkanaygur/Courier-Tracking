namespace Gorsel_Programlama_Proje
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.AlicilarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KuryeTakipDataSet = new Gorsel_Programlama_Proje.KuryeTakipDataSet();
            this.AlicilarTableAdapter = new Gorsel_Programlama_Proje.KuryeTakipDataSetTableAdapters.AlicilarTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AlicilarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KuryeTakipDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.AlicilarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gorsel_Programlama_Proje.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(426, 818);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "...";
            this.label1.Visible = false;
            // 
            // AlicilarBindingSource
            // 
            this.AlicilarBindingSource.DataMember = "Alicilar";
            this.AlicilarBindingSource.DataSource = this.KuryeTakipDataSet;
            // 
            // KuryeTakipDataSet
            // 
            this.KuryeTakipDataSet.DataSetName = "KuryeTakipDataSet";
            this.KuryeTakipDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AlicilarTableAdapter
            // 
            this.AlicilarTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 818);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlicilarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KuryeTakipDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AlicilarBindingSource;
        private KuryeTakipDataSet KuryeTakipDataSet;
        private KuryeTakipDataSetTableAdapters.AlicilarTableAdapter AlicilarTableAdapter;
        private System.Windows.Forms.Label label1;

    }
}