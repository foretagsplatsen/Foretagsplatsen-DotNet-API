using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Company REST resource:
    /// https://web.foretagsplatsen.se/Api/Company/
    /// 
    /// Notes: 
    /// * Agency directors (administrator) has access to all the Agency's customers.
    /// * Agency consultants have access to only those customers assigned to them.
    /// * Company user have access to the companies they created/owns and those 
    ///   assigned/connected to them.
    /// * A company user can only delete a company if he is the one who 
    ///   owns (created) the company.
    /// </summary>
    public class CompanyResource
    {
        private readonly ApiClient client;

        /// <summary>
        /// Instantiates a new <see cref="CompanyResource"/> object.
        /// </summary>
        /// <param name="client">REST client to use.</param>
        public CompanyResource(ApiClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Url for the company resource.
        /// </summary>
        /// <returns>Url.</returns>
        public string GetCollectionUrl()
        {
            const string companyCollectionUrlFormat = "{0}/Api/Company";
            return String.Format(companyCollectionUrlFormat, client.BaseUrl);
        }

        /// <summary>
        /// Url for the company collection resource
        /// </summary>
        /// <param name="companyInfo">Company to get the url for.</param>
        /// <returns>Url.</returns>
        public string GetUrl(CompanyInfo companyInfo)
        {
            const string companyUrlFormat = "{0}/Api/Company/{1}/";
            return String.Format(companyUrlFormat, client.BaseUrl, companyInfo.BusinessIdentityCode);
        }
        
        /// <summary>
        /// List companies. 
        /// </summary>
        /// <returns><see cref="CompanyInfo"/>List of companies.</returns>
        public List<CompanyInfo> List()
        {
            string companyCollectionUrl = GetCollectionUrl();
            return client.Get<List<CompanyInfo>>(companyCollectionUrl);
        }

        /// <summary>
        /// Get company
        /// </summary>
        /// <param name="businessIdentityCode">Business identity code for company.</param>
        /// <returns>A company</returns>
        public CompanyInfo Get(string businessIdentityCode)
        {
            const string companyUrlFormat = "{0}/Api/Company/{1}/";
            string getCompanyUrl = String.Format(companyUrlFormat, client.BaseUrl, businessIdentityCode);

            return client.Get<CompanyInfo>(getCompanyUrl);
        }

        /// <summary>
        /// Update a company. 
        /// </summary>
        /// <remarks>
        /// Business identity code can not be edited. If the identity code
        /// is edited, the system assumes it´s a new company.
        /// </remarks>
        /// <param name="company">New company information.</param>
        public void Update(CompanyInfo company)
        {
            string companyUrl = GetUrl(company);
            client.Put<bool?>(companyUrl, JObject.FromObject(company).ToString());
        }

        /// <summary>
        /// Delete a company. 
        /// </summary>
        /// <param name="company">Company to delete.</param>
        public void Delete(CompanyInfo company)
        {
            string companyUrl = GetUrl(company);
            client.Delete<bool?>(companyUrl);
        }
    }
}