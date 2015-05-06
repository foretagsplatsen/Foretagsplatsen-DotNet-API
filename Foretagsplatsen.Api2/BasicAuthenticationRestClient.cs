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
        private readonly string username;
        private readonly string password;

        /// <summary>
        /// Url needed when accessing building URLs for
        /// accessing the OAuthCredentialService
        /// </summary>
        public string BaseUrl { get { return baseUrl; } }

        public BasicAuthenticationRestClient(string username, string password, string baseUrl)
        {
            this.username = username;
            this.password = password;

            // Basic Authentication
            BasicCredentials = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

            this.baseUrl = baseUrl;
        }

        protected string BasicCredentials { get; set; }

        public WebResponse MakeRequest(string httpMethod, string url, object arguments)
        {
            var request = CreateRequest(httpMethod, url, arguments);
            return request.GetResponse();
        }

        public HttpWebRequest CreateRequest(string httpMethod, string url, object arguments)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            request.Accept = "application/json";
            request.Method = httpMethod;
            request.ContentType = "application/json";

            request.Headers.Add("Authorization", "Basic " + BasicCredentials);

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

            return request;
        }

        public HttpWebRequest CreateLoginRequest(LoginParameters loginParameters)
        {
            //TODO: Add support for selecting service
            var loginToUrl = String.Format("{0}/Account/Login", baseUrl);
            return CreateRequest("POST", loginToUrl, new { username, password });
        }
    }
}