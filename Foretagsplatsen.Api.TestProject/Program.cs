using System;
using Foretagsplatsen.Api2;

namespace Foretagsplatsen.Api.TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "https://dev-master.foretagsplatsen.se";
            var client = new ApiClient(new BasicAuthenticationRestClient("hej", "hej123", baseUrl));

            var companyResource = client.GetCompanyResource();
            var companies = companyResource.List(true);

            foreach (var info in companies)
            {
                Console.WriteLine(info.id + " " + info.name);
                var fiscalYears = client.GetCompanyFiscalYearResource(info).List();
                foreach (var fiscalYear in fiscalYears)
                {
                    Console.WriteLine(fiscalYear.start + " " + fiscalYear.end);

                    var keyFigureResults = client.GetCompanyKeyFigureValueResource(info).List(fiscalYear.start, fiscalYear.end);
                    foreach (var keyFigureResult in keyFigureResults)
                    {
                        Console.WriteLine(keyFigureResult.keyFigure.name);
                        foreach (var keyFigureValue in keyFigureResult.keyFigureValues)
                        {
                            Console.WriteLine(keyFigureValue.value);
                        }
                    }

                    var keyFigureDatas = client.GetCompanyKeyFigureDataResource(info).List(fiscalYear.id);
                    foreach (var keyFigureData in keyFigureDatas)
                    {
                        Console.WriteLine(keyFigureData.keyFigureInfoId + " " + keyFigureData.value);
                    }
                }
            }
        }
    }
}
