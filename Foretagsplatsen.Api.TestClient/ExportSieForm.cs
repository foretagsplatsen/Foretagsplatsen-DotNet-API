using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public delegate void ExportEventHandler(object sender, EventArgs e);

    /// <summary>
    /// When uploading a SIE file to the provider this form is
    /// displayed.
    /// </summary>
    public partial class ExportSieForm : Form
    {
        private string sieFileData;

        public ExportSieForm()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSieFile.Text))
            {
                return;
            }

            ExportSie();
        }

        private void ExportSie()
        {
            string currencySymbol = new RegionInfo(new CultureInfo(cbCurrency.Text).LCID).ISOCurrencySymbol;

            var projects = new List<string>();
            foreach (object project in lbProjects.SelectedItems)
            {
                projects.Add(project.ToString());
            }

            var chartOfAccountsType = (ChartOfAccountsType) Enum.Parse(typeof (ChartOfAccountsType), cbChartOfAccount.Text, true);

            // Upload SIE
            Uri uri;
            ImportSieResult sieImportResult;
            try
            {
                sieImportResult = CurrentApiClient.Instance.GetImportSieResource().Upload(
                    new ImportData
                    {
                        Data = sieFileData,
                        ChartOfAccountsType = chartOfAccountsType,
                        Currency = currencySymbol,
                        DimensionObjects = projects.ToArray(),
                        LastLedgerDate = DateTime.Now
                    });

                uri = CurrentApiClient.Instance.GetLoginUrl();

                if (sieImportResult == null || uri == null)
                {
                    throw new ApplicationException("Unknown error");
                }
            }
            catch (ApiException e)
            {
                MessageBox.Show(e.Message, MessageBoxHeaderText.Error);
                return;
            }

            // Check if upload was successful
            if (!sieImportResult.Success)
            {
                string messages = sieImportResult.FormatErrors() + sieImportResult.FormatWarnings();
                MessageBox.Show(messages, MessageBoxHeaderText.Info);
                return;
            }

            string message = sieImportResult.HasWarnings
                                 ?
                                     sieImportResult.FormatWarnings()
                                 :
                                     "Imported without errors or warnings";

            message += Environment.NewLine + "Go to Företagsplatsen and check the uploaded company ?";

            DialogResult result = MessageBox.Show(message, "Sie upload OK.", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == result)
            {
                MainForm.OpenAddressInWebBrowser(uri.AbsoluteUri);
            }
        }

        private void btnSelectSieFile_Click(object sender, EventArgs e)
        {
            openSieFileDialog.Filter =
                "All files (*.*)|*.*|txt files (*.txt)|*.txt|sie files (*.sie)|*.sie";
            openSieFileDialog.Title = "Select a text file";
            if (openSieFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openSieFileDialog.FileName))
                {
                    tbSieFile.Text = openSieFileDialog.FileName;
                    ParseSieFile();
                }
            }
        }

        private void ParseSieFile()
        {
            // Todo change this to your own values for select siefile

            using (var streamReader = new StreamReader(tbSieFile.Text, Encoding.GetEncoding(437)))
            {
                sieFileData = streamReader.ReadToEnd();
            }

            tbLatestTransactionDay.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

            cbCurrency.Items.AddRange(new[] {"sv-SE", "en-GB", "nb-NO"});
            cbCurrency.Text = "sv-SE";

            cbChartOfAccount.Items.Clear();
            foreach (ChartOfAccountsType item in Enum.GetValues(typeof (ChartOfAccountsType)))
            {
                cbChartOfAccount.Items.Add(item);
            }
            cbChartOfAccount.SelectedIndex = 0;

            lbProjects.Items.Clear();
            lbProjects.Items.AddRange(new[] {"project1", "project2", "project3"});
        }
    }
}