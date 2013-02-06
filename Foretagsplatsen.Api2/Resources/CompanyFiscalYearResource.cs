using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyFiscalYearResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyFiscalYearResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public CompanyFiscalYearResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }


        public List<FiscalYear> List()
        {
            var url = GetUrl();
            return client.Get<List<FiscalYear>>(url);
        }

        public FiscalYear Get(string fiscalYearId)
        {
            var url = GetUrl(fiscalYearId);
            return client.Get<FiscalYear>(url);
        }

        public void Delete(string fiscalYearId)
        {
            var url = GetUrl(fiscalYearId);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl()
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/FiscalYear";
            return string.Format(urlFormat, client.BaseUrl, companyId);
        }

        private string GetUrl(string fiscalYearId)
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/FiscalYear/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, fiscalYearId);
        }

        #endregion

    }
}