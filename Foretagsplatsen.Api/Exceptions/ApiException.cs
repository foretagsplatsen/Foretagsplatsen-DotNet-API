using System;

namespace Foretagsplatsen.Api.Exceptions
{
    public class ApiException : Exception
    {
        public ApiErrorType TypeOfError { get; set; }

        public ApiException()
        {}

        public ApiException(string message)
            : base(message)
        {}

        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {}

        public ApiException(ApiErrorType errorType)
        {
            TypeOfError = errorType;
        }

        public ApiException(string message, ApiErrorType errorType)
            : base(message)
        {
            TypeOfError = errorType;            
        }

        public ApiException(string message, Exception innerException, ApiErrorType errorType)
            : base(message, innerException)
        {
            TypeOfError = errorType;            
        }

        public ApiException(Exception innerException, ApiErrorType errorType)
            : base(string.Empty, innerException)
        {
            TypeOfError = errorType;
        }

    }
}