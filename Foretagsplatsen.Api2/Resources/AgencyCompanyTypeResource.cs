using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;

namespace Foretagsplatsen.Api2.Resources
{
    public class AgencyCompanyTypeResource
    {
        private readonly string agencyShortName;
        private readonly ApiClient client;

        public AgencyCompanyTypeResource(ApiClient client, Agency agency) : this(client, agency.shortName)
        {
        }

        public AgencyCompanyTypeResource(ApiClient client, string agencyShortName)
        {
            this.client = client;
            this.agencyShortName = agencyShortName;
        }

        public List<CompanyType> List()
        {
            var url = GetUrl();
            return client.Get<List<CompanyType>>(url);
        }

        public CompanyType Get(string companyTypeId)
        {
            var url = GetUrl(companyTypeId);
            return client.Get<CompanyType>(url);
        }

        #region Private methods

        private string GetUrl()
        {
            return $"{client.BaseUrl}/Api/v2/Agency/{agencyShortName}/CompanyType";
        }

        private string GetUrl(string companyTypeId)
        {
            return $"{GetUrl()}/{companyTypeId}";
        }

        #endregion
    }
}