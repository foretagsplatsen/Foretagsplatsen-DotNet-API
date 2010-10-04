namespace Foretagsplatsen.Api.TestClient
{
    partial class EditYearsForCompanyForm
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
            this.btnDeleteSelectedYear = new System.Windows.Forms.Button();
            this.tbStartOfYear = new System.Windows.Forms.TextBox();
            this.tbYearId = new System.Windows.Forms.TextBox();
            this.tbEndOfYear = new System.Windows.Forms.TextBox();
            this.tbLastLedgerDate = new System.Windows.Forms.TextBox();
            this.tbCurrency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBusinessIdentityCode = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.btnFetchYears = new System.Windows.Forms.Button();
            this.cbCompanyYears = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbChartOfAccount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDeleteSelectedYear
            // 
            this.btnDeleteSelectedYear.Location = new System.Drawing.Point(363, 118);
            this.btnDeleteSelectedYear.Name = "btnDeleteSelectedYear";
            this.btnDeleteSelectedYear.Size = new System.Drawing.Size(137, 23);
            this.btnDeleteSelectedYear.TabIndex = 1;
            this.btnDeleteSelectedYear.Text = "Delete selected year";
            this.btnDeleteSelectedYear.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedYear.Click += new System.EventHandler(this.btnDeleteSelectedYear_Click);
            // 
            // tbStartOfYear
            // 
            this.tbStartOfYear.Enabled = false;
            this.tbStartOfYear.Location = new System.Drawing.Point(15, 171);
            this.tbStartOfYear.Name = "tbStartOfYear";
            this.tbStartOfYear.Size = new System.Drawing.Size(150, 20);
            this.tbStartOfYear.TabIndex = 2;
            // 
            // tbYearId
            // 
            this.tbYearId.Location = new System.Drawing.Point(15, 118);
            this.tbYearId.Name = "tbYearId";
            this.tbYearId.ReadOnly = true;
            this.tbYearId.Size = new System.Drawing.Size(322, 20);
            this.tbYearId.TabIndex = 3;
            // 
            // tbEndOfYear
            // 
            this.tbEndOfYear.Enabled = false;
            this.tbEndOfYear.Location = new System.Drawing.Point(171, 171);
            this.tbEndOfYear.Name = "tbEndOfYear";
            this.tbEndOfYear.Size = new System.Drawing.Size(166, 20);
            this.tbEndOfYear.TabIndex = 4;
            // 
            // tbLastLedgerDate
            // 
            this.tbLastLedgerDate.Enabled = false;
            this.tbLastLedgerDate.Location = new System.Drawing.Point(171, 209);
            this.tbLastLedgerDate.Name = "tbLastLedgerDate";
            this.tbLastLedgerDate.Size = new System.Drawing.Size(166, 20);
            this.tbLastLedgerDate.TabIndex = 5;
            // 
            // tbCurrency
            // 
            this.tbCurrency.Enabled = false;
            this.tbCurrency.Location = new System.Drawing.Point(15, 208);
            this.tbCurrency.Name = "tbCurrency";
            this.tbCurrency.Size = new System.Drawing.Size(150, 20);
            this.tbCurrency.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "End of year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Currency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start of year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Last ledger date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Year id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Years for current company";
            // 
            // tbBusinessIdentityCode
            // 
            this.tbBusinessIdentityCode.Location = new System.Drawing.Point(15, 25);
            this.tbBusinessIdentityCode.Name = "tbBusinessIdentityCode";
            this.tbBusinessIdentityCode.ReadOnly = true;
            this.tbBusinessIdentityCode.Size = new System.Drawing.Size(322, 20);
            this.tbBusinessIdentityCode.TabIndex = 13;
            this.tbBusinessIdentityCode.Text = "556679-1215";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(12, 9);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(212, 13);
            this.label100.TabIndex = 14;
            this.label100.Text = "Business identity code for company to fetch";
            // 
            // btnFetchYears
            // 
            this.btnFetchYears.Location = new System.Drawing.Point(363, 22);
            this.btnFetchYears.Name = "btnFetchYears";
            this.btnFetchYears.Size = new System.Drawing.Size(139, 23);
            this.btnFetchYears.TabIndex = 15;
            this.btnFetchYears.Text = "Fetch Years for Company";
            this.btnFetchYears.UseVisualStyleBackColor = true;
            this.btnFetchYears.Click += new System.EventHandler(this.btnFetchYears_Click);
            // 
            // cbCompanyYears
            // 
            this.cbCompanyYears.FormattingEnabled = true;
            this.cbCompanyYears.Location = new System.Drawing.Point(15, 75);
            this.cbCompanyYears.Name = "cbCompanyYears";
            this.cbCompanyYears.Size = new System.Drawing.Size(322, 21);
            this.cbCompanyYears.TabIndex = 18;
            this.cbCompanyYears.SelectedIndexChanged += new System.EventHandler(this.cbCompanyYears_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Chart of account type";
            // 
            // tbChartOfAccount
            // 
            this.tbChartOfAccount.Enabled = false;
            this.tbChartOfAccount.Location = new System.Drawing.Point(15, 247);
            this.tbChartOfAccount.Name = "tbChartOfAccount";
            this.tbChartOfAccount.Size = new System.Drawing.Size(150, 20);
            this.tbChartOfAccount.TabIndex = 20;
            // 
            // EditYearsForCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 304);
            this.Controls.Add(this.tbChartOfAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbCompanyYears);
            this.Controls.Add(this.btnFetchYears);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.tbBusinessIdentityCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCurrency);
            this.Controls.Add(this.tbLastLedgerDate);
            this.Controls.Add(this.tbEndOfYear);
            this.Controls.Add(this.tbYearId);
            this.Controls.Add(this.tbStartOfYear);
            this.Controls.Add(this.btnDeleteSelectedYear);
            this.Name = "EditYearsForCompanyForm";
            this.Text = "EditYearsForCompanyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteSelectedYear;
        private System.Windows.Forms.TextBox tbStartOfYear;
        private System.Windows.Forms.TextBox tbYearId;
        private System.Windows.Forms.TextBox tbEndOfYear;
        private System.Windows.Forms.TextBox tbLastLedgerDate;
        private System.Windows.Forms.TextBox tbCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbBusinessIdentityCode;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Button btnFetchYears;
        private System.Windows.Forms.ComboBox cbCompanyYears;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbChartOfAccount;
    }
}