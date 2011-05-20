namespace Foretagsplatsen.Api.TestClient
{
    partial class EditCompaniesForm
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
            this.cbCompanies = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.tbCompanyBusinessIdentityCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCompanyContactName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCompanyContactAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCompanyContactPostalAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCompanyContactPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateSelectedCompanty = new System.Windows.Forms.Button();
            this.btnRemoveSelectedCompany = new System.Windows.Forms.Button();
            this.btnGetCompanies = new System.Windows.Forms.Button();
            this.btnEditYearsForCompany = new System.Windows.Forms.Button();
            this.btnGotoSelectedCompany = new System.Windows.Forms.Button();
            this.btnCreateCompany = new System.Windows.Forms.Button();
            this.btnEditUsers = new System.Windows.Forms.Button();
            this.btnKeyFigures = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCompanies
            // 
            this.cbCompanies.FormattingEnabled = true;
            this.cbCompanies.Location = new System.Drawing.Point(12, 25);
            this.cbCompanies.Name = "cbCompanies";
            this.cbCompanies.Size = new System.Drawing.Size(226, 21);
            this.cbCompanies.TabIndex = 0;
            this.cbCompanies.SelectedIndexChanged += new System.EventHandler(this.cbCompanies_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Companies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company name";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(9, 32);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(198, 20);
            this.tbCompanyName.TabIndex = 3;
            // 
            // tbCompanyBusinessIdentityCode
            // 
            this.tbCompanyBusinessIdentityCode.Location = new System.Drawing.Point(9, 72);
            this.tbCompanyBusinessIdentityCode.Name = "tbCompanyBusinessIdentityCode";
            this.tbCompanyBusinessIdentityCode.ReadOnly = true;
            this.tbCompanyBusinessIdentityCode.Size = new System.Drawing.Size(198, 20);
            this.tbCompanyBusinessIdentityCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Business identity code";
            // 
            // tbCompanyContactName
            // 
            this.tbCompanyContactName.Location = new System.Drawing.Point(9, 32);
            this.tbCompanyContactName.Name = "tbCompanyContactName";
            this.tbCompanyContactName.Size = new System.Drawing.Size(198, 20);
            this.tbCompanyContactName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name";
            // 
            // tbCompanyContactAddress
            // 
            this.tbCompanyContactAddress.Location = new System.Drawing.Point(226, 32);
            this.tbCompanyContactAddress.Name = "tbCompanyContactAddress";
            this.tbCompanyContactAddress.Size = new System.Drawing.Size(198, 20);
            this.tbCompanyContactAddress.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Address";
            // 
            // tbCompanyContactPostalAddress
            // 
            this.tbCompanyContactPostalAddress.Location = new System.Drawing.Point(9, 75);
            this.tbCompanyContactPostalAddress.Name = "tbCompanyContactPostalAddress";
            this.tbCompanyContactPostalAddress.Size = new System.Drawing.Size(198, 20);
            this.tbCompanyContactPostalAddress.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Postal address";
            // 
            // tbCompanyContactPhone
            // 
            this.tbCompanyContactPhone.Location = new System.Drawing.Point(226, 75);
            this.tbCompanyContactPhone.Name = "tbCompanyContactPhone";
            this.tbCompanyContactPhone.Size = new System.Drawing.Size(198, 20);
            this.tbCompanyContactPhone.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phone";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCompanyContactAddress);
            this.groupBox1.Controls.Add(this.tbCompanyContactPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbCompanyContactName);
            this.groupBox1.Controls.Add(this.tbCompanyContactPostalAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(15, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 113);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company contact info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbCompanyName);
            this.groupBox2.Controls.Add(this.tbCompanyBusinessIdentityCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(15, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 107);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Company";
            // 
            // btnUpdateSelectedCompanty
            // 
            this.btnUpdateSelectedCompanty.Location = new System.Drawing.Point(260, 156);
            this.btnUpdateSelectedCompanty.Name = "btnUpdateSelectedCompanty";
            this.btnUpdateSelectedCompanty.Size = new System.Drawing.Size(179, 23);
            this.btnUpdateSelectedCompanty.TabIndex = 16;
            this.btnUpdateSelectedCompanty.Text = "Update selected company";
            this.btnUpdateSelectedCompanty.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedCompanty.Click += new System.EventHandler(this.btnUpdateSelectedCompany_Click);
            // 
            // btnRemoveSelectedCompany
            // 
            this.btnRemoveSelectedCompany.Location = new System.Drawing.Point(260, 185);
            this.btnRemoveSelectedCompany.Name = "btnRemoveSelectedCompany";
            this.btnRemoveSelectedCompany.Size = new System.Drawing.Size(179, 23);
            this.btnRemoveSelectedCompany.TabIndex = 17;
            this.btnRemoveSelectedCompany.Text = "Remove selected company";
            this.btnRemoveSelectedCompany.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedCompany.Click += new System.EventHandler(this.btnRemoveSelectedCompany_Click);
            // 
            // btnGetCompanies
            // 
            this.btnGetCompanies.Location = new System.Drawing.Point(260, 25);
            this.btnGetCompanies.Name = "btnGetCompanies";
            this.btnGetCompanies.Size = new System.Drawing.Size(179, 23);
            this.btnGetCompanies.TabIndex = 18;
            this.btnGetCompanies.Text = "Fetch companies";
            this.btnGetCompanies.UseVisualStyleBackColor = true;
            this.btnGetCompanies.Click += new System.EventHandler(this.btnGetCompanies_Click);
            // 
            // btnEditYearsForCompany
            // 
            this.btnEditYearsForCompany.Location = new System.Drawing.Point(260, 98);
            this.btnEditYearsForCompany.Name = "btnEditYearsForCompany";
            this.btnEditYearsForCompany.Size = new System.Drawing.Size(179, 23);
            this.btnEditYearsForCompany.TabIndex = 19;
            this.btnEditYearsForCompany.Text = "Edit years for company";
            this.btnEditYearsForCompany.UseVisualStyleBackColor = true;
            this.btnEditYearsForCompany.Click += new System.EventHandler(this.btnEditYearsForCompany_Click);
            // 
            // btnGotoSelectedCompany
            // 
            this.btnGotoSelectedCompany.Location = new System.Drawing.Point(260, 243);
            this.btnGotoSelectedCompany.Name = "btnGotoSelectedCompany";
            this.btnGotoSelectedCompany.Size = new System.Drawing.Size(179, 23);
            this.btnGotoSelectedCompany.TabIndex = 20;
            this.btnGotoSelectedCompany.Text = "Goto selected company";
            this.btnGotoSelectedCompany.UseVisualStyleBackColor = true;
            this.btnGotoSelectedCompany.Click += new System.EventHandler(this.btnGotoSelectedCompany_Click);
            // 
            // btnCreateCompany
            // 
            this.btnCreateCompany.Location = new System.Drawing.Point(260, 69);
            this.btnCreateCompany.Name = "btnCreateCompany";
            this.btnCreateCompany.Size = new System.Drawing.Size(179, 23);
            this.btnCreateCompany.TabIndex = 21;
            this.btnCreateCompany.Text = "Create company";
            this.btnCreateCompany.UseVisualStyleBackColor = true;
            this.btnCreateCompany.Click += new System.EventHandler(this.btnCreateCompany_Click);
            // 
            // btnEditUsers
            // 
            this.btnEditUsers.Location = new System.Drawing.Point(260, 127);
            this.btnEditUsers.Name = "btnEditUsers";
            this.btnEditUsers.Size = new System.Drawing.Size(179, 23);
            this.btnEditUsers.TabIndex = 22;
            this.btnEditUsers.Text = "Edit users for company";
            this.btnEditUsers.UseVisualStyleBackColor = true;
            this.btnEditUsers.Click += new System.EventHandler(this.btnEditUsers_Click);
            // 
            // btnKeyFigures
            // 
            this.btnKeyFigures.Location = new System.Drawing.Point(260, 214);
            this.btnKeyFigures.Name = "btnKeyFigures";
            this.btnKeyFigures.Size = new System.Drawing.Size(179, 23);
            this.btnKeyFigures.TabIndex = 23;
            this.btnKeyFigures.Text = "KeyFigures";
            this.btnKeyFigures.UseVisualStyleBackColor = true;
            this.btnKeyFigures.Click += new System.EventHandler(this.btnKeyFigures_Click);
            // 
            // EditCompaniesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 431);
            this.Controls.Add(this.btnKeyFigures);
            this.Controls.Add(this.btnEditUsers);
            this.Controls.Add(this.btnCreateCompany);
            this.Controls.Add(this.btnGotoSelectedCompany);
            this.Controls.Add(this.btnEditYearsForCompany);
            this.Controls.Add(this.btnGetCompanies);
            this.Controls.Add(this.btnRemoveSelectedCompany);
            this.Controls.Add(this.btnUpdateSelectedCompanty);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCompanies);
            this.Name = "EditCompaniesForm";
            this.Text = "EditCompaniesForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCompanies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.TextBox tbCompanyBusinessIdentityCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCompanyContactName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCompanyContactAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCompanyContactPostalAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCompanyContactPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdateSelectedCompanty;
        private System.Windows.Forms.Button btnRemoveSelectedCompany;
        private System.Windows.Forms.Button btnGetCompanies;
        private System.Windows.Forms.Button btnEditYearsForCompany;
        private System.Windows.Forms.Button btnGotoSelectedCompany;
        private System.Windows.Forms.Button btnCreateCompany;
        private System.Windows.Forms.Button btnEditUsers;
        private System.Windows.Forms.Button btnKeyFigures;
    }
}