using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Rest resource for companies that an agency user are attached to
    /// https://web.foretagsplatsen.se/Api/AgencyUser/{username}/Company/{businessIdentityCode}/
    /// </summary>
    public class AgencyUserCompanyResource
    {
        private readonly ApiClient client;

        public AgencyUserCompanyResource(ApiClient apiClient)
        {
            client = apiClient;
        }

        /// <summary>
        /// Url for the agency user's company collection resource
        /// </summary>
        /// <param name="userName">Username to get the companies for</param>
        /// <returns>Url.</returns>
        private string GetCollectionUrl(string userName)
        {
            const string agencyUsersCompanyCollectionUrlFormat = "{0}/Api/AgencyUser/{1}/Company/";
            return String.Format(agencyUsersCompanyCollectionUrlFormat, client.BaseUrl, userName);
        }

        /// <summary>
        /// Url for an agency user's company resource
        /// </summary>
        /// <param name="userName">Username of the agency user</param>
        /// <param name="businessIdentityCode">Business identity code for the company</param>
        /// <returns>Url.</returns>
        private string GetCompanyUrlForAgencyUser(string userName, string businessIdentityCode)
        {
            const string agencyUsersCompanyCollectionUrlFormat = "{0}/Api/AgencyUser/{1}/Company/{2}";
            return string.Format(agencyUsersCompanyCollectionUrlFormat, client.BaseUrl, userName, businessIdentityCode);
        }

        /// <summary>
        /// Url for attaching and detaching company from and to company
        /// </summary>
        /// <param name="userName">Username of the agency user</param>
        /// <param name="businessIdentityCode">Business identity code for the company</param>
        /// <returns></returns>
        private string GetUrlForDetachAndAttachAgencyUser(string userName, string businessIdentityCode)
        {
            const string agencyUsersCompanyCollectionUrlFormat = "{0}/Api/Company/{1}/AgencyUser/{2}";
            return string.Format(agencyUsersCompanyCollectionUrlFormat, client.BaseUrl, businessIdentityCode, userName);
        }

        /// <summary>
        /// Get a list of companies that a user is attached to
        /// </summary>
        /// <param name="userName">Username of the user to get companies for</param>
        /// <returns>List with <see>CompanyInfo</see></returns>
        public List<CompanyInfo> List(string userName)
        {
            string companyCollectionUrl = GetCollectionUrl(userName);
            return client.Get<List<CompanyInfo>>(companyCollectionUrl);
        }

        /// <summary>
        /// Get a company from an agency users 
        /// </summary>
        /// <param name="userName">Username of the agency user</param>
        /// <param name="businessIdentityCode">Business identity code for the company</param>
        /// <returns></returns>
        public CompanyInfo Get(string userName, string businessIdentityCode)
        {
            string companyForAgencyUserUrl = GetCompanyUrlForAgencyUser(userName, businessIdentityCode);
            return client.Get<CompanyInfo>(companyForAgencyUserUrl);
        }

        /// <summary>
        /// Attach a company to an agency user
        /// </summary>
        /// <param name="userName">Username of the agency user</param>
        /// <param name="businessIdentityCode">Business identity code for the company</param>
        public void Attach(string userName, string businessIdentityCode)
        {
            string companyForAgencyUserUrl = GetUrlForDetachAndAttachAgencyUser(userName, businessIdentityCode);
            client.Put(companyForAgencyUserUrl, null);
        }

        /// <summary>
        /// Detach a company from an agency user
        /// </summary>
        /// <param name="userName">Username of the agency user</param>
        /// <param name="businessIdentityCode">Business identity code for the company</param>
        public void Detach(string userName, string businessIdentityCode)
        {
            string companyForAgencyUserUrl = GetUrlForDetachAndAttachAgencyUser(userName, businessIdentityCode);
            client.Delete(companyForAgencyUserUrl);
        }
    }
}
