using System;
using System.Net;

namespace Foretagsplatsen.Api2
{
    public interface IRestClient
    {
        string BaseUrl { get; }
        WebResponse MakeRequest(string httpMethod, string url, object arguments);
    }
}