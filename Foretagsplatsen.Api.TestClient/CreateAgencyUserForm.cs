using System;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class CreateAgencyUserForm : Form
    {
        public CreateAgencyUserForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            cbUserType.Items.Clear();
            cbUserType.Items.Add(UserType.AgencyDirector);
            cbUserType.Items.Add(UserType.AgencyConsultant);
            cbUserType.SelectedIndex = 0;

            base.OnShown(e);
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
                Phone = tbPhone.Text,
                TypeOfUser = (UserType)cbUserType.SelectedItem
            };

            try
            {
                CurrentApiClient.Instance.GetAgencyUserResource().Create(userToCreate);
                MessageBox.Show("Agency user " + userToCreate.UserName + " successfully created.", MessageBoxHeaderText.Success);
                Close();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
    }
}
