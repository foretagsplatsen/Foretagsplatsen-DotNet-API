using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Entities.Accounts;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api.Resources
{
    public class ChartOfAccountsResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        /// <summary>
        /// Instantiates a new <see cref="KeyFigureDataResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="company">Company</param>
        public ChartOfAccountsResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="KeyFigureDataResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="businessIdentityCode">Business identity code for company.</param>
        public ChartOfAccountsResource(ApiClient client, string businessIdentityCode)
        {
            this.client = client;
            this.businessIdentityCode = businessIdentityCode;
        }


        /// <summary>
        /// Url for the key figure data resource.
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrl()
        {
            const string yearUrlFormat = "{0}/Api/Company/{1}/ChartOfAccounts";
            return string.Format(yearUrlFormat, client.BaseUrl, businessIdentityCode);
        }

        /// <summary>
        /// Url for the key figure data resource.
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrlWithChartOfAccountsId(string chartOfAccountsId)
        {
            const string yearUrlFormat = "{0}/Api/Company/{1}/ChartOfAccounts/{2}";
            return string.Format(yearUrlFormat, client.BaseUrl, businessIdentityCode, chartOfAccountsId);
        }

        /// <summary>
        /// Url for the key figure data resource.
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrlWithFiscalYearIdAndChartOfAccountsId(string fiscalYearId, string chartOfAccountsId)
        {
            const string yearUrlFormat = "{0}/Api/Company/{1}/FiscalYear/{2}/ChartOfAccounts/{3}";
            return string.Format(yearUrlFormat, client.BaseUrl, businessIdentityCode, fiscalYearId, chartOfAccountsId);
        }

        /// <summary>
        /// Url for the key figure data resource.
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrlWithFiscalYearId(string fiscalYearId)
        {
            const string yearUrlFormat = "{0}/Api/Company/{1}/FiscalYear/{2}/ChartOfAccounts";
            return string.Format(yearUrlFormat, client.BaseUrl, businessIdentityCode, fiscalYearId);
        }

        /// <summary>
        /// Lists all chart of accounts for the company
        /// </summary>
        /// <returns>A list of chart of accoutns</returns>
        public List<ChartOfAccounts> List()
        {
            string url = GetUrl();
            return client.Get<List<ChartOfAccounts>>(url);
        }


        /// <summary>
        /// Get the chart of account by id
        /// </summary>
        /// <param name="id">The id of the chart of account</param>
        /// <returns>A chart of account</returns>
        public ChartOfAccounts Get(string id)
        {
            string url = GetUrlWithChartOfAccountsId(id);
            return client.Get<ChartOfAccounts>(url);
        }

        /// <summary>
        /// Get the chart of account for a particular fiscal year
        /// </summary>
        /// <param name="fiscalYearId">The id of the fiscal year</param>
        /// <returns>A chart of account for the year</returns>
        public ChartOfAccounts GetByFiscalYearId(string fiscalYearId)
        {
            string url = GetUrlWithFiscalYearId(fiscalYearId);
            return client.Get<ChartOfAccounts>(url);
        }

        /// <summary>
        /// Deletes a chart of account from the company. The server will return an error if the chart of account is connect to a year.
        /// </summary>
        /// <param name="chartOfAccountsId">The id of the chart of account to be deleted</param>
        public void Delete(string chartOfAccountsId)
        {
            string url = GetUrlWithChartOfAccountsId(chartOfAccountsId);
            client.Delete(url);
        }

        /// <summary>
        /// Connects a chart of account to a fiscal year
        /// </summary>
        /// <param name="fiscalYearId">The id of the fiscal year</param>
        /// <param name="chartOfAccountsId">The id of the chart of account</param>
        public void Connect(string fiscalYearId, string chartOfAccountsId)
        {
            string url = GetUrlWithFiscalYearIdAndChartOfAccountsId(fiscalYearId, chartOfAccountsId);
            client.Post(url, " ");
        }


        /// <summary>
        /// Disconnects the custom chart of account from a fiscal year and restore the default one.
        /// </summary>
        /// <param name="fiscalYearId">The id of the fiscal year</param>
        public void Disconnect(string fiscalYearId)
        {
            string url = GetUrlWithFiscalYearId(fiscalYearId);
            client.Delete(url);
        }

        /// <summary>
        /// Updates a chart of account. If the chart of account doesn't exists it will be created.
        /// </summary>
        /// <param name="id">The id of the chart of account, must match the id in the json data</param>
        /// <param name="json">JSON representation of the chart of account</param>
        public void Update(string id, string json)
        {
            string url = GetUrlWithChartOfAccountsId(id);
            
            client.Put(url, json);
        }

        /// <summary>
        /// Updates a chart of account. If the chart of account doesn't exists it will be created.
        /// </summary>
        /// <param name="chartOfAccounts">The chart of account to upload</param>
        public void Update(ChartOfAccounts chartOfAccounts)
        {
            var json = JsonConvert.SerializeObject(chartOfAccounts);

            Update(chartOfAccounts.Id, json);
        }

        /// <summary>
        /// Creates a chart of account for the company. If the chart of account id already exists, an exception will
        /// be thrown.
        /// </summary>
        /// <param name="id">The id of the chart of account, must match the id in the json data</param>
        /// <param name="json">JSON representation of the chart of account</param>
        public void Create(string id, string json)
        {
            string url = GetUrlWithChartOfAccountsId(id);

            client.Post(url, json);
        }

        /// <summary>
        /// Creates a chart of account for the company. If the chart of account id already exists, an exception will
        /// be thrown.
        /// </summary>
        /// <param name="chartOfAccounts">The chart of account to upload</param>
        public void Create(ChartOfAccounts chartOfAccounts)
        {
            var json = JsonConvert.SerializeObject(chartOfAccounts);

            Create(chartOfAccounts.Id, json);
        }

    }
}