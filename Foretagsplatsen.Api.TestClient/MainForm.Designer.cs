namespace Foretagsplatsen.Api.TestClient
{
    partial class MainForm
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
            this.btnGoToCompany = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRemoveAccessToken = new System.Windows.Forms.Button();
            this.btnEditCompanies = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAccessTokenSecret = new System.Windows.Forms.TextBox();
            this.tbConsumerSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAccessToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConsumerKey = new System.Windows.Forms.TextBox();
            this.tbAccessTokenUsername = new System.Windows.Forms.TextBox();
            this.tbProviderHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGoToCompany
            // 
            this.btnGoToCompany.Location = new System.Drawing.Point(13, 13);
            this.btnGoToCompany.Name = "btnGoToCompany";
            this.btnGoToCompany.Size = new System.Drawing.Size(124, 23);
            this.btnGoToCompany.TabIndex = 6;
            this.btnGoToCompany.Text = "Go to företagsplatsen";
            this.btnGoToCompany.UseVisualStyleBackColor = true;
            this.btnGoToCompany.Click += new System.EventHandler(this.btnGoToCompany_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(13, 42);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(124, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Upload sie";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRemoveAccessToken
            // 
            this.btnRemoveAccessToken.Location = new System.Drawing.Point(157, 13);
            this.btnRemoveAccessToken.Name = "btnRemoveAccessToken";
            this.btnRemoveAccessToken.Size = new System.Drawing.Size(152, 23);
            this.btnRemoveAccessToken.TabIndex = 9;
            this.btnRemoveAccessToken.Text = "Remove access token";
            this.btnRemoveAccessToken.UseVisualStyleBackColor = true;
            this.btnRemoveAccessToken.Click += new System.EventHandler(this.btnRemoveAccessToken_Click);
            // 
            // btnEditCompanies
            // 
            this.btnEditCompanies.Location = new System.Drawing.Point(13, 70);
            this.btnEditCompanies.Name = "btnEditCompanies";
            this.btnEditCompanies.Size = new System.Drawing.Size(124, 23);
            this.btnEditCompanies.TabIndex = 10;
            this.btnEditCompanies.Text = "Edit companies";
            this.btnEditCompanies.UseVisualStyleBackColor = true;
            this.btnEditCompanies.Click += new System.EventHandler(this.btnEditCompanies_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbAccessTokenSecret);
            this.groupBox1.Controls.Add(this.tbConsumerSecret);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbAccessToken);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbConsumerKey);
            this.groupBox1.Controls.Add(this.tbAccessTokenUsername);
            this.groupBox1.Location = new System.Drawing.Point(13, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 187);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current access token";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Consumer secret";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Token secret";
            // 
            // tbAccessTokenSecret
            // 
            this.tbAccessTokenSecret.Location = new System.Drawing.Point(6, 151);
            this.tbAccessTokenSecret.Name = "tbAccessTokenSecret";
            this.tbAccessTokenSecret.ReadOnly = true;
            this.tbAccessTokenSecret.Size = new System.Drawing.Size(305, 20);
            this.tbAccessTokenSecret.TabIndex = 8;
            // 
            // tbConsumerSecret
            // 
            this.tbConsumerSecret.Location = new System.Drawing.Point(169, 73);
            this.tbConsumerSecret.Name = "tbConsumerSecret";
            this.tbConsumerSecret.Size = new System.Drawing.Size(142, 20);
            this.tbConsumerSecret.TabIndex = 12;
            this.tbConsumerSecret.Text = "secret";
            this.tbConsumerSecret.TextChanged += new System.EventHandler(this.tbConsumerSecret_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Token";
            // 
            // tbAccessToken
            // 
            this.tbAccessToken.Location = new System.Drawing.Point(6, 112);
            this.tbAccessToken.Name = "tbAccessToken";
            this.tbAccessToken.ReadOnly = true;
            this.tbAccessToken.Size = new System.Drawing.Size(305, 20);
            this.tbAccessToken.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Consumer key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // tbConsumerKey
            // 
            this.tbConsumerKey.Location = new System.Drawing.Point(169, 32);
            this.tbConsumerKey.Name = "tbConsumerKey";
            this.tbConsumerKey.Size = new System.Drawing.Size(142, 20);
            this.tbConsumerKey.TabIndex = 1;
            this.tbConsumerKey.Text = "key";
            this.tbConsumerKey.TextChanged += new System.EventHandler(this.tbConsumerKey_TextChanged);
            // 
            // tbAccessTokenUsername
            // 
            this.tbAccessTokenUsername.Location = new System.Drawing.Point(6, 32);
            this.tbAccessTokenUsername.Name = "tbAccessTokenUsername";
            this.tbAccessTokenUsername.ReadOnly = true;
            this.tbAccessTokenUsername.Size = new System.Drawing.Size(142, 20);
            this.tbAccessTokenUsername.TabIndex = 0;
            // 
            // tbProviderHost
            // 
            this.tbProviderHost.Location = new System.Drawing.Point(157, 58);
            this.tbProviderHost.Name = "tbProviderHost";
            this.tbProviderHost.Size = new System.Drawing.Size(177, 20);
            this.tbProviderHost.TabIndex = 13;
            this.tbProviderHost.Text = "https://web.foretagsplatsen.se";
            this.tbProviderHost.TextChanged += new System.EventHandler(this.tbProviderHost_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Provider host";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(13, 99);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(124, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 360);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbProviderHost);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditCompanies);
            this.Controls.Add(this.btnRemoveAccessToken);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGoToCompany);
            this.Name = "MainForm";
            this.Text = "Example client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoToCompany;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRemoveAccessToken;
        private System.Windows.Forms.Button btnEditCompanies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbConsumerKey;
        private System.Windows.Forms.TextBox tbAccessTokenUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAccessTokenSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccessToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbConsumerSecret;
        private System.Windows.Forms.TextBox tbProviderHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLogin;
    }
}

