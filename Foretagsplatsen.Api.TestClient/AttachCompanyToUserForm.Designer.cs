namespace Foretagsplatsen.Api.TestClient
{
    partial class AttachCompanyToUserForm
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
            this.lbCompaniesThatCanBeAttached = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAttachCompany = new System.Windows.Forms.Button();
            this.tbCurrentUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCompaniesThatCanBeAttached
            // 
            this.lbCompaniesThatCanBeAttached.FormattingEnabled = true;
            this.lbCompaniesThatCanBeAttached.Location = new System.Drawing.Point(12, 92);
            this.lbCompaniesThatCanBeAttached.Name = "lbCompaniesThatCanBeAttached";
            this.lbCompaniesThatCanBeAttached.Size = new System.Drawing.Size(205, 264);
            this.lbCompaniesThatCanBeAttached.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCurrentUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected user";
            // 
            // btnAttachCompany
            // 
            this.btnAttachCompany.Location = new System.Drawing.Point(79, 362);
            this.btnAttachCompany.Name = "btnAttachCompany";
            this.btnAttachCompany.Size = new System.Drawing.Size(138, 23);
            this.btnAttachCompany.TabIndex = 3;
            this.btnAttachCompany.Text = "Attach selected company";
            this.btnAttachCompany.UseVisualStyleBackColor = true;
            this.btnAttachCompany.Click += new System.EventHandler(this.btnAttachCompany_Click);
            // 
            // tbCurrentUsername
            // 
            this.tbCurrentUsername.Location = new System.Drawing.Point(67, 13);
            this.tbCurrentUsername.Name = "tbCurrentUsername";
            this.tbCurrentUsername.ReadOnly = true;
            this.tbCurrentUsername.Size = new System.Drawing.Size(116, 20);
            this.tbCurrentUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Companies not attached to user";
            // 
            // AttachCompanyToUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAttachCompany);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbCompaniesThatCanBeAttached);
            this.Name = "AttachCompanyToUserForm";
            this.Text = "AttachCompanyToUserForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCompaniesThatCanBeAttached;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCurrentUsername;
        private System.Windows.Forms.Button btnAttachCompany;
        private System.Windows.Forms.Label label2;
    }
}