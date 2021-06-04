using DevDefined.OAuth.Framework;

namespace Foretagsplatsen.Api2.Exceptions
{
    /// <summary>
    /// An exception caused by OAuth
    /// </summary>
    public class ApiOAuthException : ApiException
    {
        public string Problem { get; set; }
        public string Advice { get; set; }

        public ApiOAuthException(OAuthException innerException)
            : this(innerException.Message, innerException)
        {
        }

        public ApiOAuthException(string message, OAuthException innerException) : base(message, innerException)
        {
            var report = innerException.Report;
            Problem = report.Problem;
            Advice = report.ProblemAdvice;
        }
    }
}