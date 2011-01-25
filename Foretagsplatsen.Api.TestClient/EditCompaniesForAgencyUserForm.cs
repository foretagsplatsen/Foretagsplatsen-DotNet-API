using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class EditCompaniesForAgencyUserForm : Form
    {
        private AttachCompanyToUserForm attachCompanyToUserForm;

        public EditCompaniesForAgencyUserForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            attachCompanyToUserForm = new AttachCompanyToUserForm();
            attachCompanyToUserForm.Closed += AttachCompanyToUserForm_Closed;
            attachCompanyToUserForm.CurrentUser = CurrentUser;
        }

        protected override void OnShown(EventArgs e)
        {
            tbCurrentUserName.Text = CurrentUser.UserName;
            RefreshCompanyList();
            base.OnShown(e);
        }

        private void AttachCompanyToUserForm_Closed(object sender, EventArgs e)
        {
            attachCompanyToUserForm = new AttachCompanyToUserForm();
            attachCompanyToUserForm.Closed += AttachCompanyToUserForm_Closed;
            attachCompanyToUserForm.CurrentUser = CurrentUser;
            Enabled = true;

            RefreshCompanyList();
        }

        public UserInfo CurrentUser { get; set; }

        private void lbAttachedCompanies_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string businessIdentityCode = GetBusinessIdentityCode();

            if (string.IsNullOrEmpty(businessIdentityCode))
            {
                return;
            }

            CompanyInfo companyInfo;
            try
            {
                companyInfo = CurrentApiClient.Instance.GetAgencyUserCompanyResource().Get(CurrentUser.UserName, businessIdentityCode);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                return;
            }
            
            ShowSelectedCompanyInfo(companyInfo);
        }

        private void RefreshCompanyList()
        {
            lbAttachedCompanies.Items.Clear();
            List<CompanyInfo> companies;
            try
            {
                companies = CurrentApiClient.Instance.GetAgencyUserCompanyResource().List(CurrentUser.UserName);
            }
            catch (ApiException ex) 
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                return;
            }
            
            const string formatedStringForCompany = "{0} ({1})";
            foreach (CompanyInfo company in companies)
            {
                string formatedValue = string.Format(formatedStringForCompany, company.Name, company.BusinessIdentityCode);
                lbAttachedCompanies.Items.Add(formatedValue);
            }
        }

        private void ShowSelectedCompanyInfo(CompanyInfo companyToShow)
        {
            tbCompanyName.Text = companyToShow.Name;
            tbCompanyBusinessIdentityCode.Text = companyToShow.BusinessIdentityCode;
            tbCompanyContactName.Text = companyToShow.ContactInfo.Name;
            tbCompanyContactPhone.Text = companyToShow.ContactInfo.Phone;
            tbCompanyContactAddress.Text = companyToShow.ContactInfo.Address;
            tbCompanyContactEmail.Text = companyToShow.ContactInfo.PostalAddress;
        }

        private void btnAttachCompanies_Click(object sender, EventArgs e)
        {
            attachCompanyToUserForm.CurrentUser = CurrentUser;
            attachCompanyToUserForm.Show();
            Enabled = false;
        }

        private void btnDetachCompany_Click(object sender, EventArgs e)
        {
            if (lbAttachedCompanies.SelectedItem == null)
            {
                MessageBox.Show("Please select a company first before detach user.");
                return;
            }

            string businessIdentityCode = GetBusinessIdentityCode();

            try
            {
                CurrentApiClient.Instance.GetAgencyUserCompanyResource().Detach(CurrentUser.UserName, businessIdentityCode);
                RefreshCompanyList();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                return;
            }
            
            MessageBox.Show("Successfully detach user from company.", MessageBoxHeaderText.Success);
        }

        private string GetBusinessIdentityCode()
        {
            if (lbAttachedCompanies.SelectedItem == null)
            {
                return string.Empty;
            }

            var selectedCompany = (string)lbAttachedCompanies.SelectedItem;

            // Calculate and get business identity code from string shown in list
            string businessIdentityCode;
            try
            {
                int businessIdentityCodeStartIndex = selectedCompany.LastIndexOf("(") + 1;
                int businessIdentityCodeLength = selectedCompany.Length - businessIdentityCodeStartIndex - 1;
                businessIdentityCode = selectedCompany.Substring(businessIdentityCodeStartIndex, businessIdentityCodeLength);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not parse business identity code for company.", MessageBoxHeaderText.Error);
                return string.Empty;
            }

            return businessIdentityCode;
        }
    }
}
