using System;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class CreateCompanyUserForm : Form
    {
        public CreateCompanyUserForm()
        {
            InitializeComponent();
        }

        public CompanyInfo CurrentCompany { get; set; }

        protected override void OnShown(EventArgs e)
        {
            cbCompanyRole.Items.Clear();
            cbCompanyRole.Items.Add(CompanyRoleType.CompanyAdminRole.ToString());
            cbCompanyRole.Items.Add(CompanyRoleType.CompanyNormalRole.ToString());
            cbCompanyRole.Items.Add(CompanyRoleType.CompanyLimitedRole.ToString());
            cbCompanyRole.SelectedIndex = 0;

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
                TypeOfUser = UserType.CompanyUser
            };

            try
            {
                // Create user
                var role = (CompanyRoleType)Enum.Parse(typeof(CompanyRoleType), cbCompanyRole.SelectedItem.ToString());
                CurrentApiClient.Instance.GetCompanyUserResource(CurrentCompany).Create(userToCreate, role);

                // Show user what happened
                MessageBox.Show("Company user " + userToCreate.UserName + " successfully created.", MessageBoxHeaderText.Success);
                Close();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
    }
}
