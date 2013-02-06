using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Key figure data REST resource:
    /// https://web.foretagsplatsen.se/Api/KeyFigureData/{businessIdentityCode}/{fiscalYearId}/
    /// </summary>
    public class KeyFigureDataResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        /// <summary>
        /// Instantiates a new <see cref="KeyFigureDataResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="company">Company</param>
        public KeyFigureDataResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="KeyFigureDataResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="businessIdentityCode">Business identity code for company.</param>
        public KeyFigureDataResource(ApiClient client, string businessIdentityCode)
        {
            this.client = client;
            this.businessIdentityCode = businessIdentityCode;
        }

        /// <summary>
        /// Url for the key figure data resource.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year.</param>
        /// <returns>Url for the resource</returns>
        public string GetUrl(string fiscalYearId)
        {
            const string yearUrlFormat = "{0}/Api/KeyFigureData/{1}/{2}";
            return string.Format(yearUrlFormat, client.BaseUrl, businessIdentityCode, fiscalYearId);
        }

        /// <summary>
        /// Lists all key figure data for a company and a fiscal year.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year.</param>
        /// <returns>A list of key figure data</returns>
        public List<KeyFigureData> List(string fiscalYearId)
        {
            string url = GetUrl(fiscalYearId);
            return client.Get<List<KeyFigureData>>(url);
        }

        /// <summary>
        /// Deletes all key figure data for a company and a fiscal year.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year to delete key figure data for.</param>
        public void Delete(string fiscalYearId)
        {
            string url = GetUrl(fiscalYearId);
            client.Delete(url);
        }

        /// <summary>
        /// Updates the key figure data for a company and a fiscal year. If no data exists it will be created.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year.</param>
        /// <param name="keyFigureDataJson">The JSON list of key figure data to upload.</param>
        public void Update(string fiscalYearId, string keyFigureDataJson)
        {
            string url = GetUrl(fiscalYearId);
            client.Put(url, keyFigureDataJson);
        }

        /// <summary>
        /// Updates the key figure data for a company and a fiscal year. If no data exists it will be created.
        /// </summary>
        /// <param name="fiscalYearId">Identifier for fiscal year.</param>
        /// <param name="keyFigureDatas">The list of key figure data to upload.</param>
        public void Update(string fiscalYearId, List<KeyFigureData> keyFigureDatas)
        {
            var keyFigureDataJson = JArray.FromObject(keyFigureDatas).ToString();
            Update(fiscalYearId, keyFigureDataJson);
        }

    }
}