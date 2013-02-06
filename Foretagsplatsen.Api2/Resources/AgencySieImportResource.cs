using System;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.SieImport;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class AgencySieImportResource
    {
        private readonly ApiClient client;
        private readonly string agencyShortName;

        public AgencySieImportResource(ApiClient client, Agency agency) : this(client, agency.shortName)
        {
        }

        public AgencySieImportResource(ApiClient client, string agencyShortName)
        {
            this.client = client;
            this.agencyShortName = agencyShortName;
        }

        public SieImportResult Upload(SieImportData importData)
        {
            string url = GetUrl();
            return client.Put<SieImportResult>(url, JObject.FromObject(importData).ToString());
        }

        #region Private methods

        private string GetUrl()
        {
            const string importSieUrlFormat = "{0}/Api/v2/Agency/{1}/SieImport/";
            return String.Format(importSieUrlFormat, client.BaseUrl, agencyShortName);
        }

        #endregion

    }
}