using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class EditUsersForm : Form
    {
        private AttachAgencyUserToCompanyForm attachAgencyUserToCompanyForm;
        private AttachCompanyUserToCompanyForm attachCompanyUserToCompanyForm;
        private EditCompaniesForAgencyUserForm editCompaniesForAgencyUserForm;
        private CreateAgencyUserForm createAgencyUserForm;
        private CreateCompanyUserForm createCompanyUserForm;
        private CompanyInfo currentCompany;

        public EditUsersForm()
        {
            InitializeComponent();
            Init();
        }

        public CompanyInfo CurrentCompany
        {
            get
            {
                return currentCompany;
            }
            set
            {
                currentCompany = value;

                // Set information that will be displayed
                tbCurrentCompanyName.Text = currentCompany.Name;
                tbCurrentCompanyBusinessIdentityCode.Text = currentCompany.BusinessIdentityCode;
            }
        }

        private void Init()
        {
            attachAgencyUserToCompanyForm = new AttachAgencyUserToCompanyForm();
            attachAgencyUserToCompanyForm.FormClosed += AttachAgencyUserToCompanyForm_FormClosed;

            attachCompanyUserToCompanyForm = new AttachCompanyUserToCompanyForm();
            attachCompanyUserToCompanyForm.FormClosed += AttachCompanyUserToCompanyForm_FormClosed;

            createAgencyUserForm = new CreateAgencyUserForm();
            createAgencyUserForm.FormClosed += CreateAgencyUserForm_FormClosed;

            createCompanyUserForm = new CreateCompanyUserForm();
            createCompanyUserForm.FormClosed += CreateCompanyUserForm_FormClosed;

            editCompaniesForAgencyUserForm = new EditCompaniesForAgencyUserForm();
            editCompaniesForAgencyUserForm.FormClosed += EditCompaniesForAgencyUserForm_FormClosed;
        }
        
        private void EditCompaniesForAgencyUserForm_FormClosed(object sender, EventArgs e)
        {
            editCompaniesForAgencyUserForm = new EditCompaniesForAgencyUserForm();
            editCompaniesForAgencyUserForm.Closed += EditCompaniesForAgencyUserForm_FormClosed;
            Enabled = true;

            RefreshAgencyUsersForCompany();
        }

        private void CreateAgencyUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            createAgencyUserForm = new CreateAgencyUserForm();
            createAgencyUserForm.FormClosed += CreateAgencyUserForm_FormClosed;
            Enabled = true;

            RefreshAgencyUsersForCompany();
        }

        private void CreateCompanyUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            createCompanyUserForm = new CreateCompanyUserForm();
            createCompanyUserForm.FormClosed += CreateCompanyUserForm_FormClosed;
            Enabled = true;

            RefreshCompanyUsersForCompany();
        }

        private void AttachAgencyUserToCompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            attachAgencyUserToCompanyForm = new AttachAgencyUserToCompanyForm();
            attachAgencyUserToCompanyForm.FormClosed += AttachAgencyUserToCompanyForm_FormClosed;
            attachAgencyUserToCompanyForm.Hide();
            Enabled = true;

            RefreshAgencyUsersForCompany();
        }

        private void AttachCompanyUserToCompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            attachCompanyUserToCompanyForm = new AttachCompanyUserToCompanyForm();
            attachCompanyUserToCompanyForm.FormClosed += AttachCompanyUserToCompanyForm_FormClosed;
            attachCompanyUserToCompanyForm.Hide();
            Enabled = true;

            RefreshCompanyUsersForCompany();
        }
        
        protected override void OnShown(EventArgs e)
        {
            RefreshAgencyUsersForCompany();
            RefreshCompanyUsersForCompany();

            PopulateAgencyUserTypeComboBox();
            PopulateCompanyUserTypeComboBox();

            base.OnShown(e);
        }

        private void PopulateAgencyUserTypeComboBox()
        {
            cbAgencyUserType.Items.Clear();

            cbAgencyUserType.Items.Add(UserType.AgencyDirector);
            cbAgencyUserType.Items.Add(UserType.AgencyConsultant);
        }

        private void PopulateCompanyUserTypeComboBox()
        {
            cbCompanyUserRole.Items.Clear();

            cbCompanyUserRole.Items.Add(CompanyRoleType.CompanyAdminRole.ToString());
            cbCompanyUserRole.Items.Add(CompanyRoleType.CompanyNormalRole.ToString());
            cbCompanyUserRole.Items.Add(CompanyRoleType.CompanyLimitedRole.ToString());
        }

        #region AgencyUser

        private void lbAgencyUsers_Click(object sender, EventArgs e)
        {
            if (lbAgencyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbAgencyUsers.SelectedItem.ToString();


            // Fetch info about user only if a new user in the list was selected
            if (!tbAgencyUserName.Text.Equals(selectedUser) && !string.IsNullOrEmpty(selectedUser))
            {
                try
                {
                    UserInfo userInfo = CurrentApiClient.Instance.GetAgencyUserResource().Get(selectedUser);
                    UpdateAgencyUserInfo(userInfo);
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                }
            }
        }

        private void btnAttachAgencyUsers_Click(object sender, EventArgs e)
        {
            attachAgencyUserToCompanyForm.CurrentCompany = currentCompany;
            attachAgencyUserToCompanyForm.Show();
            Enabled = false;
        }

        private void btnDetachAgencyUser_Click(object sender, EventArgs e)
        {
            if (lbAgencyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbAgencyUsers.SelectedItem.ToString();

            // Fetch info about user if a new user in the list was selected
            try
            {
                CurrentApiClient.Instance.GetCompanyAgencyUserResource(currentCompany).Detach(selectedUser);

                // Clear old values with empty object
                UpdateAgencyUserInfo(new UserInfo());

                MessageBox.Show("User " + selectedUser + " successfully detached from company " + currentCompany.Name + ".", MessageBoxHeaderText.Success);

                // Get update list with attached agency users
                RefreshAgencyUsersForCompany();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void AddAgencyUsersToList(List<UserInfo> agencyUsers)
        {
            lbAgencyUsers.Items.Clear();
            foreach (UserInfo agencyUser in agencyUsers)
            {
                lbAgencyUsers.Items.Add(agencyUser.UserName);
            }
        }

        private void UpdateAgencyUserInfo(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                tbAgencyUserUsername.Text = userInfo.UserName;
                tbAgencyUserPassword.Text = userInfo.Password;
                tbAgencyUserName.Text = userInfo.Name;
                tbAgencyUserPhone.Text = userInfo.Phone;
                tbAgencyUserCellphone.Text = userInfo.Cellphone;
                tbAgencyUserEmail.Text = userInfo.Email;
                cbAgencyUserType.SelectedItem = userInfo.TypeOfUser;
            }
        }

        private void RefreshAgencyUsersForCompany()
        {
            try
            {
                List<UserInfo> agencyUsers = CurrentApiClient.Instance.GetCompanyAgencyUserResource(currentCompany).List();
                AddAgencyUsersToList(agencyUsers);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void btnCreateAgencyUser_Click(object sender, EventArgs e)
        {
            createAgencyUserForm.Show();
            Enabled = false;
        }

        private void btnDeleteAgencyUser_Click(object sender, EventArgs e)
        {
            if (lbAgencyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbAgencyUsers.SelectedItem.ToString();

            // Delete user from database 
            try
            {
                CurrentApiClient.Instance.GetAgencyUserResource().Delete(selectedUser);
                RefreshAgencyUsersForCompany();
                MessageBox.Show("User " + selectedUser + " successfully deleted.", MessageBoxHeaderText.Success);
            }
            catch (ApiException ex)
            {

                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }

        private void btnUpdateAgencyUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAgencyUserUsername.Text) ||
                lbAgencyUsers.SelectedItem.ToString() != tbAgencyUserUsername.Text)
            {
                MessageBox.Show("Username can't be empty.", MessageBoxHeaderText.Error);
                return;
            }

            // Create user information to update with
            var userInfo = new UserInfo
            {
                UserName = tbAgencyUserUsername.Text,
                Password = tbAgencyUserPassword.Text == string.Empty ? null : tbAgencyUserPassword.Text,
                Cellphone = tbAgencyUserCellphone.Text,
                Email = tbAgencyUserEmail.Text,
                Name = tbAgencyUserName.Text,
                Phone = tbAgencyUserPhone.Text,
                TypeOfUser = (UserType)cbAgencyUserType.SelectedItem
            };

            // Delete user from database 
            try
            {
                CurrentApiClient.Instance.GetAgencyUserResource().Update(userInfo);
                RefreshAgencyUsersForCompany();
                MessageBox.Show("User " + userInfo.UserName + " updated successfully.", MessageBoxHeaderText.Success);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void btnEditCompaniesForSelectedAgencyUser_Click(object sender, EventArgs e)
        {
            if (lbAgencyUsers.SelectedItem == null)
            {
                return;
            }

            try
            {
                UserInfo selectedUser = CurrentApiClient.Instance.GetAgencyUserResource().Get(lbAgencyUsers.SelectedItem.ToString());

                editCompaniesForAgencyUserForm.CurrentUser = selectedUser;
                editCompaniesForAgencyUserForm.Show();
                Enabled = false;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        #endregion
        
        #region CompanyUser

        private void AddCompanyUsersToList(List<UserInfo> companyUsers)
        {
            lbCompanyUsers.Items.Clear();
            foreach (var companyUser in companyUsers)
            {
                lbCompanyUsers.Items.Add(companyUser.UserName);
            }
        }

        private void RefreshCompanyUsersForCompany()
        {
            try
            {
                List<UserInfo> companyUsers = CurrentApiClient.Instance.GetCompanyUserResource(currentCompany).List(false);
                AddCompanyUsersToList(companyUsers);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void UpdateCompanyUserInfo(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                tbCompanyUserUsername.Text = userInfo.UserName;
                tbCompanyUserPassword.Text = userInfo.Password;
                tbCompanyUserName.Text = userInfo.Name;
                tbCompanyUserPhone.Text = userInfo.Phone;
                tbCompanyUserCellphone.Text = userInfo.Cellphone;
                tbCompanyUserEmail.Text = userInfo.Email;

                // Set role in company for user
                if (userInfo.Companies != null)
                {
                    var foundCompanyRole = userInfo.Companies.FirstOrDefault(c => c.BusinessIdentityCode.Equals(currentCompany.BusinessIdentityCode));
                    if (foundCompanyRole != null)
                    {
                        cbCompanyUserRole.SelectedItem = foundCompanyRole.TypeOfRole;
                    }
                }
                else
                {
                    cbCompanyUserRole.SelectedItem = CompanyRoleType.CompanyNormalRole;
                }
            }
        }

        private void lbCompanyUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCompanyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbCompanyUsers.SelectedItem.ToString();


            // Fetch info about user only if a new user in the list was selected
            if (!tbCompanyUserName.Text.Equals(selectedUser) && !string.IsNullOrEmpty(selectedUser))
            {
                try
                {
                    UserInfo userInfo = CurrentApiClient.Instance.GetCompanyUserResource(currentCompany).Get(selectedUser);
                    UpdateCompanyUserInfo(userInfo);
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                }
            }
        }

        private void btnUpdateCompanyUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCompanyUserUsername.Text) ||
                lbCompanyUsers.SelectedItem.ToString() != tbCompanyUserUsername.Text)
            {
                MessageBox.Show("Username can't be empty.", MessageBoxHeaderText.Error);
                return;
            }

            // Create user information to update with
            var userInfo = new UserInfo
            {
                UserName = tbCompanyUserUsername.Text,
                Password = tbCompanyUserPassword.Text == string.Empty ? null : tbCompanyUserPassword.Text,
                Cellphone = tbCompanyUserCellphone.Text,
                Email = tbCompanyUserEmail.Text,
                Name = tbCompanyUserName.Text,
                Phone = tbCompanyUserPhone.Text,
                TypeOfUser = UserType.CompanyUser
            };

            try
            {
                // Update user
                var role = (CompanyRoleType)Enum.Parse(typeof(CompanyRoleType), cbCompanyUserRole.SelectedItem.ToString());
                CurrentApiClient.Instance.GetCompanyUserResource(currentCompany).Update(userInfo, role);

                // Show what happened to the user
                RefreshCompanyUsersForCompany();
                MessageBox.Show("User " + userInfo.UserName + " updated successfully.", MessageBoxHeaderText.Success);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void btnDetachCompanyUser_Click(object sender, EventArgs e)
        {
            if (lbCompanyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbCompanyUsers.SelectedItem.ToString();

            // Fetch info about user if a new user in the list was selected
            try
            {
                CurrentApiClient.Instance.GetCompanyUserResource(currentCompany).Delete(selectedUser, true);

                // Clear old values with empty object
                UpdateCompanyUserInfo(new UserInfo());

                MessageBox.Show("User " + selectedUser + " successfully detached from company " + currentCompany.Name + ".", MessageBoxHeaderText.Success);

                // Get update list with attached company users
                RefreshCompanyUsersForCompany();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void btnDeleteCompanyUser_Click(object sender, EventArgs e)
        {
            if (lbCompanyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbCompanyUsers.SelectedItem.ToString();

            // Fetch info about user if a new user in the list was selected
            try
            {
                CurrentApiClient.Instance.GetCompanyUserResource(currentCompany).Delete(selectedUser, false);

                // Clear old values with empty object
                UpdateCompanyUserInfo(new UserInfo());

                MessageBox.Show("User " + selectedUser + " successfully deleted from company " + currentCompany.Name + ".", MessageBoxHeaderText.Success);

                // Get update list with attached company users
                RefreshCompanyUsersForCompany();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private void btnAttachCompanyUser_Click(object sender, EventArgs e)
        {
            attachCompanyUserToCompanyForm.CurrentCompany = currentCompany;
            attachCompanyUserToCompanyForm.Show();
            Enabled = false;
        }

        private void btnCreateCompanyUser_Click(object sender, EventArgs e)
        {
            createCompanyUserForm.Show();
            createCompanyUserForm.CurrentCompany = currentCompany;
            Enabled = false;
        }

        #endregion
    }
}
