using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    /// <summary>
    /// Used for editing, removing and change company information.
    /// </summary>
    public partial class EditCompaniesForm : Form
    {
        private EditYearsForCompanyForm editYearsForCompanyForm;
        private List<CompanyInfo> companies;

        public EditCompaniesForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            companies = new List<CompanyInfo>();

            editYearsForCompanyForm = new EditYearsForCompanyForm();
            editYearsForCompanyForm.FormClosed += EditYearsForCompanyForm_FormClosed;
        }

        private void EditYearsForCompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Old form is disposed create a new form and attach events
            editYearsForCompanyForm = new EditYearsForCompanyForm();
            editYearsForCompanyForm.FormClosed += EditYearsForCompanyForm_FormClosed;
            editYearsForCompanyForm.Hide();
            Enabled = true;
        }

        private void cbCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string businessIdentityCode = GetBusinessIdentityCode();

            var companyToDisplay = companies.FirstOrDefault(c => c.BusinessIdentityCode.Equals(businessIdentityCode));

            DisplayCompanyInfo(companyToDisplay);
        }
        
        private void btnGetCompanies_Click(object sender, EventArgs e)
        {
            RefreshCompanyList();

            if (companies.Count == 0)
            {
                MessageBox.Show("No companies found", MessageBoxHeaderText.Info);
            }
        }

        private void RefreshCompanyList()
        {
            try
            {
                companies = CurrentApiClient.Instance.GetCompanyResource().List();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, MessageBoxHeaderText.Error);
                companies = new List<CompanyInfo>();
            }

            PopulateCompanyComboBox();
        }

        private void btnRemoveSelectedCompany_Click(object sender, EventArgs e)
        {
            if (companies.Count == 0)
            {
                MessageBox.Show("No companies to remove", MessageBoxHeaderText.Success);
                return;
            }

            string businessIdentityCode = GetBusinessIdentityCode();

            var selectedCompany = companies.FirstOrDefault(c => c.BusinessIdentityCode.Equals(businessIdentityCode));

            if (selectedCompany == null)
            {
                MessageBox.Show("Could not find selected company", MessageBoxHeaderText.Error);
                return;
            }
            
            try
            {
                CurrentApiClient.Instance.GetCompanyResource().Delete(selectedCompany);
            }
            catch (ApiServerException ex)
            {
                MessageBox.Show(ex.FormatedMessage(), MessageBoxHeaderText.Error);
                return;
            }

            MessageBox.Show("Company deleted.", MessageBoxHeaderText.Success);

            // Clear values
            cbCompanies.Items.Clear();
            cbCompanies.Text = string.Empty;

            tbCompanyName.Text = string.Empty;
            tbCompanyBusinessIdentityCode.Text = string.Empty;
            tbCompanyContactName.Text = string.Empty;
            tbCompanyContactAddress.Text = string.Empty;
            tbCompanyContactPostalAddress.Text = string.Empty;
            tbCompanyContactPhone.Text = string.Empty;

            // Get companies
            RefreshCompanyList();
        }

        private void btnUpdateSelectedCompanty_Click(object sender, EventArgs e)
        {
            if (companies.Count == 0)
            {
                MessageBox.Show("No companies to update", MessageBoxHeaderText.Success);
                return;
            }

            string businessIdentityCode = GetBusinessIdentityCode();

            var selectedCompany = companies.FirstOrDefault(c => c.BusinessIdentityCode.Equals(businessIdentityCode));

            if (tbCompanyName.Text.Length > 0 &&
                selectedCompany != null)
            {
                // Update company object
                selectedCompany.Name = tbCompanyName.Text;
                selectedCompany.ContactInfo.Name = tbCompanyContactName.Text;
                selectedCompany.ContactInfo.Address = tbCompanyContactAddress.Text;
                selectedCompany.ContactInfo.PostalAddress = tbCompanyContactPostalAddress.Text;
                selectedCompany.ContactInfo.Phone = tbCompanyContactPhone.Text;

                // Update company information
                try
                {
                    CurrentApiClient.Instance.GetCompanyResource().Update(selectedCompany);
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                    return;
                }

                MessageBox.Show("Company information updated.", MessageBoxHeaderText.Success);


                // Reload companies
                PopulateCompanyComboBox();
            }
            else
            {
                MessageBox.Show("Could not find selected company", MessageBoxHeaderText.Error);
            }
        }

        private void PopulateCompanyComboBox()
        {
            cbCompanies.Items.Clear();

            foreach (CompanyInfo company in companies)
            {
                cbCompanies.Items.Add(company.Name + " (" + company.BusinessIdentityCode + ")");
            }

            if (companies.Count > 0)
            {
                cbCompanies.SelectedIndex = 0;
                DisplayCompanyInfo(companies.First());
            }
        }

        private void DisplayCompanyInfo(CompanyInfo companyInfo)
        {
            tbCompanyName.Text = companyInfo.Name;
            tbCompanyBusinessIdentityCode.Text = companyInfo.BusinessIdentityCode;
            tbCompanyContactName.Text = companyInfo.ContactInfo.Name;
            tbCompanyContactAddress.Text = companyInfo.ContactInfo.Address;
            tbCompanyContactPostalAddress.Text = companyInfo.ContactInfo.PostalAddress;
            tbCompanyContactPhone.Text = companyInfo.ContactInfo.Phone;
        }

        private string GetBusinessIdentityCode()
        {
            var value = cbCompanies.SelectedItem.ToString();

            return value.Substring(value.LastIndexOf("(") + 1).Replace(")", string.Empty);
        }

        private void btnEditYearsForCompany_Click(object sender, EventArgs e)
        {
            if (companies.Count == 0)
            {
                MessageBox.Show("No companies to edit", MessageBoxHeaderText.Info);
                return;
            }

            editYearsForCompanyForm.SetCurrentBusinessIdentityCode(tbCompanyBusinessIdentityCode.Text);
            editYearsForCompanyForm.Show();
            Enabled = false;
        }

        private void btnGotoSelectedCompany_Click(object sender, EventArgs e)
        {
            if (companies.Count == 0)
            {
                MessageBox.Show("No company selected", MessageBoxHeaderText.Info);
                return;
            }
            
            string businessIdentityCode = GetBusinessIdentityCode();
            
            Uri uri = CurrentApiClient.Instance.GetLoginUrl(businessIdentityCode);
            
            // Access resource
            MainForm.OpenAddressInWebBrowser(uri.AbsoluteUri);
        }
    }
}
