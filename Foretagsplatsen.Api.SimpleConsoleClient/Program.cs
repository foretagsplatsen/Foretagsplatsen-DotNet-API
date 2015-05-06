using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api2;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;

namespace Foretagsplatsen.Api.SimpleConsoleClient
{
    class Program
    {
        static void Main()
        {
            const string baseUrl = "https://web.foretagsplatsen.se";

            // Create a client
            var client = new ApiClient(new BasicAuthenticationRestClient("apiconsultant", "api", baseUrl));

            // List all companies
            var companyResource = client.GetCompanyResource();
            var companies = companyResource.List(true);
            foreach (var info in companies)
            {
                Console.WriteLine(info.name);
            }

            var firstCompany = companies.First();

            // List fiscal years
            var fiscalYears = client.GetCompanyFiscalYearResource(firstCompany).List();
            foreach (FiscalYear year in fiscalYears)
            {
                Console.WriteLine("Year: " + year.id);
            }

            // Update a company
            firstCompany.name = "A brand new name";
            companyResource.Update(firstCompany);

            // Get Single-Sign-On url
            var loginUrl = client.GetLoginRequest(LoginParameters.CreateOAuthLoginParameters(firstCompany.businessIdentityCode, "MyCompanies"));
            Console.WriteLine(loginUrl.RequestUri);

            // Execute custom requests
            var moreCompanies = client.Get<List<CompanyInfo>>(baseUrl + "/Api/v2/Company");
            foreach (CompanyInfo info in moreCompanies)
            {
                Console.WriteLine(info.name);
            }

            Console.ReadKey();
        }
    }
}
