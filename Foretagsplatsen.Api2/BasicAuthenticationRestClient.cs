using System;
using System.IO;
using System.Net;

namespace Foretagsplatsen.Api2
{
    /// <summary>
    /// Basic Authentication client to sign and execute REST requests.
    /// </summary>
    public class BasicAuthenticationRestClient : IRestClient
    {
        private readonly string baseUrl;

        /// <summary>
        /// Url needed when accessing building URLs for
        /// accessing the OAuthCredentialService
        /// </summary>
        public string BaseUrl
        {
            get { return baseUrl; }
        }


        public BasicAuthenticationRestClient(string username, string password, string baseUrl)

        {
            // Basic Authentication
            BasicCredentials = new CredentialCache
            {
                {
                    new Uri(baseUrl), 
                    "Basic", new NetworkCredential(username, password)
                }
            };

            this.baseUrl = baseUrl;
        }

        protected CredentialCache BasicCredentials { get; set; }

        public WebResponse MakeRequest(string httpMethod, string url, object arguments)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Accept = "application/json";
            request.Method = httpMethod;
            request.ContentType = "application/json";

            request.Credentials = BasicCredentials;

            if (arguments != null && (httpMethod == "POST" || httpMethod == "PUT"))
            {
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(arguments.ToString());
                }
            }
            else if (httpMethod == "POST" || httpMethod == "PUT")
            {
                request.ContentLength = 0;
            }

            return request.GetResponse();
        }
    }
}