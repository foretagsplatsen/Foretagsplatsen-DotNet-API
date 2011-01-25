using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class AttachAgencyUserToCompanyForm : Form
    {
        public AttachAgencyUserToCompanyForm()
        {
            InitializeComponent();
        }

        public CompanyInfo CurrentCompany { get; set; }

        protected override void OnShown(EventArgs e)
        {
            RefreshUserList();
            base.OnShown(e);
        }

        private void btnAttachUser_Click(object sender, EventArgs e)
        {
            if (lbAgencyUsers.SelectedItem == null)
            {
                return;
            }

            string selectedUser = lbAgencyUsers.SelectedItem.ToString();

            // Add user to the company and refresh list with unattached users if valid username
            if (!string.IsNullOrEmpty(selectedUser))
            {
                try
                {
                    CurrentApiClient.Instance.GetCompanyAgencyUserResource(CurrentCompany).Attach(selectedUser);
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
                List<UserInfo> allAgencyUsers = CurrentApiClient.Instance.GetAgencyUserResource().List();
                List<UserInfo> attachedAgencyUsers = CurrentApiClient.Instance.GetCompanyAgencyUserResource(CurrentCompany).List();


                // Get users to show, users that is not attached already
                var attachedAgencyUserNames = attachedAgencyUsers.Select(au => au.UserName);
                var notAttachedUsers = allAgencyUsers.FindAll(u => attachedAgencyUserNames.Contains(u.UserName) == false);
                
                lbAgencyUsers.Items.Clear();

                if (notAttachedUsers.Count == 0)
                {
                    MessageBox.Show("There is no more agency users that can be attached to the company.", MessageBoxHeaderText.Info);
                    return;
                }

                foreach (UserInfo notAttachedUser in notAttachedUsers)
                {
                    lbAgencyUsers.Items.Add(notAttachedUser.UserName);
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }
    }
}
