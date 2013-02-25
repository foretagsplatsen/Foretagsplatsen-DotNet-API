using System;
using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Accounts;
using Foretagsplatsen.Api2.Entities.Company;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyChartOfAccountsResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyChartOfAccountsResource(ApiClient client, CompanyInfo company)
            : this(client, company.id)
        {
        }

        public CompanyChartOfAccountsResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }


        /// <summary>
        /// Lists all chart of accounts for the company
        /// </summary>
        /// <returns>A list of chart of accoutns</returns>
        public List<ChartOfAccounts> List()
        {
            var url = GetUrl();
            return client.Get<List<ChartOfAccounts>>(url);
        }

        /// <summary>
        /// Lists all chart of accounts for the company in a specific period of time.
        /// </summary>
        /// <param name="startDate">Limit the results by this start date</param>
        /// <param name="endDate">Limit the results by this end date</param>
        /// <returns>A list of chart of accoutns</returns>
        public List<ChartOfAccounts> List(DateTime startDate, DateTime endDate)
        {
            var url = GetUrl(startDate, endDate);
            return client.Get<List<ChartOfAccounts>>(url);
        }

        /// <summary>
        /// Lists all chart of accounts for the company in a specific period of time.
        /// </summary>
        /// <param name="period">Limit the results by this period</param>
        /// <returns>A list of chart of accoutns</returns>
        public List<ChartOfAccounts> List(Period period)
        {
            var url = GetUrl(period.start, period.end);
            return client.Get<List<ChartOfAccounts>>(url);
        }

        /// <summary>
        /// Get the chart of account by id
        /// </summary>
        /// <param name="chartOfAccountsId">The id of the chart of account</param>
        /// <returns>A chart of account</returns>
        public ChartOfAccounts Get(string chartOfAccountsId)
        {
            var url = GetUrl();
            return client.Get<ChartOfAccounts>(url);
        }

        public ChartOfAccounts Create(ChartOfAccounts chartOfAccounts)
        {
            var url = GetUrl();
            return client.Post<ChartOfAccounts>(url, JObject.FromObject(chartOfAccounts).ToString());
        }

        public ChartOfAccounts Update(ChartOfAccounts chartOfAccounts)
        {
            var url = GetUrl();
            return client.Put<ChartOfAccounts>(url, JObject.FromObject(chartOfAccounts).ToString());
        }

        /// <summary>
        /// Deletes a chart of account from the company. The server will return an error if the chart of account is connect to a year.
        /// </summary>
        /// <param name="chartOfAccounts">The id of the chart of account to be deleted</param>
        public void Delete(ChartOfAccounts chartOfAccounts)
        {
            Delete(chartOfAccounts.id);
        }

        /// <summary>
        /// Deletes a chart of account from the company. The server will return an error if the chart of account is connect to a year.
        /// </summary>
        /// <param name="chartOfAccountsId">The chart of account to be deleted</param>
        public void Delete(string chartOfAccountsId)
        {
            var url = GetUrl(chartOfAccountsId);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl(string chartOfAccountsId = "")
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/ChartOfAccounts/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, chartOfAccountsId);
        }

        private string GetUrl(DateTime startDate, DateTime endDate)
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/ChartOfAccounts/?startDate={2}&endDate={3}";
            return string.Format(urlFormat, client.BaseUrl, companyId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        }
        #endregion
    }
}
