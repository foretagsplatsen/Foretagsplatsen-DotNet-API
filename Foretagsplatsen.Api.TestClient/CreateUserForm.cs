using System;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class CreateUserForm : Form
    {
        public bool IsAgencyUser { get; set; }

        public CreateUserForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) ||
                string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Username or password can't be empty.", MessageBoxHeaderText.Error);
                return;
            }

            var userToCreate = new UserInfo
            {
                UserName = tbUsername.Text,
                Password = tbPassword.Text,
                Cellphone = tbCellphone.Text,
                Email = tbEmail.Text,
                Name = tbName.Text,
                Phone = tbPhone.Text
            };

            try
            {
                if (IsAgencyUser)
                {
                    CurrentApiClient.Instance.GetAgencyUserResource().Create(userToCreate);
                    MessageBox.Show("Agency user " + userToCreate.UserName + " successfully created.", MessageBoxHeaderText.Success);
                    Close();
                }
                else
                {
                    // Todo company user
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
    }
}
