using System;

namespace Foretagsplatsen.Api.Entities
{
    public class XAuthResult
    {
        // ReSharper disable InconsistentNaming
        public string oauth_token { get; set; }
        public string oauth_token_secret { get; set; }
        public DateTime x_auth_expires { get; set; }
        // ReSharper restore InconsistentNaming
    }
}