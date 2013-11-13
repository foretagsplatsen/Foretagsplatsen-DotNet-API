using System;
using System.Net;
using DevDefined.OAuth.Consumer;

namespace Foretagsplatsen.Api2
{
    /// <summary>
    /// OAuth client to sign and execute REST requests.
    /// </summary>
    public class OAuthRestClient : IRestClient
    {
        private readonly OAuthCredentials credentials;
        private readonly string baseUrl;

        /// <summary>
        /// Url needed when accessing building URLs for
        /// accessing the OAuthCredentialService
        /// </summary>
        public string BaseUrl { get { return baseUrl; } }

        /// <summary>
        /// Instantiate a new <see cref="OAuthRestClient"/>
        /// </summary>
        /// <param name="credentials">OAuth credentials to use when signing requests.</param>
        /// <param name="baseUrl">Url needed when accessing building URLs for
        /// accessing the OAuthCredentialService</param>
        public OAuthRestClient(OAuthCredentials credentials, string baseUrl)
        {
            this.credentials = credentials;
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Add OAuth signing to requests and executes the request.
        /// </summary>
        /// <param name="httpMethod">HTTP Verb (GET, POST, PUT, DELETE)</param>
        /// <param name="url">Url to execute the request against.</param>
        /// <param name="arguments">Query arguments</param>
        /// <returns>Response from server.</returns>
        public WebResponse MakeRequest(string httpMethod, string url, object arguments)
        {
            var request = CreateRequest(httpMethod, url, arguments);

            return request.GetResponse();
        }

        /// <summary>
        /// Add OAuth signing to requests and executes the request.
        /// </summary>
        /// <param name="httpMethod">HTTP Verb (GET, POST, PUT, DELETE)</param>
        /// <param name="url">Url to execute the request against.</param>
        /// <param name="arguments">Query arguments</param>
        /// <returns>The HttpWebRequest.</returns>
        public HttpWebRequest CreateRequest(string httpMethod, string url, object arguments)
        {
            IOAuthSession session = OAuthService.CreateSession(credentials, BaseUrl, String.Empty);

            IConsumerRequest request = session
                .Request()
                .ForMethod(httpMethod)
                .ForUrl(url)
                .AlterHttpWebRequest(httpRequest => httpRequest.ContentType = "application/json")
                .AlterContext(context => context.UseQueryParametersForOAuth = true)
                .SignWithToken(credentials.Token)
                .AlterHttpWebRequest(httpRequest => httpRequest.Timeout = 30*60*1000)
                .AlterHttpWebRequest(httpRequest => httpRequest.ReadWriteTimeout = 30*60*1000);


            if (arguments != null && (httpMethod == "POST" || httpMethod == "PUT"))
            {
                request.ConsumerContext.EncodeRequestBody = false;
                request.WithBody(arguments.ToString());
            }
            else if (httpMethod == "POST" || httpMethod == "PUT")
            {
                request.AlterHttpWebRequest(httpRequest => httpRequest.ContentLength = 0);
            }

            if (arguments != null && (httpMethod == "GET" || httpMethod == "DELETE"))
            {
                request.WithQueryParameters(arguments);
            }

            var httpWebRequest = ((ConsumerRequest) request).ToWebRequest();

            return httpWebRequest;
        }

        public HttpWebRequest CreateLoginRequest(LoginParameters loginParameters)
        {
            var loginToUrl = String.Format("{0}/Account/Login/{1}", baseUrl, loginParameters.BusinessIdentityCode);
            return CreateRequest("GET", loginToUrl, new { loginParameters.Service });
        }
    }
}