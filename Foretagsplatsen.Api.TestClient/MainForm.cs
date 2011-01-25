using System;
using System.Windows.Forms;

namespace Foretagsplatsen.Api.TestClient
{
    /// <summary>
    /// Main form that is first seen when starting the test client.
    /// </summary>
    public partial class MainForm : Form
    {
        private GetUserForm getUserForm;
        private ExportSieForm exportSieForm;
        private EditCompaniesForm editCompaniesForm;
        private Action currentAction;
                
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // Todo Setup credentials in your own way with right keys, secrets and tokens
            CurrentApiClient.ConsumerKey = tbConsumerKey.Text;
            CurrentApiClient.ConsumerSecret = tbConsumerSecret.Text;
            CurrentApiClient.Host = tbProviderHost.Text;

            getUserForm = new GetUserForm();
            getUserForm.FormClosed += GetUserForm_FormClosed;
            getUserForm.UpdateAccessTokenStatus += GetUserForm_UpdateAccessTokenStatus;
            getUserForm.Hide();

            exportSieForm = new ExportSieForm();
            exportSieForm.FormClosed += ExportSieForm_FormClosed;
            exportSieForm.Hide();

            editCompaniesForm = new EditCompaniesForm();
            editCompaniesForm.FormClosed += EditCompaniesForm_FormClosed;
        }

        private void GetUserForm_UpdateAccessTokenStatus(object sender, EventArgs e)
        {
            ShowCurrentAccessToken();
        }

        private void EditCompaniesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            editCompaniesForm = new EditCompaniesForm();
            editCompaniesForm.FormClosed += EditCompaniesForm_FormClosed;
            editCompaniesForm.Hide();
            Enabled = true;
        }
        
        private void GetUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Old form is disposed create a new form and attach events
            getUserForm = new GetUserForm();
            getUserForm.FormClosed += GetUserForm_FormClosed;
            getUserForm.UpdateAccessTokenStatus += GetUserForm_UpdateAccessTokenStatus;
            getUserForm.Hide();
            Enabled = true;
        }

        private void ExportSieForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Old form is disposed create a new form and attach events
            exportSieForm = new ExportSieForm();
            exportSieForm.FormClosed += ExportSieForm_FormClosed;
            exportSieForm.Hide();
            Enabled = true;
        }

        private void btnGoToCompany_Click(object sender, EventArgs e)
        {
            currentAction = Action.GoToCompany;
            // If there is no access token then show form for login and get a new access token
            if (CurrentApiClient.Credentials == null)
            {
                ShowLoginForm();
            }
            else
            {
                switch (currentAction)
                {
                    case Action.ExportSie:
                        ShowExportSie();
                        break;
                    case Action.GoToCompany:
                        GoToService();
                        break;
                    case Action.EditCompany:
                        ShowEditCompanyForm();
                        break;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            currentAction = Action.ExportSie;
            // If there is no access token then show form for login and get a new access token
            if (CurrentApiClient.Credentials == null)
            {
                ShowLoginForm();
            }
            else
            {
                switch (currentAction)
                {
                    case Action.ExportSie:
                        ShowExportSie();
                        break;
                    case Action.GoToCompany:
                        GoToService();
                        break;
                    case Action.EditCompany:
                        ShowEditCompanyForm();
                        break;
                }
            }
        }

        private void btnRemoveAccessToken_Click(object sender, EventArgs e)
        {
            CurrentApiClient.ResetInstance();


            tbAccessTokenUsername.Text = string.Empty;
            tbAccessToken.Text = string.Empty;
            tbAccessTokenSecret.Text = string.Empty;
        }

        private void btnEditCompanies_Click(object sender, EventArgs e)
        {
            currentAction = Action.EditCompany;
            // If there is no access token then show form for login and get a new access token
            if (CurrentApiClient.Credentials == null)
            {
                ShowLoginForm();
            }
            else
            {
                switch (currentAction)
                {
                    case Action.ExportSie:
                        ShowExportSie();
                        break;
                    case Action.GoToCompany:
                        GoToService();
                        break;
                    case Action.EditCompany:
                        ShowEditCompanyForm();
                        break;
                }
            }
        }

        private void ShowLoginForm()
        {
            Enabled = false;
            Visible = true;
            getUserForm.Visible = true;
        }

        private void ShowEditCompanyForm()
        {
            Enabled = false;
            Visible = true;
            editCompaniesForm.Show();
        }

        private void HideMainForm()
        {
            Enabled = false;
            Visible = true;
        }

        private void ShowExportSie()
        {
            HideMainForm();
            exportSieForm.Show();
        }

        private static void GoToService()
        {
            try
            {
                Uri uri = CurrentApiClient.Instance.GetLoginUrl();

                // Access resource
                OpenAddressInWebBrowser(uri.AbsoluteUri);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, MessageBoxHeaderText.Error);
            }
        }

        public static void OpenAddressInWebBrowser(string address)
        {
            System.Diagnostics.Process.Start(address);
        }

        private void ShowCurrentAccessToken()
        {
            if (CurrentApiClient.Credentials != null)
            {
                tbAccessTokenUsername.Text = CurrentApiClient.Credentials.Token.UserName;
                tbConsumerKey.Text = CurrentApiClient.Credentials.Token.ConsumerKey;
                tbAccessTokenSecret.Text = CurrentApiClient.Credentials.Token.TokenSecret;
                tbAccessToken.Text = CurrentApiClient.Credentials.Token.Token;
            }
        }

        private void tbProviderHost_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbProviderHost.Text))
            {
                MessageBox.Show("Host must be set.", MessageBoxHeaderText.Info);
                return;
            }
            CurrentApiClient.Host = tbProviderHost.Text;
        }

        private void tbConsumerKey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbConsumerKey.Text))
            {
                MessageBox.Show("Consumer key must be set.", MessageBoxHeaderText.Info);
                return;
            }
            CurrentApiClient.ConsumerKey = tbConsumerKey.Text;
        }

        private void tbConsumerSecret_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbConsumerSecret.Text))
            {
                MessageBox.Show("Consumer secret must be set.", MessageBoxHeaderText.Info);
                return;
            }
            CurrentApiClient.ConsumerSecret = tbConsumerSecret.Text;
        }
    }
}
