using System;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Exceptions
{
    /// <summary>
    /// Exception thrown when an error occur on the server.
    /// </summary>
    [Serializable]
    public class ApiServerException : ApiException
    {
        public ApiServerException() { }

        public ApiServerException(string message) : base(message) { }

        public ApiServerException(string message, ApiErrorType typeOfError, string identifier)
            : base(message, typeOfError)
        {
            Identifier = identifier;
        }

        public ApiServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public string Identifier { get; private set; }

        public string FormatedMessage()
        {
            string result = Message +
                            Environment.NewLine +
                            Environment.NewLine +
                            "Id: " + Identifier;

            return result;
        }

        public static ApiServerException CreateFromJson(string json)
        {
            try
            {
                var jsonObject = JObject.Parse(json);

                var message = jsonObject["Message"].Value<string>();

                var typeOfError = (ApiErrorType)Enum.Parse(typeof(ApiErrorType),
                    jsonObject["TypeOfError"].Value<string>());

                var identifier = jsonObject["Identifier"].Value<string>();

                return new ApiServerException(message, typeOfError, identifier);
            }
            catch (Exception ex)
            {
                // Usualy the case when an error message is returned from an intermediate 
                // node such as a proxy or webserver.
                throw new ApiServerException("Not a valid json error response.", ex);
            }
        }
    }
}