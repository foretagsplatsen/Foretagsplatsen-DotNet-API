using System;
using System.Net;

namespace Foretagsplatsen.Api
{
    public interface IRestClient
    {
        string BaseUrl { get; }
        WebResponse MakeRequest(string httpMethod, string url, object arguments);
        Uri GetUri(string url, object queryParameters);
        Uri GetUri(string url);
    }
}