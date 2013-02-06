using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Company user REST resource:
    /// https://web.foretagsplatsen.se/Api/Company/{businessIdentityCode}/User/{username}
    /// 
    /// Notes: 
    /// * Agency directors (administrator) has access to all the companys' users.
    /// * Agency consultants only has access to company users for their attached companies.
    /// * Company user has no access to company users in a company.
    /// </summary>
    public class CompanyUserResource
    {
        private ApiClient client;
        private CompanyInfo company;

        public CompanyUserResource(ApiClient apiClient, CompanyInfo companyInfo)
        {
            client = apiClient;
            company = companyInfo;
        }

        /// <summary>
        /// List connected company users
        /// </summary>
        /// <returns><see cref="UserInfo"/>List with company users</returns>
        public List<UserInfo> List()
        {
            return List(false);
        }

        /// <summary>
        /// List company users for company
        /// </summary>
        /// <param name="getNotConnectedUsers"><see langword="true"/> to get disconnected users or <see langword="false"/> to get connected users</param>
        /// <returns><see cref="UserInfo"/>List with company users</returns>
        public List<UserInfo> List(bool getNotConnectedUsers)
        {
            string companyUsersCollectionUrl = GetCollectionUrl();

            companyUsersCollectionUrl += "?notConnected=" + getNotConnectedUsers;

            return client.Get<List<UserInfo>>(companyUsersCollectionUrl);
        }

        /// <summary>
        /// Get Company user from company
        /// </summary>
        /// <param name="userName">Username in company to get</param>
        /// <returns><see cref="UserInfo"/>Information about user</returns>
        public UserInfo Get(string userName)
        {
            string companyUserForCompanyUrl = GetCompanyUserUrl(userName);
            return client.Get<UserInfo>(companyUserForCompanyUrl);
        }

        /// <summary>
        /// Url for company user in companyresource
        /// </summary>
        /// <param name="userName">Username of user in company</param>
        /// <returns>Url.</returns>
        private string GetCompanyUserUrl(string userName)
        {
            const string companyUsersForCompanyCollectionUrlFormat = "{0}/Api/Company/{1}/User/{2}";
            return String.Format(companyUsersForCompanyCollectionUrlFormat, client.BaseUrl, company.BusinessIdentityCode, userName);
        }

        /// <summary>
        /// Url for the companys' company users collection resource
        /// </summary>
        /// <returns>Url.</returns>
        private string GetCollectionUrl()
        {
            const string companyUsersForCompanyCollectionUrlFormat = "{0}/Api/Company/{1}/User/";
            return String.Format(companyUsersForCompanyCollectionUrlFormat, client.BaseUrl, company.BusinessIdentityCode);
        }

        /// <summary>
        /// Create a new company user
        /// </summary>
        /// <param name="newUser"><see cref="UserInfo"/> New user to create</param>
        /// <param name="role"><see cref="CompanyRoleType"/>The role for the user</param>
        public void Create(UserInfo newUser, CompanyRoleType role)
        {
            // Create url
            string companyUsersForCompanyCollectionUrlFormat = GetCompanyUserUrl(newUser.UserName);
            companyUsersForCompanyCollectionUrlFormat += "?role=" + role;

            client.Post(companyUsersForCompanyCollectionUrlFormat, JObject.FromObject(newUser));
        }

        /// <summary>
        /// Update a company user
        /// </summary>
        /// <param name="userInfoToUpdate"><see cref="UserInfo"/> User to update</param>
        /// <param name="role"><see cref="CompanyRoleType"/>The role for the user</param>
        public void Update(UserInfo userInfoToUpdate, CompanyRoleType role)
        {
            // Create url
            string companyUsersForCompanyCollectionUrlFormat = GetCompanyUserUrl(userInfoToUpdate.UserName);
            companyUsersForCompanyCollectionUrlFormat += "?role=" + role;

            client.Put(companyUsersForCompanyCollectionUrlFormat, JObject.FromObject(userInfoToUpdate));
        }

        /// <summary>
        /// Attach a company to a company users list with attached companies
        /// </summary>
        /// <param name="userName">Username to attach company to</param>
        /// <param name="role"><see cref="CompanyRoleType"/>The role for the user</param>
        public void Attach(string userName, CompanyRoleType role)
        {
            // Create url
            string companyUsersForCompanyCollectionUrlFormat = GetCompanyUserUrl(userName);
            companyUsersForCompanyCollectionUrlFormat += "?role=" + role;

            client.Put(companyUsersForCompanyCollectionUrlFormat, null);
        }

        /// <summary>
        /// Delete or detach 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="detach"></param>
        public void Delete(string userName, bool detach)
        {
            string companyUsersForCompanyCollectionUrlFormat = GetCompanyUserUrl(userName);

            // Add detach option to request
            companyUsersForCompanyCollectionUrlFormat += "?onlyDetach=" + detach;

            client.Delete(companyUsersForCompanyCollectionUrlFormat, null);
        }
    }
}