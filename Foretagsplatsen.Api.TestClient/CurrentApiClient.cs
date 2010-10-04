using System.Windows.Forms;

namespace Foretagsplatsen.Api.TestClient
{
    public static class CurrentApiClient
    {
        private static ApiClient instance;
        private static string host;
        private static string consumerKey;
        private static string consumerSecret;

        public static ApiClient Instance
        {
            get
            {
                if (string.IsNullOrEmpty(Host) ||
                    string.IsNullOrEmpty(ConsumerKey) ||
                    string.IsNullOrEmpty(ConsumerSecret) ||
                    Credentials.Token == null)
                {
                    MessageBox.Show("Host or credentials not set.", MessageBoxHeaderText.Error);
                    return null;
                }

                if (instance == null)
                {
                    instance = new ApiClient(Host, Credentials);
                }

                return instance;
            }
        }
        
        public static string Host
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
                Credentials = null;
                instance = null;
            }
        }
        public static string ConsumerKey
        {
            get
            {
                return consumerKey;
            }
            set
            {
                consumerKey = value;
                Credentials = null;
                instance = null;
            }
        }
        public static string ConsumerSecret
        {
            get
            {
                return consumerSecret;
            }
            set
            {
                consumerSecret = value;
                Credentials = null;
                instance = null;
            }
        }
        public static OAuthCredentials Credentials { get; set; }
    }
}
