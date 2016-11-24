using System.Net;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;
using Foretagsplatsen.Api2.Resources;

namespace Foretagsplatsen.Api2
{
    public class ApiClient
    {
        private readonly IRestClient restClient;

        public ApiClient(IRestClient restClient)
        {
            this.restClient = restClient;
            BaseUrl = restClient.BaseUrl;
        }

        public string BaseUrl { get; }

        #region Resources

        public CompanyResource GetCompanyResource()
        {
            return new CompanyResource(this);
        }

        public AgencyResource GetAgencyResource()
        {
            return new AgencyResource(this);
        }

        public AgencyCompanyResource GetAgencyCompanyResource(Agency agency)
        {
            return new AgencyCompanyResource(this, agency);
        }

        public AgencyCompanyResource GetAgencyCompanyResource(string agencyShortName)
        {
            return new AgencyCompanyResource(this, agencyShortName);
        }

        public SieImportResource GetSieImportResource()
        {
            return new SieImportResource(this);
        }

        public CompanyKeyFigureValueResource GetCompanyKeyFigureValueResource(CompanyInfo company)
        {
            return new CompanyKeyFigureValueResource(this, company);
        }

        public CompanyKeyFigureValueResource GetCompanyKeyFigureValueResource(string companyId)
        {
            return new CompanyKeyFigureValueResource(this, companyId);
        }

        public CompanyKeyFigurePresetResource GetCompanyKeyFigurePresetResource(CompanyInfo company)
        {
            return new CompanyKeyFigurePresetResource(this, company);
        }

        public CompanyKeyFigurePresetResource GetCompanyKeyFigurePresetResource(string companyId)
        {
            return new CompanyKeyFigurePresetResource(this, companyId);
        }

        public CompanyCommentResource GetCompanyCommentResource(CompanyInfo company)
        {
            return GetCompanyCommentResource(company.id);
        }

        public CompanyCommentResource GetCompanyCommentResource(string companyId)
        {
            return new CompanyCommentResource(this, companyId);
        }

        public CompanyKeyFigureDataResource GetCompanyKeyFigureDataResource(CompanyInfo company)
        {
            return new CompanyKeyFigureDataResource(this, company);
        }

        public CompanyKeyFigureDataResource GetCompanyKeyFigureDataResource(string companyId)
        {
            return new CompanyKeyFigureDataResource(this, companyId);
        }

        public CompanyFiscalYearResource GetCompanyFiscalYearResource(CompanyInfo company)
        {
            return new CompanyFiscalYearResource(this, company);
        }

        public CompanyFiscalYearResource GetCompanyFiscalYearResource(string companyId)
        {
            return new CompanyFiscalYearResource(this, companyId);
        }

        public CompanyPeriodReportResource GetCompanyPeriodReportResource(CompanyInfo company)
        {
            return new CompanyPeriodReportResource(this, company);
        }

        public CompanyPeriodReportResource GetCompanyPeriodReportResource(string companyId)
        {
            return new CompanyPeriodReportResource(this, companyId);
        }

        public UserResource GetUserResource()
        {
            return new UserResource(this);
        }

        public MeResource GetMeResource()
        {
            return new MeResource(this);
        }

        public CompanyChartOfAccountsResource GetCompanyChartOfAccountResource(CompanyInfo company)
        {
            return GetCompanyChartOfAccountResource(company.id);
        }

        public CompanyChartOfAccountsResource GetCompanyChartOfAccountResource(string companyId)
        {
            return new CompanyChartOfAccountsResource(this, companyId);
        }

        public CompanyDocumentResource GetCompanyDocumentResource(CompanyInfo company)
        {
            return GetCompanyDocumentResource(company.id);
        }

        public CompanyDocumentResource GetCompanyDocumentResource(string companyId)
        {
            return new CompanyDocumentResource(this, companyId);
        }

        #endregion

        #region Login

        public HttpWebRequest GetLoginRequest(LoginParameters loginParameters)
        {
            return restClient.CreateLoginRequest(loginParameters);
        }

        #endregion

        #region Request methods

        public string Get(string resourceUrl)
        {
            return Get(resourceUrl, null);
        }

        public string Get(string resourceUrl, object arguments)
        {
            return Execute("GET", resourceUrl, arguments);
        }

        public T Get<T>(string resourceUrl) where T : new()
        {
            return Get<T>(resourceUrl, null);
        }

        public T Get<T>(string resourceUrl, object arguments) where T : new()
        {
            return Execute<T>("GET", resourceUrl, arguments);
        }

        public string Put(string resourceUrl, object arguments)
        {
            return Execute("PUT", resourceUrl, arguments);
        }

        public T Put<T>(string resourceUrl, object arguments) where T : new()
        {
            return Execute<T>("PUT", resourceUrl, arguments);
        }

        public string Post(string resourceUrl, object arguments)
        {
            return Execute("POST", resourceUrl, arguments);
        }

        public T Post<T>(string resourceUrl, object arguments) where T : new()
        {
            return Execute<T>("POST", resourceUrl, arguments);
        }

        public string Delete(string resourceUrl)
        {
            return Delete(resourceUrl, null);
        }

        public string Delete(string resourceUrl, object arguments)
        {
            return Execute("DELETE", resourceUrl, arguments);
        }

        public T Delete<T>(string resourceUrl) where T : new()
        {
            return Delete<T>(resourceUrl, null);
        }

        public T Delete<T>(string resourceUrl, object arguments) where T : new()
        {
            return Execute<T>("DELETE", resourceUrl, arguments);
        }

        public string Execute(string httpMethod, string url, object arguments)
        {
            var response = restClient.MakeRequest(httpMethod, url, arguments);
            return response.Body;
        }

        public T Execute<T>(string httpMethod, string url, object arguments) where T : new()
        {
            var response = restClient.MakeRequest(httpMethod, url, arguments);
            return response.Parse<T>();
        }

        #endregion
    }
}