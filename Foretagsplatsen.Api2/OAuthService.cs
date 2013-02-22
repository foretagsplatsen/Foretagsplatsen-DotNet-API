using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using DevDefined.OAuth.Storage.Basic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using OAuthException=DevDefined.OAuth.Framework.OAuthException;

namespace Foretagsplatsen.Api2
{
    /// <summary>
    /// Företagsplatsen OAuth service
    /// </summary>
    /// <example>
    /// Get access token using Foretagsplatsen xAuth inspired method:
    /// <code>
    /// var service = new CredentialService("key", "secret");
    /// OAuthCredentials credentials = service.GetCredentials("username", "password");
    /// </code>
    /// </example>
    /// <example>
    /// Get access token using OAuth :
    /// <code>
    /// var service = new CredentialService("key", "secret");
    /// service.RequestToken();
    /// var url = service.GetAuthorizeUrl();
    /// var verifier = RedirectUserToUrlAndGetVerifierFromResult(url);
    /// OAuthCredentials credentials = service.GetAccessToken("username", "verifier);
    /// </code>
    /// </example>
    public class OAuthService
    {
        private readonly IOAuthSession session;
        private readonly OAuthCredentials credentials;

        private IToken requestToken;

        public OAuthService(string consumerKey, string consumerSecret)
            : this(consumerKey, consumerSecret, "https://web.foretagsplatsen.se", String.Empty)
        {
        }

        public OAuthService(string consumerKey, string consumerSecret, string baseUrl, string callbackUrl)
        {
            credentials = new OAuthCredentials(consumerKey, consumerSecret);
            session = CreateSession(credentials, baseUrl, callbackUrl);
        }

        protected IToken RequestToken
        {
            get
            {
                if(requestToken == null)
                {
                    throw new ApplicationException("RequestToken missing. Call GetRequestToken to obtain a token from server.");
                }
                
                return requestToken;
            }

            set { requestToken = value; }
        }

        public OAuthCredentials Credentials
        {
            get { return credentials; }
        }

        /// <summary>
        /// The first step to authenticating a user is to obtain a request token from Företagsplatsen. 
        /// This step serves two purposes: First, to tell Företagsplatsen what you're about to do. Second, 
        /// to tell Företagsplatsen what you want to do for the OAuth callback.
        /// </summary>
        public void GetRequestToken()
        {
            try
            {
                RequestToken = session.GetRequestToken();
                
                if (RequestToken.Token == null)
                {
                    throw new ApiException("Invalid request token. (This can occur with the wrong provider host.)");
                }
            }
            catch (OAuthException ex)
            {
                // If signature_invalid then consumer key/secret is invalid
                if (ex.Report.Problem.Equals("signature_invalid"))
                {
                    throw new OAuthConsumerException(ex);
                }

                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The authorize step is where you send the user to a page on Företagsplatsen.se that will allow them to 
        /// grant your application privileges to use their account with the API. 
        /// </summary>
        /// <returns>URL for the authorization page</returns>
        public string GetAuthorizeUrl()
        {
            return session.GetUserAuthorizationUrlForToken(RequestToken);
        }

        /// <summary>
        /// The authorize step is where you send the user to a page on Företagsplatsen.se that will allow them to 
        /// grant your application privileges to use their account with the API. 
        /// </summary>
        /// <param name="callback">Callback Url. The authorization page will redirect the user to this page on sucessful authorization.</param>
        /// <returns>URL for the authorization page</returns>
        public string GetAuthorizeUrl(string callback)
        {
            return session.GetUserAuthorizationUrlForToken(RequestToken, callback);
        }

        /// <summary>
        /// Authorize using Foretagsplatsen xAuth inspired method intended for browser-less applications. 
        /// </summary>
        /// <param name="username">Username for user</param>
        /// <param name="password">Password for user.</param>
        /// <returns>An OAuth verifier.</returns>
        public string Authorize(string username, string password)
        {
            string authorizationUrl = GetAuthorizeUrl();

            var usernameAndPasswordParameters = new Dictionary<string, string>
            {
                {"username", username},
                {"password", password}
            };

            // Build request for direct of user to service provider
            IConsumerRequest authorizationRequest = session
                .Request()
                .Post()
                .ForUrl(authorizationUrl)
                .SignWithToken(RequestToken)
                .WithFormParameters(usernameAndPasswordParameters)
                .AlterHttpWebRequest(httpRequest => httpRequest.Accept = "application/json")
                .AlterHttpWebRequest(httpRequest => httpRequest.AllowAutoRedirect = false);

            // Get response from server and parse needed values from response
            HttpWebResponse authorizationResponse = authorizationRequest.ToWebResponse();

            // Read response
            string json = authorizationResponse.ReadBody();
            
            var authorizeResult  = JsonConvert.DeserializeObject<AuthorizeResult>(json);
            
            return authorizeResult.verifier;
        }

        /// <summary>
        /// Exchanges a request token for an access token.
        /// </summary>
        /// <param name="username">username for user.</param>
        /// <param name="verifier">OAuth verifier </param>
        /// <returns>OAuth credentials.</returns>
        public OAuthCredentials GetAccessToken(string username, string verifier)
        {   
            TokenBase tokenBase;
            try
            {
                tokenBase = (TokenBase)session.ExchangeRequestTokenForAccessToken(RequestToken, verifier);
            }
            catch (OAuthException ex)
            {
                // If permission_denied the Authorization failed
                if (ex.Report.Problem.Equals("permission_denied"))
                {
                    throw new OAuthAuthorizationException(ex);
                }
                
                throw;
            }

            // Create AccessToken object from base class
            credentials.Token = new AccessToken
            {
                UserName = username,
                TokenSecret = tokenBase.TokenSecret,
                Token = tokenBase.Token,
                Realm = tokenBase.Realm,
                ConsumerKey = tokenBase.ConsumerKey
            };

            return credentials;
        }

        /// <summary>
        /// Perform all necessary steps (RequestToken, Authorize, AccessToken) to get credentials.
        /// </summary>
        /// <param name="username">Username for user</param>
        /// <param name="password">Password for user.</param>
        /// <returns>OAuth credentials containing access token.</returns>
        public OAuthCredentials GetCredentials(string username, string password)
        {
            GetRequestToken();
            string verifier = Authorize(username, password);
            return GetAccessToken(username, verifier);
        }

        public static string GetRequestTokenEndpointUrl(string oAuthBaseUrl)
        {
            return String.Format("{0}/OAuth/RequestToken", oAuthBaseUrl);
        }

        public static string GetAuthorizeEndpointUrl(string oAuthBaseUrl)
        {
            return String.Format("{0}/OAuth/Authorize", oAuthBaseUrl);
        }

        public static string GetAccessTokenEndpointUrl(string oAuthBaseUrl)
        {
            return String.Format("{0}/OAuth/AccessToken", oAuthBaseUrl);
        }

        public static IOAuthSession CreateSession(OAuthCredentials credentials, string oAuthBaseUrl, string callbackUrl)
        {
            var consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = credentials.ConsumerKey,
                ConsumerSecret = credentials.ConsumerSecret
            };

            return new OAuthSession(
                consumerContext,
                GetRequestTokenEndpointUrl(oAuthBaseUrl),
                GetAuthorizeEndpointUrl(oAuthBaseUrl),
                GetAccessTokenEndpointUrl(oAuthBaseUrl),
                callbackUrl);
        }
    }
}