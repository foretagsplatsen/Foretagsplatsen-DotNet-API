using System;
using System.Windows.Forms;

namespace Foretagsplatsen.Api.TestClient
{
    /// <summary>
    /// Display login form for user. Validates the user against the provider.
    /// </summary>
    public partial class GetUserForm : Form
    {
        public delegate void UpdateAccessTokenStatusEventHandler(object sender, EventArgs e);

        // An event that clients can use to be notified whenever the
        // access token has been updated.
        public event UpdateAccessTokenStatusEventHandler UpdateAccessTokenStatus;

        public GetUserForm()
        {
            InitializeComponent();
        }
        
        private void InvokeUpdateAccessTokenStatus(EventArgs e)
        {
            UpdateAccessTokenStatusEventHandler handler = UpdateAccessTokenStatus;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        private void CreateAccessToken()
        {
            try
            {
                var service = new OAuthService(CurrentApiClient.ConsumerKey, CurrentApiClient.ConsumerSecret, CurrentApiClient.Host, string.Empty);
                CurrentApiClient.Credentials = service.GetCredentials(tbUsername.Text, tbPassword.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, MessageBoxHeaderText.Error);
                CurrentApiClient.Credentials = null;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) && string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Username and password must be set.", MessageBoxHeaderText.Info);
            }
            else
            {
                CreateAccessToken();
                InvokeUpdateAccessTokenStatus(e);
                Close();
            }
        }
    }
}
