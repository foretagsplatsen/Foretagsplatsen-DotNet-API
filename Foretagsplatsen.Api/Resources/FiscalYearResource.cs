using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Fiscal year REST resource:
    /// https://web.foretagsplatsen.se/Api/Company/{businessIdentityCode}/FiscalYear/
    /// </summary>
    public class FiscalYearResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        /// <summary>
        /// Instantiates a new <see cref="FiscalYearResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="company">Company</param>
        public FiscalYearResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="FiscalYearResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="businessIdentityCode">Business identity code for company.</param>
        public FiscalYearResource(ApiClient client, string businessIdentityCode)
        {
            this.client = client;
            this.businessIdentityCode = businessIdentityCode;
        }

        /// <summary>
        /// Url for the fiscal year collection resource.
        /// </summary>
        /// <returns>Url for resource.</returns>
        public string GetCollectionUrl()
        {
            const string yearCollectionUrlFormat = "{0}/Api/Company/{1}/FiscalYear/";
            return String.Format(yearCollectionUrlFormat, client.BaseUrl, businessIdentityCode);
        }
        
        /// <summary>
        /// Url for the fiscal year resource.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year.</param>
        /// <returns>Url for resource.</returns>
        public string GetUrl(string fiscalYearId)
        {
            const string yearUrlFormat = "{0}/Api/Company/{1}/FiscalYear/{2}";
            return String.Format(yearUrlFormat, client.BaseUrl, businessIdentityCode, fiscalYearId);
        }

        /// <summary>
        /// List all fiscal years for a company
        /// </summary>
        /// <returns>List of fiscal years.</returns>
        public List<FiscalYear> List()
        {
            string yearCollectionUrl = GetCollectionUrl();
            return client.Get<List<FiscalYear>>(yearCollectionUrl);
        }

        /// <summary>
        /// Delete a fiscal year.
        /// </summary>
        /// <param name="year">Identifier for fiscal year.</param>
        public void Delete(FiscalYear year)
        {
            Delete(year.Id);
        }

        /// <summary>
        /// Delete a fiscal year.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year.</param>
        public void Delete(string fiscalYearId)
        {
            string yearUrl = GetUrl(fiscalYearId);
            client.Delete(yearUrl);
        }
    }
}