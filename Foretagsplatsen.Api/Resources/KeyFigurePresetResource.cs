using System.Collections.Generic;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Key figure data REST resource:
    /// 
    /// </summary>
    public class KeyFigurePresetResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        /// <summary>
        /// Instantiates a new <see cref="KeyFigurePresetResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="company">Company</param>
        public KeyFigurePresetResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="KeyFigurePresetResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="businessIdentityCode">Business identity code for company.</param>
        public KeyFigurePresetResource(ApiClient client, string businessIdentityCode)
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
            const string presetUrlFormat = "{0}/Api/Company/{1}/KeyFigurePreset/";
            return string.Format(presetUrlFormat, client.BaseUrl, businessIdentityCode);
        }

        /// <summary>
        /// Url for the keyfigure preset data list resource
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrlWithPresetId(string presetId)
        {
            const string presetUrlFormat = "{0}/Api/Company/{1}/KeyFigurePreset/{2}";
            return string.Format(presetUrlFormat, client.BaseUrl, businessIdentityCode, presetId);
        }

        /// <summary>
        /// Lists all KeyFigurePreset for a company.
        /// </summary>
        /// <returns>A list of KeyFigurePreset</returns>
        public List<KeyFigurePreset> List()
        {
            var url = GetUrl();
            
            return client.Get<List<KeyFigurePreset>>(url);
        }

        /// <summary>
        /// Gets a single KeyFigurePreset for a company.
        /// If the id of the KeyFigurePreset doesn't exist for the company, a NotFound exception will be thrown
        /// </summary>
        /// <param name="id">The id of the KeyFigurePreset to get</param>
        /// <returns>A singel KeyFigurePreset</returns>
        public KeyFigurePreset Get(string id)
        {
            var url = GetUrlWithPresetId(id);

            return client.Get<KeyFigurePreset>(url);
        }


        /// <summary>
        /// Creates a new KeyFigurePreset.
        /// If the KeyFigurePreset does not contain an id or a list of KeyFigureTypes, an InvalidArguments exception will be thrown
        /// If the id of the KeyFigurePreset already exists for the company, an Exists exception will be thrown.
        /// </summary>
        /// <param name="keyFigurePreset">The KeyFigurePreset to create</param>
        public void Create(KeyFigurePreset keyFigurePreset)
        {
            var url = GetUrlWithPresetId(keyFigurePreset.Id);
            var json = JObject.FromObject(keyFigurePreset).ToString();

            client.Post(url, json);
        }

        /// <summary>
        /// Creates or updates a KeyFigurePreset
        /// If the KeyFigurePreset does not contain an id or a list of KeyFigureTypes, an InvalidArguments exception will be thrown
        /// </summary>
        /// <param name="keyFigurePreset">The KeyFigurePreset to create or update</param>
        public void Update(KeyFigurePreset keyFigurePreset)
        {
            var url = GetUrlWithPresetId(keyFigurePreset.Id);
            var json = JObject.FromObject(keyFigurePreset).ToString();

            client.Put(url, json);
        }

        /// <summary>
        /// Deletes a KeyFigurePreset.
        /// If the id of the KeyFigurePreset doesn't exist for the company, a NotFound exception will be thrown
        /// </summary>
        /// <param name="id">The id of the KeyFigurePreset to delete</param>
        public void Delete(string id)
        {
            var url = GetUrlWithPresetId(id);

            client.Delete(url);
        }
    }
}
