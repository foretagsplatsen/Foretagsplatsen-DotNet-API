using System;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.SieImport;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class SieImportResource
    {
        private readonly ApiClient client;

        public SieImportResource(ApiClient client)
        {
            this.client = client;
        }

        public SieImportResult Upload(SieImportData importData)
        {
            var url = GetUrl();
            return client.Put<SieImportResult>(url, JObject.FromObject(importData).ToString());
        }

        public SieImportResult Upload(SieImportData importData, Agency agency)
        {
            return Upload(importData, agency.shortName);
        }

        public SieImportResult Upload(SieImportData importData, string agencyShortName)
        {
            var url = GetUrl(agencyShortName);
            return client.Put<SieImportResult>(url, JObject.FromObject(importData).ToString());
        }

        #region Private methods

        private string GetUrl()
        {
            const string importSieUrlFormat = "{0}/Api/v2/SieImport";
            return string.Format(importSieUrlFormat, client.BaseUrl);
        }
        private string GetUrl(string agencyShortName)
        {
            const string importSieUrlFormat = "{0}/Api/v2/SieImport/{1}";
            return string.Format(importSieUrlFormat, client.BaseUrl, agencyShortName);
        }

        #endregion

    }
}