namespace Foretagsplatsen.Api.TestClient
{
    partial class AttachAgencyUserToCompanyForm
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
            this.lbAgencyUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAttachUser = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbAgencyUsers
            // 
            this.lbAgencyUsers.FormattingEnabled = true;
            this.lbAgencyUsers.Location = new System.Drawing.Point(12, 30);
            this.lbAgencyUsers.Name = "lbAgencyUsers";
            this.lbAgencyUsers.Size = new System.Drawing.Size(192, 199);
            this.lbAgencyUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agency users not attached to company";
            // 
            // btnAttachUser
            // 
            this.btnAttachUser.Location = new System.Drawing.Point(12, 249);
            this.btnAttachUser.Name = "btnAttachUser";
            this.btnAttachUser.Size = new System.Drawing.Size(117, 23);
            this.btnAttachUser.TabIndex = 2;
            this.btnAttachUser.Text = "Attach selected user";
            this.btnAttachUser.UseVisualStyleBackColor = true;
            this.btnAttachUser.Click += new System.EventHandler(this.btnAttachUser_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(133, 249);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(71, 23);
            this.btnCloseForm.TabIndex = 3;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // AttachAgencyUserToCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 288);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnAttachUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAgencyUsers);
            this.Name = "AttachAgencyUserToCompanyForm";
            this.Text = "AttachAgencyUserToCompanyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAgencyUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAttachUser;
        private System.Windows.Forms.Button btnCloseForm;
    }
}