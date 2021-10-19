using System;
using Foretagsplatsen.Api2.Entities.User;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class MeResource : UserBaseResource
    {
        public MeResource(ApiClient client) :base(client)
        {
        }

        public UserInfo Get()
        {
            var url = GetUrl();
            var json = Client.Get(url);
            var jsonComment = JObject.Parse(json);
            return CreateUser(jsonComment);
        }

        #region Private methods

        private string GetUrl()
        {
            const string urlFormat = "{0}/Me";
            return string.Format(urlFormat, Client.BaseUrl);
        }

        #endregion
    }
}