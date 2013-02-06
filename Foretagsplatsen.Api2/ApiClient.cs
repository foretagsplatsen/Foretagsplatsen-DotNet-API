using System;
using System.Net;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Exceptions;
using Foretagsplatsen.Api2.Resources;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api2
{
    public class ApiClient
    {
        private readonly IRestClient restClient;
        private readonly string baseUrl;

        public ApiClient(IRestClient restClient)
        {
            this.restClient = restClient;
            this.baseUrl = restClient.BaseUrl;
        }

        public string BaseUrl
        {
            get { return baseUrl; }
        }

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

        public AgencySieImportResource GetAgencySieImportResource(Agency agency)
        {
            return new AgencySieImportResource(this, agency);
        }

        public AgencySieImportResource GetAgencySieImportResource(string agencyShortName)
        {
            return new AgencySieImportResource(this, agencyShortName);
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
            WebResponse response = GetResponse(httpMethod, url, arguments);
            return TryReadResponseBody(response);
        }

        public T Execute<T>(string httpMethod, string url, object arguments) where T : new()
        {
            WebResponse response = GetResponse(httpMethod, url, arguments);
            return ParseResponse<T>(response);
        }

        public WebResponse GetResponse(string httpMethod, string url, object arguments)
        {
            WebResponse response;
            try
            {
                response = restClient.MakeRequest(httpMethod, url, arguments);
            }
            catch (WebException exception)
            {
                response = exception.Response;
            }
            
            return response;
        }

        public static T ParseResponse<T>(WebResponse response)
        {
            string json = TryReadResponseBody(response);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string TryReadResponseBody(WebResponse response)
        {
            string json;
            try
            {
                json = response.ReadBody();
            }
            catch (Exception exception)
            {
                throw new ApiException("Failed to read response body", ApiErrorType.Unknown, exception);
            }

            HttpStatusCode statusCode = ((HttpWebResponse)(response)).StatusCode;
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.NoContent) // NoContent is returned for void Web Api methods
            {
                ApiException serverErrorException = ApiException.CreateFromJson(json);
                throw serverErrorException;
            }

            response.Close();

            return json;
        }
    }
}