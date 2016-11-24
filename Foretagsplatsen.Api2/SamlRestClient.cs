using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Foretagsplatsen.Api2
{
    public class SamlRestClient : RestClientBase
    {
        private readonly string samlAssertion;

        public SamlRestClient(string baseUrl, string samlAssertion)
        {
            BaseUrl = baseUrl;
            this.samlAssertion = samlAssertion;
        }

        public SamlRestClient(string baseUrl, XmlDocument samlAssertionDocument)
        {
            this.BaseUrl = baseUrl;
            this.samlAssertion = samlAssertionDocument.OuterXml;
        }

        public override HttpWebRequest CreateRequest(string httpMethod, string url, object arguments)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            request.Accept = "application/json";
            request.Method = httpMethod;
            request.ContentType = "application/json";
            request.Headers.Add("SamlAssertion", samlAssertion);

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
            var loginToUrl = string.Format("{0}/Account/SamlLogin/{1}/{2}/{3}",
                BaseUrl,
                loginParameters.AgencyId,
                loginParameters.BusinessIdentityCode,
                loginParameters.Service);

            return CreateRequest("GET", loginToUrl, null);
        }
    }
}