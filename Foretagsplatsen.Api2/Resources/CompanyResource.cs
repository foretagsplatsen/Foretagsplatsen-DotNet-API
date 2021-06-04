using System;
using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyResource
    {
        private readonly ApiClient client;

        public CompanyResource(ApiClient client)
        {
            this.client = client;
        }

        public List<CompanyInfo> List(bool showAll)
        {
            var url = GetUrl();
            url += "?showAll=" + showAll;

            return client.Get<List<CompanyInfo>>(url);
        }

        public CompanyInfo Get(string companyId)
        {
            var url = GetUrl(companyId);
            return client.Get<CompanyInfo>(url);
        }

        public CompanyInfo Create(CompanyInfo company)
        {
            var url = GetUrl(company);
            return client.Post<CompanyInfo>(url, JObject.FromObject(company).ToString());
        }

        public CompanyInfo Update(CompanyInfo company)
        {
            var url = GetUrl(company);
            return client.Put<CompanyInfo>(url, JObject.FromObject(company).ToString());
        }

        public void Delete(CompanyInfo company)
        {
            Delete(company.id);
        }

        public void Delete(string companyId)
        {
            var url = GetUrl(companyId);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl()
        {
            const string urlFormat = "{0}/Api/v2/Company";
            return string.Format(urlFormat, client.BaseUrl);
        }

        private string GetUrl(string companyId)
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}";
            return string.Format(urlFormat, client.BaseUrl, companyId);
        }

        private string GetUrl(CompanyInfo companyInfo)
        {
            return GetUrl(companyInfo.id);
        }

        #endregion

    }
}