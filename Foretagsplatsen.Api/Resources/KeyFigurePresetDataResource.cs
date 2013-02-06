using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Key figure data REST resource:
    /// 
    /// </summary>
    public class KeyFigurePresetDataResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        /// <summary>
        /// Instantiates a new <see cref="KeyFigurePresetDataResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="company">Company</param>
        public KeyFigurePresetDataResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

         /// <summary>
        /// Instantiates a new <see cref="KeyFigurePresetDataResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="businessIdentityCode">Business identity code for company.</param>
        public KeyFigurePresetDataResource(ApiClient client, string businessIdentityCode)
        {
            this.client = client;
            this.businessIdentityCode = businessIdentityCode;
        }

        /// <summary>
        /// Url for the keyfigure preset data list resource
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrl()
        {
            const string presetUrlFormat = "{0}/Api/Company/{1}/KeyFigurePresetData/";
            return string.Format(presetUrlFormat, client.BaseUrl, businessIdentityCode);
        }

        /// <summary>
        /// Url for the keyfigure preset data list resource
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrlWithPresetId(string presetId)
        {
            const string presetUrlFormat = "{0}/Api/Company/{1}/KeyFigurePresetData/{2}";
            return string.Format(presetUrlFormat, client.BaseUrl, businessIdentityCode, presetId);
        }

        /// <summary>
        /// Lists all key figure preset data for a company.
        /// </summary>
        /// <returns>A list of key figure preset data</returns>
        public List<KeyFigurePresetData> List()
        { 
            var url = GetUrl();
            return client.Get<List<KeyFigurePresetData>>(url);
        }

        /// <summary>
        /// Shows a single key figure preset data for a company.
        /// </summary>
        /// <returns>A singel key figure preset data</returns>
        public KeyFigurePresetData Get(string preset)
        {
            var url = GetUrlWithPresetId(preset);
            return client.Get<KeyFigurePresetData>(url);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of key figure preset data</returns>
        public void Save(KeyFigurePresetData preset)
        {
            var url = GetUrlWithPresetId(preset.Id);
            var json = JObject.FromObject(preset).ToString();
            client.Post(url, json);
        }

    }
}
