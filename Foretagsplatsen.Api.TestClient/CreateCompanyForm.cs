using System;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class CreateCompanyForm : Form
    {
        public CreateCompanyForm()
        {
            InitializeComponent();
        }

        private void btnCreateCompany_Click(object sender, EventArgs e)
        {
            var companyInfo = BuildCompanyInfo();

            if (companyInfo != null)
            {
                try
                {
                    CurrentApiClient.Instance.GetCompanyResource().Create(companyInfo);
                    MessageBox.Show("Company created successfully.", MessageBoxHeaderText.Info);
                    Close();
                }
                catch (ApiException ex)
                {
                    MessageBox.Show(ex.Message, MessageBoxHeaderText.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private CompanyInfo BuildCompanyInfo()
        {
            if (string.IsNullOrEmpty(tbBusinessIdentityCode.Text) )
            {
                MessageBox.Show("Business identity code can't be empty.", MessageBoxHeaderText.Error);
                return null;
            }

            if (string.IsNullOrEmpty(tbCompanyName.Text))
            {
                MessageBox.Show("Company name can't be empty.", MessageBoxHeaderText.Error);
                return null;
            }

            var contactInfo = new ContactInfo
            {
                Address = tbContactAddress.Text,
                Name = tbContactName.Text,
                Phone = tbContactPhone.Text,
                PostalAddress = tbContactPostalAddress.Text
            };

            var companyInfo = new CompanyInfo
            {
                Name = tbCompanyName.Text, 
                BusinessIdentityCode = tbBusinessIdentityCode.Text, 
                ContactInfo = contactInfo
            };
            
            return companyInfo;
        }
    }
}
