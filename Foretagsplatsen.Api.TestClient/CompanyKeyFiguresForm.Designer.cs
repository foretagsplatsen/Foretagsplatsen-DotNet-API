namespace Foretagsplatsen.Api.TestClient
{
    partial class CompanyKeyFiguresForm
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
            this.tbBusinessIdentityCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrossMargin = new System.Windows.Forms.Button();
            this.tbKeyFigureResult = new System.Windows.Forms.TextBox();
            this.btnTurnover = new System.Windows.Forms.Button();
            this.btnProfit = new System.Windows.Forms.Button();
            this.btnCostsForEmployees = new System.Windows.Forms.Button();
            this.btnGrossProfitMargin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCompantStartDate = new System.Windows.Forms.TextBox();
            this.tbCompantEndDate = new System.Windows.Forms.TextBox();
            this.tbArgumentString = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mcStartDate = new System.Windows.Forms.MonthCalendar();
            this.label8 = new System.Windows.Forms.Label();
            this.mcEndDate = new System.Windows.Forms.MonthCalendar();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClearStartDate = new System.Windows.Forms.Button();
            this.btnClearEndDate = new System.Windows.Forms.Button();
            this.btnAllKeyFigures = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBusinessIdentityCode
            // 
            this.tbBusinessIdentityCode.Location = new System.Drawing.Point(134, 10);
            this.tbBusinessIdentityCode.Name = "tbBusinessIdentityCode";
            this.tbBusinessIdentityCode.ReadOnly = true;
            this.tbBusinessIdentityCode.Size = new System.Drawing.Size(138, 20);
            this.tbBusinessIdentityCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Business identity code:";
            // 
            // btnGrossMargin
            // 
            this.btnGrossMargin.Location = new System.Drawing.Point(16, 390);
            this.btnGrossMargin.Name = "btnGrossMargin";
            this.btnGrossMargin.Size = new System.Drawing.Size(112, 23);
            this.btnGrossMargin.TabIndex = 2;
            this.btnGrossMargin.Text = "Grossmargin";
            this.btnGrossMargin.UseVisualStyleBackColor = true;
            this.btnGrossMargin.Click += new System.EventHandler(this.btnGrossMargin_Click);
            // 
            // tbKeyFigureResult
            // 
            this.tbKeyFigureResult.Location = new System.Drawing.Point(134, 303);
            this.tbKeyFigureResult.Multiline = true;
            this.tbKeyFigureResult.Name = "tbKeyFigureResult";
            this.tbKeyFigureResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbKeyFigureResult.Size = new System.Drawing.Size(363, 237);
            this.tbKeyFigureResult.TabIndex = 3;
            // 
            // btnTurnover
            // 
            this.btnTurnover.Location = new System.Drawing.Point(16, 303);
            this.btnTurnover.Name = "btnTurnover";
            this.btnTurnover.Size = new System.Drawing.Size(112, 23);
            this.btnTurnover.TabIndex = 4;
            this.btnTurnover.Text = "Turnover";
            this.btnTurnover.UseVisualStyleBackColor = true;
            this.btnTurnover.Click += new System.EventHandler(this.btnTurnover_Click);
            // 
            // btnProfit
            // 
            this.btnProfit.Location = new System.Drawing.Point(16, 332);
            this.btnProfit.Name = "btnProfit";
            this.btnProfit.Size = new System.Drawing.Size(112, 23);
            this.btnProfit.TabIndex = 5;
            this.btnProfit.Text = "Profit";
            this.btnProfit.UseVisualStyleBackColor = true;
            this.btnProfit.Click += new System.EventHandler(this.btnProfit_Click);
            // 
            // btnCostsForEmployees
            // 
            this.btnCostsForEmployees.Location = new System.Drawing.Point(16, 419);
            this.btnCostsForEmployees.Name = "btnCostsForEmployees";
            this.btnCostsForEmployees.Size = new System.Drawing.Size(112, 23);
            this.btnCostsForEmployees.TabIndex = 7;
            this.btnCostsForEmployees.Text = "CostsForEmployees";
            this.btnCostsForEmployees.UseVisualStyleBackColor = true;
            this.btnCostsForEmployees.Click += new System.EventHandler(this.btnCostsForEmployees_Click);
            // 
            // btnGrossProfitMargin
            // 
            this.btnGrossProfitMargin.Location = new System.Drawing.Point(16, 361);
            this.btnGrossProfitMargin.Name = "btnGrossProfitMargin";
            this.btnGrossProfitMargin.Size = new System.Drawing.Size(112, 23);
            this.btnGrossProfitMargin.TabIndex = 6;
            this.btnGrossProfitMargin.Text = "GrossProfitmargin";
            this.btnGrossProfitMargin.UseVisualStyleBackColor = true;
            this.btnGrossProfitMargin.Click += new System.EventHandler(this.btnGrossProfitMargin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Start date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End date";
            // 
            // tbCompantStartDate
            // 
            this.tbCompantStartDate.Location = new System.Drawing.Point(73, 36);
            this.tbCompantStartDate.Name = "tbCompantStartDate";
            this.tbCompantStartDate.ReadOnly = true;
            this.tbCompantStartDate.Size = new System.Drawing.Size(154, 20);
            this.tbCompantStartDate.TabIndex = 13;
            // 
            // tbCompantEndDate
            // 
            this.tbCompantEndDate.Location = new System.Drawing.Point(298, 36);
            this.tbCompantEndDate.Name = "tbCompantEndDate";
            this.tbCompantEndDate.ReadOnly = true;
            this.tbCompantEndDate.Size = new System.Drawing.Size(154, 20);
            this.tbCompantEndDate.TabIndex = 14;
            // 
            // tbArgumentString
            // 
            this.tbArgumentString.Location = new System.Drawing.Point(134, 274);
            this.tbArgumentString.Name = "tbArgumentString";
            this.tbArgumentString.ReadOnly = true;
            this.tbArgumentString.Size = new System.Drawing.Size(345, 20);
            this.tbArgumentString.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Argument string";
            // 
            // mcStartDate
            // 
            this.mcStartDate.Location = new System.Drawing.Point(20, 86);
            this.mcStartDate.MaxSelectionCount = 1;
            this.mcStartDate.Name = "mcStartDate";
            this.mcStartDate.TabIndex = 17;
            this.mcStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcStartDate_DateSelected);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Select start date";
            // 
            // mcEndDate
            // 
            this.mcEndDate.Location = new System.Drawing.Point(228, 86);
            this.mcEndDate.MaxSelectionCount = 1;
            this.mcEndDate.Name = "mcEndDate";
            this.mcEndDate.TabIndex = 19;
            this.mcEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcEndDate_DateSelected);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Select end date";
            // 
            // btnClearStartDate
            // 
            this.btnClearStartDate.Location = new System.Drawing.Point(103, 59);
            this.btnClearStartDate.Name = "btnClearStartDate";
            this.btnClearStartDate.Size = new System.Drawing.Size(88, 23);
            this.btnClearStartDate.TabIndex = 21;
            this.btnClearStartDate.Text = "Clear start date";
            this.btnClearStartDate.UseVisualStyleBackColor = true;
            this.btnClearStartDate.Click += new System.EventHandler(this.btnClearStartDate_Click);
            // 
            // btnClearEndDate
            // 
            this.btnClearEndDate.Location = new System.Drawing.Point(311, 59);
            this.btnClearEndDate.Name = "btnClearEndDate";
            this.btnClearEndDate.Size = new System.Drawing.Size(88, 23);
            this.btnClearEndDate.TabIndex = 22;
            this.btnClearEndDate.Text = "Clear end date";
            this.btnClearEndDate.UseVisualStyleBackColor = true;
            this.btnClearEndDate.Click += new System.EventHandler(this.btnClearEndDate_Click);
            // 
            // btnAllKeyFigures
            // 
            this.btnAllKeyFigures.Location = new System.Drawing.Point(16, 448);
            this.btnAllKeyFigures.Name = "btnAllKeyFigures";
            this.btnAllKeyFigures.Size = new System.Drawing.Size(112, 23);
            this.btnAllKeyFigures.TabIndex = 23;
            this.btnAllKeyFigures.Text = "All key figures";
            this.btnAllKeyFigures.UseVisualStyleBackColor = true;
            this.btnAllKeyFigures.Click += new System.EventHandler(this.btnAllKeyFigures_Click);
            // 
            // CompanyKeyFiguresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 551);
            this.Controls.Add(this.btnAllKeyFigures);
            this.Controls.Add(this.btnClearEndDate);
            this.Controls.Add(this.btnClearStartDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mcEndDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mcStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbArgumentString);
            this.Controls.Add(this.tbCompantEndDate);
            this.Controls.Add(this.tbCompantStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCostsForEmployees);
            this.Controls.Add(this.btnGrossProfitMargin);
            this.Controls.Add(this.btnProfit);
            this.Controls.Add(this.btnTurnover);
            this.Controls.Add(this.tbKeyFigureResult);
            this.Controls.Add(this.btnGrossMargin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBusinessIdentityCode);
            this.Name = "CompanyKeyFiguresForm";
            this.Text = "CompanyKeyFiguresForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBusinessIdentityCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrossMargin;
        private System.Windows.Forms.TextBox tbKeyFigureResult;
        private System.Windows.Forms.Button btnTurnover;
        private System.Windows.Forms.Button btnProfit;
        private System.Windows.Forms.Button btnCostsForEmployees;
        private System.Windows.Forms.Button btnGrossProfitMargin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCompantStartDate;
        private System.Windows.Forms.TextBox tbCompantEndDate;
        private System.Windows.Forms.TextBox tbArgumentString;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MonthCalendar mcStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar mcEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClearStartDate;
        private System.Windows.Forms.Button btnClearEndDate;
        private System.Windows.Forms.Button btnAllKeyFigures;
    }
}