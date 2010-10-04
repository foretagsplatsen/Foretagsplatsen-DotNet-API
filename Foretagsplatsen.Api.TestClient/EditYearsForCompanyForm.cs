using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    /// <summary>
    /// Used for displaying and removing years from a company.
    /// </summary>
    public partial class EditYearsForCompanyForm : Form
    {
        private List<FiscalYear> years;
        
        public EditYearsForCompanyForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            years = new List<FiscalYear>();
        }

        public void SetCurrentBusinessIdentityCode(string businessIdentityCode)
        {
            tbBusinessIdentityCode.Text = businessIdentityCode;
        }

        private void btnFetchYears_Click(object sender, EventArgs e)
        {
            years = GetYears();
            ClearOldYearValues();
            PopulateListBoxWithYears();

            if (years.Count == 0)
            {
                MessageBox.Show("No years found for company.", MessageBoxHeaderText.Info);
                return;
            }
        }

        private void btnDeleteSelectedYear_Click(object sender, EventArgs e)
        {
            if (years.Count == 0)
            {
                MessageBox.Show("No years for company.", MessageBoxHeaderText.Info);
                return;
            }

            if (!string.IsNullOrEmpty(cbCompanyYears.SelectedItem.ToString()))
            {
                string id = GetSelectedYearId();

                try
                {
                    CurrentApiClient.Instance.GetFiscalYearResource(tbBusinessIdentityCode.Text).Delete(id);
                }
                catch (ApiServerException ex)
                {
                    MessageBox.Show(ex.FormatedMessage(), MessageBoxHeaderText.Error);
                    return;
                }

                ClearOldYearValuesAndSetSelectedIndex();
                MessageBox.Show("Year deleted.", MessageBoxHeaderText.Success);
            }
        }

        private void cbCompanyYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GetSelectedYearId();
            DisplayInfoForYear(id);
        }

        private List<FiscalYear> GetYears()
        {
            string businessIdentityCode = tbBusinessIdentityCode.Text;

            try
            {
                return CurrentApiClient.Instance.GetFiscalYearResource(businessIdentityCode).List();
            }
            catch (ApiException e)
            {
                MessageBox.Show(e.Message, MessageBoxHeaderText.Error);
            }

            return new List<FiscalYear>();
        }

        private void PopulateListBoxWithYears()
        {
            cbCompanyYears.Items.Clear();
            
            foreach (FiscalYear year in years)
            {
                string formatetYear = string.Format("{0}-{1} ({2})",
                    year.Start.ToShortDateString(),
                    year.End.ToShortDateString(),
                    year.Id);
                cbCompanyYears.Items.Add(formatetYear);
            }

            if (cbCompanyYears.Items.Count > 0)
            {
                cbCompanyYears.SelectedIndex = 0;
                DisplayInfoForYear(GetSelectedYearId());
            }
        }

        private void ClearOldYearValues()
        {
            tbYearId.Text = string.Empty;
            tbStartOfYear.Text = string.Empty;
            tbEndOfYear.Text = string.Empty;
            tbLastLedgerDate.Text = string.Empty;
            tbCurrency.Text = string.Empty;
            tbChartOfAccount.Text = string.Empty;
        }

        private void ClearOldYearValuesAndSetSelectedIndex()
        {
            ClearOldYearValues();
            
            // remove deleted year and reset index
            cbCompanyYears.Items.Remove(cbCompanyYears.SelectedItem);
            if (cbCompanyYears.Items.Count > 0)
            {
                cbCompanyYears.SelectedIndex = 0;
            }
            else
            {
                cbCompanyYears.SelectedIndex = -1;
            }
        }
        
        private string GetSelectedYearId()
        {
            // Parse year identifier out of paranteses in string with the format "Start-End (id)"
            if (cbCompanyYears.SelectedIndex > -1)
            {
                string value = cbCompanyYears.SelectedItem.ToString();

                string id = value.Substring(value.LastIndexOf("(") + 1).Replace(")", string.Empty);

                return id;
            }

            return string.Empty;
        }

        private void DisplayInfoForYear(string yearIdentifier)
        {
            FiscalYear year = years.FirstOrDefault(y => y.Id.Equals(yearIdentifier));

            if (year == null)
            {
                MessageBox.Show("Could not find year to show", MessageBoxHeaderText.Info);
            }
            else
            {
                tbYearId.Text = year.Id;
                tbStartOfYear.Text = year.Start.ToShortDateString();
                tbEndOfYear.Text = year.End.ToShortDateString();
                tbLastLedgerDate.Text = year.LastLedgerDate.ToShortDateString();
                tbCurrency.Text = year.Currency;
                tbChartOfAccount.Text = year.ChartOfAccountsType.ToString();
            }
        }
    }
}
