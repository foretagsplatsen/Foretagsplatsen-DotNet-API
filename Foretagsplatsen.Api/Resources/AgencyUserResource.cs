using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Rest resource for agency users
    /// https://web.foretagsplatsen.se/Api/AgencyUser/{username}/
    /// </summary>
    public class AgencyUserResource
    {
        private readonly ApiClient client;

        public AgencyUserResource(ApiClient apiClient)
        {
            client = apiClient;
        }

        /// <summary>
        /// Url for the agency user collection resource
        /// </summary>
        /// <returns>Url.</returns>
        private string GetCollectionUrl()
        {
            const string agencyUserCollectionUrlFormat = "{0}/Api/AgencyUser/";
            return String.Format(agencyUserCollectionUrlFormat, client.BaseUrl);
        }

        /// <summary>
        /// Url for the agency user resource
        /// </summary>
        /// <param name="username">Username to get url for</param>
        /// <returns>Url.</returns>
        private string GetAgencyUserUrl(string username)
        {
            const string agencyUserUrlFormat = "{0}/Api/AgencyUser/{1}";
            return string.Format(agencyUserUrlFormat, client.BaseUrl, username);
        }

        /// <summary>
        /// Get a list of agency users in an agency
        /// </summary>
        /// <returns>a list of user information objects <see>UserInfo</see></returns>
        public List<UserInfo> List()
        {
            string agencyUserCollectionUrl = GetCollectionUrl();
            return client.Get<List<UserInfo>>(agencyUserCollectionUrl);
        }

        /// <summary>
        /// Get an agency user
        /// </summary>
        /// <param name="username">Name of agency user to get</param>
        /// <returns><see>UserInfo</see> with user information</returns>
        public UserInfo Get(string username)
        {
            var agencyUserUrl = GetAgencyUserUrl(username);
            return client.Get<UserInfo>(agencyUserUrl);
        }

        /// <summary>
        /// Update an agency user
        /// </summary>
        /// <param name="updatedUserInfo"><see>UserInfo</see> to update agency user with</param>
        public void Update(UserInfo updatedUserInfo)
        {
            var agencyUserUrl = GetAgencyUserUrl(updatedUserInfo.UserName);
            client.Put(agencyUserUrl, JObject.FromObject(updatedUserInfo));
        }

        /// <summary>
        /// Create an agency user
        /// </summary>
        /// <param name="userToCreate"><see>UserInfo</see> to create</param>
        public void Create(UserInfo userToCreate)
        {
            var agencyUserUrl = GetAgencyUserUrl(userToCreate.UserName);
            client.Post(agencyUserUrl, JObject.FromObject(userToCreate));
        }

        /// <summary>
        /// Delete an agency user
        /// </summary>
        /// <param name="userToDelete"><see>UserInfo</see> to delete</param>
        public void Delete(UserInfo userToDelete)
        {
            Delete(userToDelete.UserName);
        }

        /// <summary>
        /// Delete an agency user
        /// </summary>
        /// <param name="username"><see>UserInfo</see> to delete</param>
        public void Delete(string username)
        {
            var agencyUserUrl = GetAgencyUserUrl(username);
            client.Delete(agencyUserUrl);
        }
    }
}