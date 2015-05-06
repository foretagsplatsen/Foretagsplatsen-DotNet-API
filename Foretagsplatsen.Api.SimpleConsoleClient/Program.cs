using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api2;
using Foretagsplatsen.Api2.Entities.Company;

namespace Foretagsplatsen.Api.SimpleConsoleClient
{
    class Program
    {
        const string BaseUrl = "https://web.foretagsplatsen.se";

        public static IRestClient SelectAuthenticationMethod()
        {
            Console.WriteLine("Authentication method:");
            Console.WriteLine("1. Basic Authentication");
            Console.WriteLine("2. OAuth");
            Console.WriteLine("3. SAML");

            var result = Console.ReadKey(false);
            Console.WriteLine();

            switch (result.KeyChar.ToString())
            {
                case "1":
                    return new BasicAuthenticationRestClient("apidirector", "api", BaseUrl);
                case "2":
                    //TODO: api test konto
                    var oAuthService = new OAuthService("henrik_iphone_test", "ae3f41c7ae02a780");
                    var credentials = oAuthService.GetCredentials("apidirector", "api");
                    return new OAuthRestClient(credentials, BaseUrl);
                case "3":
                    throw new NotImplementedException();
            }

            throw new ApplicationException("Not a valid authentication method");
        }


        static void Main()
        {
            var credentials = SelectAuthenticationMethod();

            // Create a client
            var client = new ApiClient(credentials);

            // Who am I?
            var meResource = client.GetMeResource();
            var me = meResource.Get();
            Console.WriteLine("Name: " + me.name);
            Console.WriteLine("User Type: " + me.type);

            // List all companies
            var companyResource = client.GetCompanyResource();
            var companies = companyResource.List(showAll: true);
            foreach (var info in companies)
            {
                Console.WriteLine(info.name);
            }

            var firstCompany = companies.First();

            // List fiscal years
            var fiscalYears = client.GetCompanyFiscalYearResource(firstCompany).List();
            foreach (var year in fiscalYears)
            {
                Console.WriteLine("Year: " + year.id);
            }

            // Company Data
            //TODO: support quarters/years
            //TODO: support period changes
            var netSales = client.GetCompanyKeyFigureValueResource(firstCompany).Get(keyFigureId: "NetSales");
            Console.WriteLine(netSales.keyFigure.name);
            var values = netSales.keyFigureValues.Select(kv => kv.value);
            Console.WriteLine(String.Join("|", values));

            // Update a company
            firstCompany.name = "First Company";
            companyResource.Update(firstCompany);

            // Get Single-Sign-On URL
            //TODO: Support SAML authenticated requests
            var loginUrl = client.GetLoginRequest(businessIdentityCode: firstCompany.businessIdentityCode, service: LoginParameters.MyCompaniesServiceName);
            Console.WriteLine(loginUrl.RequestUri);

            // Execute custom requests
            //TODO: Base URL should automaticly be added to all requests
            var moreCompanies = client.Get<List<CompanyInfo>>(BaseUrl + "/Api/v2/Company");
            foreach (var info in moreCompanies)
            {
                Console.WriteLine(info.name);
            }

            Console.ReadKey();
        }
    }
}
