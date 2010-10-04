namespace Foretagsplatsen.Api.TestClient
{
    partial class ExportSieForm
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
            this.btnExport = new System.Windows.Forms.Button();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLatestTransactionDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openSieFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectSieFile = new System.Windows.Forms.Button();
            this.tbSieFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbChartOfAccount = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(219, 331);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbCurrency
            // 
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(15, 122);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(170, 21);
            this.cbCurrency.Sorted = true;
            this.cbCurrency.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Currency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Projects";
            // 
            // lbProjects
            // 
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.Location = new System.Drawing.Point(15, 234);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbProjects.Size = new System.Drawing.Size(170, 121);
            this.lbProjects.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Latest transaction day";
            // 
            // tbLatestTransactionDay
            // 
            this.tbLatestTransactionDay.Location = new System.Drawing.Point(15, 83);
            this.tbLatestTransactionDay.Name = "tbLatestTransactionDay";
            this.tbLatestTransactionDay.Size = new System.Drawing.Size(170, 20);
            this.tbLatestTransactionDay.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select sie file";
            // 
            // openSieFileDialog
            // 
            this.openSieFileDialog.FileName = "openSieFileDialog";
            this.openSieFileDialog.Title = "Select a sie file";
            // 
            // btnSelectSieFile
            // 
            this.btnSelectSieFile.Location = new System.Drawing.Point(219, 31);
            this.btnSelectSieFile.Name = "btnSelectSieFile";
            this.btnSelectSieFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSieFile.TabIndex = 8;
            this.btnSelectSieFile.Text = "Browse";
            this.btnSelectSieFile.UseVisualStyleBackColor = true;
            this.btnSelectSieFile.Click += new System.EventHandler(this.btnSelectSieFile_Click);
            // 
            // tbSieFile
            // 
            this.tbSieFile.Location = new System.Drawing.Point(18, 31);
            this.tbSieFile.Name = "tbSieFile";
            this.tbSieFile.Size = new System.Drawing.Size(167, 20);
            this.tbSieFile.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chart of account type";
            // 
            // cbChartOfAccount
            // 
            this.cbChartOfAccount.FormattingEnabled = true;
            this.cbChartOfAccount.Location = new System.Drawing.Point(18, 162);
            this.cbChartOfAccount.Name = "cbChartOfAccount";
            this.cbChartOfAccount.Size = new System.Drawing.Size(170, 21);
            this.cbChartOfAccount.Sorted = true;
            this.cbChartOfAccount.TabIndex = 11;
            // 
            // ExportSieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 366);
            this.Controls.Add(this.cbChartOfAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSieFile);
            this.Controls.Add(this.btnSelectSieFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLatestTransactionDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbProjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.btnExport);
            this.Name = "ExportSieForm";
            this.Text = "ExportSieForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLatestTransactionDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openSieFileDialog;
        private System.Windows.Forms.Button btnSelectSieFile;
        private System.Windows.Forms.TextBox tbSieFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbChartOfAccount;
    }
}