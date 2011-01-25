using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class AttachCompanyUserToCompanyForm : Form
    {
        public AttachCompanyUserToCompanyForm()
        {
            InitializeComponent();
        }
        
        public CompanyInfo CurrentCompany { get; set; }

        protected override void OnShown(EventArgs e)
        {
            RefreshUserList();

            cbCompanyRole.Items.Clear();
            cbCompanyRole.Items.Add(CompanyRoleType.CompanyAdminRole.ToString());
            cbCompanyRole.Items.Add(CompanyRoleType.CompanyNormalRole.ToString());
            cbCompanyRole.Items.Add(CompanyRoleType.CompanyLimitedRole.ToString());
            cbCompanyRole.SelectedIndex = 1;

            base.OnShown(e);
        }

        private void btnAttachUser_Click(object sender, EventArgs e)
        {
            if (lbCompanyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbCompanyUsers.SelectedItem.ToString();

            // Add user to the company and refresh list with unattached users if valid username
            if (!string.IsNullOrEmpty(selectedUser))
            {
                try
                {
                    var selectedRole = (CompanyRoleType)Enum.Parse(typeof (CompanyRoleType), cbCompanyRole.SelectedItem.ToString());
                    CurrentApiClient.Instance.GetCompanyUserResource(CurrentCompany).Attach(selectedUser, selectedRole);
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                    return;
                }

                MessageBox.Show("User " + selectedUser + " successfully attached to company " + CurrentCompany.Name + ".", MessageBoxHeaderText.Success);

                RefreshUserList();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshUserList()
        {
            try
            {
                List<UserInfo> disconnectedCompanyUsers = CurrentApiClient.Instance.GetCompanyUserResource(CurrentCompany).List(true);

                lbCompanyUsers.Items.Clear();

                if (disconnectedCompanyUsers.Count == 0)
                {
                    MessageBox.Show("There is no more company users that can be attached to the company.", MessageBoxHeaderText.Info);
                    return;
                }

                foreach (UserInfo notAttachedUser in disconnectedCompanyUsers)
                {
                    lbCompanyUsers.Items.Add(notAttachedUser.UserName);
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }
    }
}
