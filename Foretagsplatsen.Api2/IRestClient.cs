﻿using System.Net;

namespace Foretagsplatsen.Api2
{
    public interface IRestClient
    {
        string BaseUrl { get; }
        Response MakeRequest(string httpMethod, string url, object arguments);
        HttpWebRequest CreateRequest(string httpMethod, string url, object arguments);
        HttpWebRequest CreateLoginRequest(LoginParameters loginParameters);
    }
}