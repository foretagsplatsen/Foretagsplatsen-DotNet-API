using DevDefined.OAuth.Storage.Basic;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api
{
    /// <summary>
    /// OAuth credential object. Used when signing request against the API.
    /// </summary>
    public class OAuthCredentials
    {
        public OAuthCredentials(string key, string secret)
        {
            ConsumerKey = key;
            ConsumerSecret = secret;
        }

        public OAuthCredentials(string key, string secret, string tokenAsJson)
            : this(key, secret)
        {
            Token = JsonConvert.DeserializeObject<AccessToken>(tokenAsJson);
        }

        public AccessToken Token { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }

        public string TokenAsJson()
        {
            return JsonConvert.SerializeObject(Token);    
        }
    }
}