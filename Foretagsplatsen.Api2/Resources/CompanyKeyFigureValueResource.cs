using System;
using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities.Company;
using Foretagsplatsen.Api2.Entities.KeyFigures;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyKeyFigureValueResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyKeyFigureValueResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public CompanyKeyFigureValueResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }

        public List<KeyFigureResult> List()
        {
            string url = GetUrl();
            return client.Get<List<KeyFigureResult>>(url);
        }

        public List<KeyFigureResult> List(DateTime startDate, DateTime endDate)
        {
            string url = GetUrl(startDate, endDate);
            return client.Get<List<KeyFigureResult>>(url);
        }

        public List<KeyFigureResult> List(int numberOfYears, string keyFigurePresetId)
        {
            string url = GetUrl(numberOfYears, keyFigurePresetId);
            return client.Get<List<KeyFigureResult>>(url);
        }

        public KeyFigureResult Get(string keyFigureId)
        {
            string url = GetUrl(keyFigureId);
            return client.Get<KeyFigureResult>(url);
        }

        public KeyFigureResult Get(string keyFigureId, DateTime startDate, DateTime endDate)
        {
            string url = GetUrl(keyFigureId, startDate, endDate);
            return client.Get<KeyFigureResult>(url, new { startDate, endDate });
        }

        #region Private methods

        private string GetUrl()
        {
            const string urlFormat = "{0}/Company/{1}/KeyFigureValue";
            return string.Format(urlFormat, client.BaseUrl, companyId);
        }

        private string GetUrl(DateTime startDate, DateTime endDate)
        {
            const string urlFormat = "{0}/Company/{1}/KeyFigureValue/?startDate={2}&endDate={3}";
            return string.Format(urlFormat, client.BaseUrl, companyId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        }

        private string GetUrl(string keyFigureId)
        {
            const string urlFormat = "{0}/Company/{1}/KeyFigureValue/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, keyFigureId);
        }

        private string GetUrl(string keyFigureId, DateTime startDate, DateTime endDate)
        {
            const string urlFormat = "{0}/Company/{1}/KeyFigureValue/{2}?startDate={3}&endDate={4}";
            return string.Format(urlFormat, client.BaseUrl, companyId, keyFigureId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        }

        private string GetUrl(int numberOfYears, string keyFigurePresetId)
        {
            const string urlFormat = "{0}/Company/{1}/KeyFigureValue/?numberOfYears={2}&keyFigurePresetId={3}";
            return string.Format(urlFormat, client.BaseUrl, companyId, numberOfYears, keyFigurePresetId);
        }

        #endregion
    }
}