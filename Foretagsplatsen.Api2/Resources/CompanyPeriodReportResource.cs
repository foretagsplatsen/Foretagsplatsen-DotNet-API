using System;
using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyPeriodReportResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyPeriodReportResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }

        public CompanyPeriodReportResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public List<PeriodReport> List(int? latest = null)
        {
            var url = GetUrl();
            return client.Get<List<PeriodReport>>(url);
        }

        public PeriodReport Get(string id)
        {
            var url = GetUrl(id);
            return client.Get<PeriodReport>(url);
        }

        #region Private methods

        private string GetUrl(int? latest = null)
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/PeriodReport/";
            var url = string.Format(urlFormat, client.BaseUrl, companyId);

            if (latest != null)
            {
                url = string.Format("{0}?latest={1}", url, latest);
            }

            return url;
        }

        private string GetUrl(string id)
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/PeriodReport/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, id);
        }

        #endregion

    }
}