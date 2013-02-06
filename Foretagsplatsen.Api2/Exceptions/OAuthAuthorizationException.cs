namespace Foretagsplatsen.Api2.Exceptions
{
    /// <summary>
    /// Authorization failed. If username/password authorization was used then ether the username or password is wrong.
    /// If standard OAuth authorization was used the verifier is wrong or the user failed to authenticate.
    /// </summary>
    public class OAuthAuthorizationException : ApiOAuthException
    {
        public OAuthAuthorizationException(DevDefined.OAuth.Framework.OAuthException innerException) : base(innerException)
        {
        }

        public OAuthAuthorizationException(string message, DevDefined.OAuth.Framework.OAuthException innerException) : base(message, innerException)
        {
        }
    }
}