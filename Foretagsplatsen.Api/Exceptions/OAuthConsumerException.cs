namespace Foretagsplatsen.Api.Exceptions
{
    /// <summary>
    /// Consumer key/secret is invalid.
    /// </summary>
    public class OAuthConsumerException : ApiOAuthException
    {
        public OAuthConsumerException(DevDefined.OAuth.Framework.OAuthException exception) : base(exception)
        {
            
        }
    }
}