using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class AgencyCompanyResource
    {
        private readonly ApiClient client;
        private readonly string agencyShortName;

        public AgencyCompanyResource(ApiClient client, Agency agency) : this(client, agency.shortName)
        {
        }

        public AgencyCompanyResource(ApiClient client, string agencyShortName)
        {
            this.client = client;
            this.agencyShortName = agencyShortName;
        }

        public List<CompanyInfo> List()
        {
            string url = GetUrl();
            return client.Get<List<CompanyInfo>>(url);
        }

        public CompanyInfo Get(string companyId)
        {
            string url = GetUrl(companyId);
            return client.Get<CompanyInfo>(url);
        }

        public CompanyInfo Create(CompanyInfo company)
        {
            string url = GetUrl(company);
            return client.Post<CompanyInfo>(url, JObject.FromObject(company).ToString());
        }

        public CompanyInfo Update(CompanyInfo company)
        {
            string url = GetUrl(company);
            return client.Put<CompanyInfo>(url, JObject.FromObject(company).ToString());
        }

        public void Delete(CompanyInfo company)
        {
            Delete(company.id);
        }

        public void Delete(string companyId)
        {
            string url = GetUrl(companyId);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl()
        {
            const string urlFormat = "{0}/Api/v2/Agency/{1}/Company";
            return string.Format(urlFormat, client.BaseUrl, agencyShortName);
        }

        private string GetUrl(string companyId)
        {
            const string urlFormat = "{0}/Api/v2/Agency/{1}/Company/{2}";
            return string.Format(urlFormat, client.BaseUrl, agencyShortName, companyId);
        }

        private string GetUrl(CompanyInfo companyInfo)
        {
            return GetUrl(companyInfo.id);
        }

        #endregion

    }
}