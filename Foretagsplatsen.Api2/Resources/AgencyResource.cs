using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class AgencyResource
    {
        private readonly ApiClient client;

        public AgencyResource(ApiClient client)
        {
            this.client = client;
        }

        public List<Agency> List()
        {
            string url = GetUrl();
            return client.Get<List<Agency>>(url);
        }

        public Agency Get(string shortName)
        {
            string url = GetUrl(shortName);
            return client.Get<Agency>(url);
        }

        public Agency Create(Agency agency)
        {
            string url = GetUrl(agency);
            return client.Post<Agency>(url, JObject.FromObject(agency).ToString());
        }

        public Agency Update(Agency agency)
        {
            string url = GetUrl(agency);
            return client.Put<Agency>(url, JObject.FromObject(agency).ToString());
        }

        public void Delete(Agency agency)
        {
            Delete(agency.shortName);
        }

        public void Delete(string shortName)
        {
            string url = GetUrl(shortName);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl()
        {
            const string urlFormat = "{0}/Api/v2/Agency";
            return string.Format(urlFormat, client.BaseUrl);
        }

        private string GetUrl(string shortName)
        {
            const string urlFormat = "{0}/Api/v2/Agency/{1}";
            return string.Format(urlFormat, client.BaseUrl, shortName);
        }

        private string GetUrl(Agency agency)
        {
            return GetUrl(agency.shortName);
        }

        #endregion

    }
}