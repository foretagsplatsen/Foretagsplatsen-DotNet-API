using System;
using System.IO;
using System.Net;

namespace Foretagsplatsen.Api2
{
    /// <summary>
    /// Basic Authentication client to sign and execute REST requests.
    /// </summary>
    public class BasicAuthenticationRestClient : RestClientBase
    {
        public BasicAuthenticationRestClient(string username, string password, string baseUrl)
        {
            // Basic Authentication
            BasicCredentials = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            BaseUrl = baseUrl;
        }

        protected string BasicCredentials { get; set; }

        public override HttpWebRequest CreateRequest(string httpMethod, string url, object arguments)
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

        public override HttpWebRequest CreateLoginRequest(LoginParameters loginParameters)
        {
            var loginToUrl = $"{BaseUrl}/Account/Login";
            return CreateRequest("POST", loginToUrl, new { loginParameters.UserName, loginParameters.Password });
        }
    }
}