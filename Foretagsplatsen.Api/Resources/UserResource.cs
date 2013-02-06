using System;
using Foretagsplatsen.Api.Entities;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Rest resource for users
    /// https://web.foretagsplatsen.se/Api/Me/
    /// </summary>
    public class UserResource
    {
        private ApiClient apiClient;

        public UserResource(ApiClient client)
        {
            apiClient = client;
        }

        /// <summary>
        /// Url for information about the logged in user
        /// </summary>
        /// <returns>Url.</returns>
        private string GetMeUrl()
        {
            const string meUrlFormat = "{0}/Api/Me";
            return String.Format(meUrlFormat, apiClient.BaseUrl);
        }
        
        /// <summary>
        /// Returns information about logged in user
        /// </summary>
        /// <returns><see cref="UserInfo"/> about logged in user</returns>
        public UserInfo Me()
        {
            string getMeUrl = GetMeUrl();
            return apiClient.Get<UserInfo>(getMeUrl);
        }
    }
}