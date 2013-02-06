using System.IO;
using System.Net;
using System.Xml;

namespace Foretagsplatsen.Api2
{
    public class SamlRestClient : IRestClient
    {
        private readonly string baseUrl;
        private readonly string samlAssertion;

        public SamlRestClient(string baseUrl, string samlAssertion)
        {
            this.baseUrl = baseUrl;
            this.samlAssertion = samlAssertion;
        }

        public SamlRestClient(string baseUrl, XmlDocument samlAssertionDocument)
        {
            this.baseUrl = baseUrl;
            this.samlAssertion = samlAssertionDocument.OuterXml;
        }


        #region Implementation of IRestClient

        public string BaseUrl
        {
            get { return baseUrl; }
        }

        public WebResponse MakeRequest(string httpMethod, string url, object arguments)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

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
            
            return request.GetResponse();
        }

        #endregion
    }
}
