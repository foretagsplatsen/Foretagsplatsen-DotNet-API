using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;
using Foretagsplatsen.Api2.Entities.KeyFigures;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyKeyFigureDataResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyKeyFigureDataResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public CompanyKeyFigureDataResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }

        public List<KeyFigureData> List(string fiscalYearId)
        {
            string url = GetUrl(fiscalYearId);
            return client.Get<List<KeyFigureData>>(url);
        }

        public List<KeyFigureData> Update(string fiscalYearId, List<KeyFigureData> listOfKeyFigureData)
        {
            string url = GetUrl(fiscalYearId);
            return client.Put<List<KeyFigureData>>(url, JArray.FromObject(listOfKeyFigureData).ToString());            
        }

        public void Delete(string fiscalYearId)
        {
            var url = GetUrl(fiscalYearId);
            client.Delete(url);
        }

        public void Delete(FiscalYear fiscalYear)
        {
            Delete(fiscalYear.id);
        }

        #region Private methods

        private string GetUrl(string fiscalYearId)
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/KeyFigureData/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, fiscalYearId);
        }

        #endregion
    }
}