namespace Foretagsplatsen.Api.TestClient
{
    partial class CreateCompanyForm
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
            this.btnCreateCompany = new System.Windows.Forms.Button();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBusinessIdentityCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbContactName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbContactAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbContactPostalAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbContactPhone = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateCompany
            // 
            this.btnCreateCompany.Location = new System.Drawing.Point(214, 313);
            this.btnCreateCompany.Name = "btnCreateCompany";
            this.btnCreateCompany.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCompany.TabIndex = 0;
            this.btnCreateCompany.Text = "Create";
            this.btnCreateCompany.UseVisualStyleBackColor = true;
            this.btnCreateCompany.Click += new System.EventHandler(this.btnCreateCompany_Click);
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(15, 25);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(196, 20);
            this.tbCompanyName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Company name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Business identity code";
            // 
            // tbBusinessIdentityCode
            // 
            this.tbBusinessIdentityCode.Location = new System.Drawing.Point(15, 64);
            this.tbBusinessIdentityCode.Name = "tbBusinessIdentityCode";
            this.tbBusinessIdentityCode.Size = new System.Drawing.Size(196, 20);
            this.tbBusinessIdentityCode.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbContactPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbContactPostalAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbContactAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbContactName);
            this.groupBox1.Location = new System.Drawing.Point(15, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 193);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact information";
            // 
            // tbContactName
            // 
            this.tbContactName.Location = new System.Drawing.Point(6, 32);
            this.tbContactName.Name = "tbContactName";
            this.tbContactName.Size = new System.Drawing.Size(174, 20);
            this.tbContactName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "E-mail";
            // 
            // tbContactAddress
            // 
            this.tbContactAddress.Location = new System.Drawing.Point(6, 74);
            this.tbContactAddress.Name = "tbContactAddress";
            this.tbContactAddress.Size = new System.Drawing.Size(174, 20);
            this.tbContactAddress.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Postal address";
            // 
            // tbContactPostalAddress
            // 
            this.tbContactPostalAddress.Location = new System.Drawing.Point(6, 115);
            this.tbContactPostalAddress.Name = "tbContactPostalAddress";
            this.tbContactPostalAddress.Size = new System.Drawing.Size(174, 20);
            this.tbContactPostalAddress.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Phone";
            // 
            // tbContactPhone
            // 
            this.tbContactPhone.Location = new System.Drawing.Point(6, 154);
            this.tbContactPhone.Name = "tbContactPhone";
            this.tbContactPhone.Size = new System.Drawing.Size(174, 20);
            this.tbContactPhone.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(133, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CreateCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 348);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBusinessIdentityCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCompanyName);
            this.Controls.Add(this.btnCreateCompany);
            this.Name = "CreateCompanyForm";
            this.Text = "CreateCompanyForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateCompany;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBusinessIdentityCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbContactPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbContactPostalAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbContactAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbContactName;
        private System.Windows.Forms.Button btnCancel;
    }
}