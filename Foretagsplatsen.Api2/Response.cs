using System;
using System.Net;
using System.Net.Http;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api2
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; }
        public string Body { get; }

        public Response(HttpWebResponse response)
        {
            try
            {
                Body = response.ReadBody();
                StatusCode = response.StatusCode;
                response.Close();
            }
            catch (Exception exception)
            {
                throw new ApiException("Failed to read response body", ApiErrorType.Unknown, exception);
            }

            EnsureResponseCodeIsOk();
        }

        public Response(HttpResponseMessage response)
        {
            try
            {
                Body = response.Content.ReadAsStringAsync().Result;
                StatusCode = response.StatusCode;
            }
            catch (Exception exception)
            {
                throw new ApiException("Failed to read response body", ApiErrorType.Unknown, exception);
            }

            EnsureResponseCodeIsOk();
        }

        public T Parse<T>()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(Body);

            }
            catch (Exception exception)
            {
                throw new ApiException("Failed to parse the response", ApiErrorType.Unknown, exception);
            }
        }

        private void EnsureResponseCodeIsOk()
        {
            if (StatusCode != HttpStatusCode.OK && StatusCode != HttpStatusCode.NoContent) // NoContent is returned for void Web Api methods
            {
                var serverErrorException = ApiException.CreateFromJson(Body);
                throw serverErrorException;
            }
        }
    }
}