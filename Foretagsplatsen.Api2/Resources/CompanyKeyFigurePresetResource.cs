using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.KeyFigures;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyKeyFigurePresetResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyKeyFigurePresetResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public CompanyKeyFigurePresetResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }

        public List<KeyFigurePreset> List()
        {
            var url = GetUrl();
            return client.Get<List<KeyFigurePreset>>(url);
        }

        public KeyFigurePreset Get(KeyFigurePreset keyFigurePreset)
        {
            return Get(keyFigurePreset.id);
        }

        public KeyFigurePreset Get(KeyFigurePresetId keyFigurePresetId)
        {
            return Get(keyFigurePresetId.ToString());
        }
        
        public KeyFigurePreset Get(string keyFigurePresetId)
        {
            var url = GetUrl(keyFigurePresetId);
            return client.Get<KeyFigurePreset>(url);
        }

        public KeyFigurePreset Create(KeyFigurePreset keyFigurePreset)
        {
            var url = GetUrl(keyFigurePreset);
            return client.Post<KeyFigurePreset>(url, JObject.FromObject(keyFigurePreset).ToString());
        }

        public KeyFigurePreset Update(KeyFigurePreset keyFigurePreset)
        {
            var url = GetUrl(keyFigurePreset);
            return client.Put<KeyFigurePreset>(url, JObject.FromObject(keyFigurePreset).ToString());
        }

        public void Delete(string keyFigurePresetId)
        {
            var url = GetUrl(keyFigurePresetId);
            client.Delete(url);
        }

        public void Delete(KeyFigurePreset keyFigurePreset)
        {
            Delete(keyFigurePreset.id);
        }

        public void Delete(KeyFigurePresetId keyFigurePresetId)
        {
            Delete(keyFigurePresetId.ToString());
        }

        #region Private methods

        private string GetUrl(KeyFigurePreset keyFigurePreset)
        {
            return GetUrl(keyFigurePreset.id);
        }

        private string GetUrl(string keyFigurePresetId = "")
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/KeyFigurePreset/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, keyFigurePresetId);
        }

        #endregion
    }
}