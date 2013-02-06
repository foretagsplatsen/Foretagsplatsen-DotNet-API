using System;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Exceptions
{
    public class ApiException : Exception
    {
        public string TypeOfError { get; set; }
        public string Identifier { get; set; }

        public ApiException()
        {}

        public ApiException(string message, string errorType)
            : base(message)
        {
            TypeOfError = errorType;
        }

        public ApiException(string message, string errorType, string identifier)
            : base(message)
        {
            TypeOfError = errorType;
            Identifier = identifier;
        }

        public ApiException(string message, string errorType, Exception innerException)
            : base(message, innerException)
        {
            TypeOfError = errorType;            
        }


        public static ApiException CreateFromJson(string json)
        {
            try
            {
                var jsonObject = JObject.Parse(json);

                var message = string.Empty;
                if (jsonObject["message"] != null)
                {
                    message = jsonObject["message"].Value<string>();
                }

                var typeOfError = string.Empty;
                if (jsonObject["typeOfError"] != null)
                {
                    typeOfError = jsonObject["typeOfError"].Value<string>();
                }

                var identifier = string.Empty;
                if (jsonObject["identifier"] != null)
                {
                    identifier = jsonObject["identifier"].Value<string>();                    
                }

                return new ApiException(message, typeOfError, identifier);
            }
            catch (Exception exception)
            {
                // Usualy the case when an error message is returned from an intermediate 
                // node such as a proxy or webserver.
                throw new ApiException("Not a valid json error response.", ApiErrorType.Unknown, exception);
            }
        }

    }
}