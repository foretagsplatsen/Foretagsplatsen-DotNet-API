using System.Net;

namespace Foretagsplatsen.Api2
{
    public abstract class RestClientBase : IRestClient
    {
        public string BaseUrl { get; protected set; }

        public virtual Response MakeRequest(string httpMethod, string url, object arguments)
        {
            WebResponse webResponse;
            try
            {
                var request = CreateRequest(httpMethod, url, arguments);
                webResponse = request.GetResponse();
            }
            catch (WebException exception)
            {
                webResponse = exception.Response;
            }

            return new Response((HttpWebResponse)webResponse);
        }

        public abstract HttpWebRequest CreateRequest(string httpMethod, string url, object arguments);
        public abstract HttpWebRequest CreateLoginRequest(LoginParameters loginParameters);
    }
}