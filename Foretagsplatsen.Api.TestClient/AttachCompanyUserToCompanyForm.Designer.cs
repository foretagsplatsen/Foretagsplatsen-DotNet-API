namespace Foretagsplatsen.Api.TestClient
{
    partial class AttachCompanyUserToCompanyForm
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
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnAttachUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCompanyUsers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCompanyRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(134, 291);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(71, 23);
            this.btnCloseForm.TabIndex = 7;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnAttachUser
            // 
            this.btnAttachUser.Location = new System.Drawing.Point(12, 291);
            this.btnAttachUser.Name = "btnAttachUser";
            this.btnAttachUser.Size = new System.Drawing.Size(117, 23);
            this.btnAttachUser.TabIndex = 6;
            this.btnAttachUser.Text = "Attach selected user";
            this.btnAttachUser.UseVisualStyleBackColor = true;
            this.btnAttachUser.Click += new System.EventHandler(this.btnAttachUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Company users not attached to company";
            // 
            // lbCompanyUsers
            // 
            this.lbCompanyUsers.FormattingEnabled = true;
            this.lbCompanyUsers.Location = new System.Drawing.Point(12, 28);
            this.lbCompanyUsers.Name = "lbCompanyUsers";
            this.lbCompanyUsers.Size = new System.Drawing.Size(192, 199);
            this.lbCompanyUsers.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Role in company";
            // 
            // cbCompanyRole
            // 
            this.cbCompanyRole.FormattingEnabled = true;
            this.cbCompanyRole.Location = new System.Drawing.Point(12, 251);
            this.cbCompanyRole.Name = "cbCompanyRole";
            this.cbCompanyRole.Size = new System.Drawing.Size(192, 21);
            this.cbCompanyRole.TabIndex = 9;
            // 
            // AttachCompanyUserToCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 326);
            this.Controls.Add(this.cbCompanyRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnAttachUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCompanyUsers);
            this.Name = "AttachCompanyUserToCompanyForm";
            this.Text = "AttachCompanyUserToCompanyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnAttachUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbCompanyUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCompanyRole;
    }
}