using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class AttachCompanyToUserForm : Form
    {
        public AttachCompanyToUserForm()
        {
            InitializeComponent();
        }

        public UserInfo CurrentUser { get; set; }

        protected override void OnShown(EventArgs e)
        {
            RefreshCompanyList();
            base.OnShown(e);
        }

        private void btnAttachCompany_Click(object sender, EventArgs e)
        {
            if (lbCompaniesThatCanBeAttached.SelectedItem == null)
            {
                MessageBox.Show("Please select a company to attach first.");
                return;
            }

            string businessIdentityCode = GetBusinessIdentityCode();

            try
            {
                CurrentApiClient.Instance.GetAgencyUserCompanyResource().Attach(CurrentUser.UserName, businessIdentityCode);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                return;
            }
            
            RefreshCompanyList();

            MessageBox.Show("Successfully attached company to user.");
        }

        private void RefreshCompanyList()
        {
            try
            {
                List<CompanyInfo> attachedCompaniesForUser = CurrentApiClient.Instance.GetAgencyUserCompanyResource().List(CurrentUser.UserName);
                List<CompanyInfo> allCompaniesForAgency = CurrentApiClient.Instance.GetCompanyResource().List(true);

                IEnumerable<string> attachedCompaniesBusinessIdentityCodeCollection = attachedCompaniesForUser.Select(c => c.BusinessIdentityCode);

                var notAttachedCompanies = allCompaniesForAgency
                    .Where(c => attachedCompaniesBusinessIdentityCodeCollection.Contains(c.BusinessIdentityCode) == false);

                if (notAttachedCompanies.Count() == 0)
                {
                    MessageBox.Show("There is no more companies that can be attached to the user.", MessageBoxHeaderText.Info);
                    return;
                }

                lbCompaniesThatCanBeAttached.Items.Clear();

                const string formatedCompanyTextTemplate = "{0} ({1})";
                foreach (CompanyInfo company in notAttachedCompanies)
                {
                    string formatedText = string.Format(formatedCompanyTextTemplate, company.Name, company.BusinessIdentityCode);
                    lbCompaniesThatCanBeAttached.Items.Add(formatedText);
                }

            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
            }
        }

        private string GetBusinessIdentityCode()
        {
            if (lbCompaniesThatCanBeAttached.SelectedItem == null)
            {
                return string.Empty;
            }

            var selectedCompany = (string)lbCompaniesThatCanBeAttached.SelectedItem;

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
