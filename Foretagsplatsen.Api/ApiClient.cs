using System;
using System.IO;
using System.Net;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;
using Foretagsplatsen.Api.Resources;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api
{
    /// <summary>
    /// A simple client for Företagsplatsen REST API. 
    /// </summary>
    public class ApiClient
    {
        private readonly OAuthRestClient restClient;
        private readonly string baseUrl;

        /// <summary>
        /// Instantiates a new <seealso cref="ApiClient"/>
        /// </summary>
        /// <param name="credentials">oAuth credentials</param>
        public ApiClient(OAuthCredentials credentials)
            : this("https://web.foretagsplatsen.se", credentials)
        {
        }

        /// <summary>
        /// Instantiates a new <seealso cref="ApiClient"/>
        /// </summary>
        /// <param name="baseUrl">Base url for the API. E.g. http://web.foretagsplatsen.se/ </param>
        /// <param name="credentials"></param>
        public ApiClient(string baseUrl, OAuthCredentials credentials)
        {
            this.baseUrl = baseUrl;
            restClient = new OAuthRestClient(credentials, baseUrl);
        }

        /// <summary>
        /// Base Url used when building Url´s for the API endpoints. E.g. if BaseUrl 
        /// is set to http://web.foretagsplatsen.se/ then the endpoint for the company 
        /// resource will be set to http://web.foretagsplatsen.se/Api/Company/
        /// </summary>
        public string BaseUrl
        {
            get { return baseUrl; }
        }

        /// <summary>
        /// Instantiates a new <seealso cref="CompanyResource"/>
        /// </summary>
        /// <returns>Company Resource</returns>
        public CompanyResource GetCompanyResource()
        {
            return new CompanyResource(this);
        }

        /// <summary>
        /// Instantiates a new <seealso cref="FiscalYearResource"/>
        /// </summary>
        /// <param name="company">Company to get the fiscal year resource for.</param>
        /// <returns><see cref="FiscalYearResource"/></returns>
        public FiscalYearResource GetFiscalYearResource(CompanyInfo company)
        {
            return new FiscalYearResource(this, company);
        }

        /// <summary>
        /// Instantiates a new <seealso cref="FiscalYearResource"/>
        /// </summary>
        /// <param name="businessIdentityCode">Business identity code for the company to get the fiscal year resource for.</param>
        /// <returns><see cref="FiscalYearResource"/></returns>
        public FiscalYearResource GetFiscalYearResource(string businessIdentityCode)
        {
            return new FiscalYearResource(this, businessIdentityCode);
        }

        /// <summary>
        /// Instantiates a new <seealso cref="ImportSieResource"/>
        /// </summary>
        /// <returns><see cref="ImportSieResource"/></returns>
        public ImportSieResource GetImportSieResource()
        {
            return new ImportSieResource(this);
        }

        /// <summary>
        /// Login URL for Single-Sign-On (SSO). Company users will be redirected to the 
        /// Presentation UI and Agency user to the Agency UI.
        /// </summary>
        /// <returns>Url for the SSO service.</returns>
        public Uri GetLoginUrl()
        {
            string loginUrl = String.Format("{0}/Api/Account/Login", baseUrl);
            Uri uri = restClient.GetUri(loginUrl);
            return uri;
        }

        /// <summary>
        /// Login URL for Single-Sign-On (SSO) to a specific company. 
        /// </summary>
        /// <param name="businessIdentityCode">Business identity code for company to login to.</param>
        /// <returns>Url for the SSO service.</returns>
        public Uri GetLoginUrl(string businessIdentityCode)
        {
            string loginToUrl = String.Format("{0}/Api/Account/Login", baseUrl);
            var queryParameters = new { id = businessIdentityCode };
            Uri uri = restClient.GetUri(loginToUrl, queryParameters);
            return uri;
        }

        /// <summary>
        /// Execute a GET request on resource.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="resourceUrl">Url for resource.</param>
        /// <returns>Deserialized result</returns>
        public T Get<T>(string resourceUrl) where T : new()
        {
            return Get<T>(resourceUrl, null);
        }

        /// <summary>
        /// Execute a GET request on resource.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="resourceUrl">Url for resource.</param>
        /// <param name="arguments">Query parameters.</param>
        /// <returns>Deserialized result</returns>
        public T Get<T>(string resourceUrl, object arguments) where T : new()
        {
            return MakeRequest<T>(resourceUrl, arguments, "GET");
        }

        /// <summary>
        /// Execute a PUT request on resource.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="resourceUrl">Url for resource.</param>
        /// <param name="arguments">Object to send in request body.</param>
        /// <returns>Deserialized result</returns>
        public T Put<T>(string resourceUrl, object arguments) where T : new()
        {
            return MakeRequest<T>(resourceUrl, arguments, "PUT");
        }

        /// <summary>
        /// Execute a POST request on resource.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="resourceUrl">Url for resource.</param>
        /// <param name="arguments">Object to send in request body.</param>
        /// <returns>Deserialized result</returns>
        public T Post<T>(string resourceUrl, object arguments) where T : new()
        {
            return MakeRequest<T>(resourceUrl, arguments, "POST");
        }

        /// <summary>
        /// Execute a DELETE request on resource.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="resourceUrl">Url for resource.</param>
        /// <returns>Deserialized result</returns>
        public T Delete<T>(string resourceUrl) where T : new()
        {
            return Delete<T>(resourceUrl, null);
        }

        /// <summary>
        /// Execute a DELETE request on resource.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="resourceUrl">Url for resource.</param>
        /// <param name="arguments">Query parameters.</param>
        /// <returns>Deserialized result</returns>
        public T Delete<T>(string resourceUrl, object arguments) where T : new()
        {
            return MakeRequest<T>(resourceUrl, arguments, "DELETE");
        }

        /// <summary>
        /// Execute a HTTP request
        /// </summary>
        /// <typeparam name="T">Type to return and use when we deserialize the response.</typeparam>
        /// <param name="url">Url for resource</param>
        /// <param name="arguments">Query parameters if GET or DELETE and message body if POST or PUT.</param>
        /// <param name="httpMethod">HTTP Verb (GET, PUST, PUT, DELETE)</param>
        /// <returns>Deserialized result.</returns>
        public T MakeRequest<T>(string url, object arguments, string httpMethod) where T : new()
        {
            WebResponse response;
            try
            {
                response = restClient.MakeRequest(httpMethod, url, arguments);
            }
            catch (WebException exception)
            {
                response = exception.Response;
            }

            return ParseResponse<T>(response);
        }

        /// <summary>
        /// Parse a HTTP response.
        /// </summary>
        /// <typeparam name="T">Type to return and use when we parse/deserialize the response.</typeparam>
        /// <param name="response">HTTP response to parse.</param>
        /// <returns>Deserialized result.</returns>
        public static T ParseResponse<T>(WebResponse response)
        {
            // Read response
            string json;
            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream.CanSeek)
                {
                    responseStream.Seek(0, SeekOrigin.Begin);
                }
                using (var reader = new StreamReader(responseStream))
                {
                    json = reader.ReadToEnd();
                }
            }

            // Get status code
            HttpStatusCode statusCode = ((HttpWebResponse) (response)).StatusCode;

            response.Close();

            // Throw an exception if not OK
            if (statusCode != HttpStatusCode.OK)
            {
                ApiServerException serverErrorException;
                try
                {
                    serverErrorException = ApiServerException.CreateFromJson(json);
                }
                catch (Exception)
                {
                    throw new ApiServerException("Unknown error");
                }

                throw serverErrorException;
            }

            // Try to deserialize to expected type
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}