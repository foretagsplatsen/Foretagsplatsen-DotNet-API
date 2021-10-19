using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api2.Entities.User;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class UserResource : UserBaseResource
    {
        public UserResource(ApiClient client) : base(client)
        {
        }

        public List<UserInfo> List()
        {
            var url = GetUrl();
            var json = Client.Get(url);
            var jsonUsers = JArray.Parse(json);
            return jsonUsers.Select(CreateUser).ToList();
        }

        public UserInfo Get(string userName)
        {
            var url = GetUrl(userName);
            var json = Client.Get(url);
            var jsonUser = JObject.Parse(json);
            return CreateUser(jsonUser);
        }

        public UserInfo Create(UserInfo user)
        {
            var url = GetUrl();
            var json = Client.Post(url, JObject.FromObject(user).ToString());
            var jsonUser = JObject.Parse(json);
            return CreateUser(jsonUser);
        }

        public UserInfo Update(UserInfo user)
        {
            var url = GetUrl();
            var json = Client.Put(url, JObject.FromObject(user).ToString());
            var jsonUser = JObject.Parse(json);
            return CreateUser(jsonUser);
        }

        public void Delete(UserInfo user)
        {
            var url = GetUrl(user.userName);
            Client.Delete(url);
        }


        #region Private methods

        private string GetUrl(string userName = "")
        {
            const string urlFormat = "{0}/User/{1}";
            return string.Format(urlFormat, Client.BaseUrl, userName);
        }

        #endregion
    }
}