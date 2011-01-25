using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.SimpleConsoleClient
{
    class Program
    {
        static void Main()
        {
            const string baseUrl = "https://web.foretagsplatsen.se";

            // Get credentials from OAuth service
            OAuthCredentials credentials;
            try
            {
                var service = new OAuthService("key", "secret", baseUrl, string.Empty);
                credentials = service.GetCredentials("ad", "ad");
            }
            catch (OAuthConsumerException)
            {
                Console.WriteLine("Invalid consumer key or secret");
                Console.ReadKey();
                return;
            }
            catch (OAuthAuthorizationException)
            {
                Console.WriteLine("Invalid username or password");
                Console.ReadKey();
                return;
            }


            // Create a client
            var client = new ApiClient(baseUrl, credentials);

            // List all companies
            var companyResource = client.GetCompanyResource();
            var companies = companyResource.List(true);
            foreach (CompanyInfo info in companies)
            {
                Console.WriteLine(info.Name);
            }

            var firstCompany = companies.First();

            // List fiscal years
            var fiscalYears = client.GetFiscalYearResource(firstCompany).List();
            foreach (FiscalYear year in fiscalYears)
            {
                Console.WriteLine("Year: " + year.Id);
            }

            // Update a company
            firstCompany.Name = "A brand new name";
            companyResource.Update(firstCompany);

            // Get Single-Sign-On url
            var loginUrl = client.GetLoginUrl(firstCompany.BusinessIdentityCode);
            Console.WriteLine(loginUrl);

            // Execute custom requests
            var moreCompanies = client.Get<List<CompanyInfo>>(baseUrl + "/Api/Company");
            foreach (CompanyInfo info in moreCompanies)
            {
                Console.WriteLine(info.Name);
            }

            Console.ReadKey();
        }
    }
}
