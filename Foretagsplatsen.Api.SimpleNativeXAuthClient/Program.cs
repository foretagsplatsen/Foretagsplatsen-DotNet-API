using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Foretagsplatsen.Api.SimpleNativeXAuthClient
{
    class Program
    {
        private const string XAuthUrl = "http://monitor2.localhost/OAuth/AccessToken";
        private const string ApiCompanyUrl = "http://monitor2.localhost/Api/Company";

        private static string consumerKey = "key";
        private static string consumerSecret = "secret";

        private static string username = "q";
        private static string password = "q";

        // XAuth parameter names and default values
        private const string XAuthUsernameParameterName = "x_auth_username";
        private const string XAuthPasswordParameterName = "x_auth_password";
        private const string XAuthModeParameterName = "x_auth_mode";
        private const string XAuthModeParameterValue = "client_auth";

        // OAuth parameter names and default values
        private const string OAuthConsumerKeyParameterName = "oauth_consumer_key";
        private const string OAuthTokenParameterName = "oauth_token";
        private const string OAuthNonceParameterName = "oauth_nonce";
        private const string OAuthTimestampParameterName = "oauth_timestamp";
        private const string OAuthSignatureMethodParameterName = "oauth_signature_method";
        private const string OAuthSignatureMethodParameterValue = "PLAINTEXT";
        private const string OAuthSignatureParameterName = "oauth_signature";

        private const string OAuthVersionParameterName = "oauth_version";
        private const string OAuthVersionParameterValue = "1.0a";

        private class XAuthResult
        {
            // ReSharper disable InconsistentNaming
            public string oauth_token { get; set; }
            public string oauth_token_secret { get; set; }
            public DateTime x_auth_expires { get; set; }
            // ReSharper restore InconsistentNaming
        }

        private class Company
        {
            public string Name { get; set; }
            public string BusinessIdentityCode { get; set; }

            // NB! The company contains more information that we don't need for the example
            // See the API documentation for more information
        }

        static void Main(string[] args)
        {            
            var xAuthResult = DoXAuth();

            if (xAuthResult != null)
            {
                Console.WriteLine("Access token");
                Console.WriteLine(string.Format("  token value: {0}", xAuthResult.oauth_token));
                Console.WriteLine(string.Format("  token secret: {0}", xAuthResult.oauth_token_secret));
                Console.WriteLine(string.Format("  expiry date: {0}", xAuthResult.x_auth_expires));
                Console.WriteLine("");

                var companies = GetCompanies(xAuthResult.oauth_token, xAuthResult.oauth_token_secret);

                Console.WriteLine("List of companies");
                Console.WriteLine("");
                foreach (var company in companies)
                {
                    Console.WriteLine(" Name: {0}", company.Name);
                    Console.WriteLine(" BusinessIdentityCode: {0}", company.BusinessIdentityCode);
                    Console.WriteLine("");
                }
                Console.WriteLine("End");

            }

        }
        private static List<Company> GetCompanies(string token, string tokenSecret)
        {
            // We can't access a protected resource without an access token
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(tokenSecret))
            {
                return new List<Company>();
            }

            // A uniqe value for every request
            var nounce = Guid.NewGuid().ToString();

            // Timestamp, totalt seconds since 1970-01-01 00:00
            var unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 01, 01, 0, 0, 0)).TotalSeconds;
            var timestamp = unixTime.ToString();

            // The request signature, see OAuth documentation for more information
            var signature = HttpUtility.UrlEncode(string.Format("{0}&{1}", consumerSecret, tokenSecret));

            // Build the http query
            var oAuthQueryBuilder = new StringBuilder();

            oAuthQueryBuilder.Append(CreateParameter(OAuthConsumerKeyParameterName, consumerKey));
            oAuthQueryBuilder.Append(CreateParameter(OAuthTokenParameterName, token));
            oAuthQueryBuilder.Append(CreateParameter(OAuthNonceParameterName, nounce));
            oAuthQueryBuilder.Append(CreateParameter(OAuthTimestampParameterName, timestamp));
            oAuthQueryBuilder.Append(CreateParameter(OAuthSignatureMethodParameterName, OAuthSignatureMethodParameterValue));
            oAuthQueryBuilder.Append(CreateParameter(OAuthVersionParameterName, OAuthVersionParameterValue));
            oAuthQueryBuilder.Append(CreateParameter(OAuthSignatureParameterName, signature));

            var query = oAuthQueryBuilder.ToString();

            var requestUrl = string.Format("{0}?{1}", ApiCompanyUrl, query);

            // Create the request
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);

            request.Accept = "application/json";
            request.Method = "GET";

            // Get the response
            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException e)
            {
                // Rude error handling, see the API documentation for more information about different error types
                Console.WriteLine("WebException: StatusCode: {0}", ((HttpWebResponse)e.Response).StatusCode);

                return null;
            }

            // Parse and return the json result
            string jsonResult;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                jsonResult = reader.ReadToEnd();
            }

            return new JavaScriptSerializer().Deserialize<List<Company>>(jsonResult);
        }

        private static XAuthResult DoXAuth()
        {
            var request = (HttpWebRequest)WebRequest.Create(XAuthUrl);

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            request.Method = "POST";

            // A uniqe value for every request
            var nounce = Guid.NewGuid().ToString();

            // Timestamp, totalt seconds since 1970-01-01 00:00
            var unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 01, 01, 0, 0, 0)).TotalSeconds;
            var timestamp = unixTime.ToString();

            // The request signature, see OAuth documentation for more information
            var signature = HttpUtility.UrlEncode(string.Format("{0}&", consumerSecret));

            // Write the oauth form parameters to the request
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(CreateParameter(XAuthUsernameParameterName, username));
                writer.Write(CreateParameter(XAuthPasswordParameterName, password));
                writer.Write(CreateParameter(XAuthModeParameterName, XAuthModeParameterValue));

                writer.Write(CreateParameter(OAuthConsumerKeyParameterName, consumerKey));
                writer.Write(CreateParameter(OAuthNonceParameterName, nounce));
                writer.Write(CreateParameter(OAuthTimestampParameterName, timestamp));
                writer.Write(CreateParameter(OAuthSignatureMethodParameterName, OAuthSignatureMethodParameterValue));
                writer.Write(CreateParameter(OAuthVersionParameterName, OAuthVersionParameterValue));
                writer.Write(CreateParameter(OAuthSignatureParameterName, signature));
            }

            // Get the response
            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException e)
            {
                // Rude error handling, see the API documentation for more information about different error types
                Console.WriteLine("WebException: StatusCode: {0}", ((HttpWebResponse)e.Response).StatusCode);
                
                return null;
            }

            // Parse and return the json result
            string jsonResult;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                jsonResult = reader.ReadToEnd();
            }


            return new JavaScriptSerializer().Deserialize<XAuthResult>(jsonResult);
        }

        private static string CreateParameter(string parameterName, string parameterValue)
        {
            return string.Format("&{0}={1}", parameterName, HttpUtility.UrlEncode(parameterValue));
        }
    }
}
