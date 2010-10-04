using System.Collections.Generic;

namespace Foretagsplatsen.Api.TestClient
{
    /// <summary>
    /// Repository to save all access tokens.
    /// This is just a temporary save and should be replaced 
    /// with a real one for a specific system at the consumer.
    /// </summary>
    public class SampleCredentialRepository 
    {
        private readonly Dictionary<string, string> accessTokens = new Dictionary<string, string>();
        
        public void Save(string username, string accessTokenAsJson)
        {
            accessTokens.Add(username, accessTokenAsJson);
        }

        public void Save(string username, OAuthCredentials credentials)
        {
            Save(username, credentials.TokenAsJson());
        }

        public string Find(string username)
        {
            if (username == null || !accessTokens.ContainsKey(username))
            {
                return null;
            }

            return accessTokens[username];
        }
    }
}