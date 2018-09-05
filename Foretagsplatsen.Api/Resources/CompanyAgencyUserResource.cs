using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Rest resource for agency users attached to a company
    /// https://web.foretagsplatsen.se/Api/Company/{businessIdentityCode}/AgencyUser/{username}/
    /// </summary>
    public class CompanyAgencyUserResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        public CompanyAgencyUserResource(ApiClient apiClient, CompanyInfo company)
        {
            client = apiClient;
            businessIdentityCode = company.BusinessIdentityCode;
        }

        /// <summary>
        /// Url for the companys' agency user collection resource
        /// </summary>
        /// <returns>Url.</returns>
        private string GetCollectionUrl()
        {
            const string agencyUserCollectionUrlFormat = "{0}/Api/Company/{1}/AgencyUser/";
            return String.Format(agencyUserCollectionUrlFormat, client.BaseUrl, businessIdentityCode);
        }

        /// <summary>
        /// Url for the companys' agency user resource
        /// </summary>
        /// <param name="username">Username to get url for</param>
        /// <returns>Url.</returns>
        private string GetCompanyAgencyUserUrl(string username)
        {
            const string agencyUserUrlFormat = "{0}/Api/Company/{1}/AgencyUser/{2}";
            return string.Format(agencyUserUrlFormat, client.BaseUrl, businessIdentityCode, username);
        }

        /// <summary>
        /// Get a list of agency users attached to a company
        /// </summary>
        /// <returns>a list of user information objects <see>UserInfo</see></returns>
        public List<UserInfo> List()
        {
            string agencyUserCollectionUrl = GetCollectionUrl();
            return client.Get<List<UserInfo>>(agencyUserCollectionUrl);
        }
        
        /// <summary>
        /// Get an agency user that is attached to a company
        /// </summary>
        /// <param name="username">username of the agency user to get</param>
        /// <returns><see>UserInfo</see> with user information</returns>
        public UserInfo Get(string username)
        {
            string companyAgencyUserUrl = GetCompanyAgencyUserUrl(username);
            return client.Get<UserInfo>(companyAgencyUserUrl);
        }

        /// <summary>
        /// Attach a detached agency user to a company
        /// </summary>
        /// <param name="username"></param>
        public void Attach(string username)
        {
            string companyAgencyUserUrl = GetCompanyAgencyUserUrl(username);
            client.Put(companyAgencyUserUrl, null);
        }

        /// <summary>
        /// Detach an attached agency user from a company
        /// </summary>
        /// <param name="username">username to detach</param>
        public void Detach(string username)
        {
            string companyAgencyUserUrl = GetCompanyAgencyUserUrl(username);
            client.Delete(companyAgencyUserUrl);
        }
    }
}