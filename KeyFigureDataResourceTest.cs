using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Foretagsplatsen.Api2;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.KeyFigures;
using Foretagsplatsen.Api2.Saml;
using NUnit.Framework;

namespace Monitor.Test.Spikes
{
    [TestFixture]
    public class KeyFigureDataResourceTest
    {
        private const string AgencyShortName = "test2";
        private const string BaseUrl = "http://narf.foretagsplatsen.se:82";

        [Test]
        public void CompanyKeyFigureDataResourceTest()
        {
            var samlRestClient = new SamlRestClient(BaseUrl, CreatePartnerSamlAssertion());
            var apiClient = new ApiClient(samlRestClient);
            var companyId = CreateAgencyCompanyId(AgencyShortName, "222222-2222");

            var companyFiscalYearResource = apiClient.GetCompanyFiscalYearResource(companyId);

            var fiscalYearsResult = companyFiscalYearResource.List();
            Assert.That(fiscalYearsResult, Is.Not.Empty);
            var year = fiscalYearsResult.First();

            Debug.WriteLine("Get key figure data");
            var companyKeyFigureDataResource = apiClient.GetCompanyKeyFigureDataResource(companyId);

            var listOfKeyFigureData = companyKeyFigureDataResource.List(year.id);
            Debug.WriteLine("--- Existing key figure data ---");
            Debug.WriteLine("--- Begin ---");
            foreach (var keyFigureData in listOfKeyFigureData)
            {
                Debug.WriteLine(string.Format("\t{0}: {1}", keyFigureData.keyFigureInfoId, keyFigureData.value));
                Debug.WriteLine(string.Format("\t{0} - {1}\n", keyFigureData.period.start.ToShortDateString(), keyFigureData.period.end.ToShortDateString()));
            }
            Debug.WriteLine("--- End ---\n\n");

            var startDate = year.start;
            var endDate = year.end;
            var newListOfKeyFigureData = new List<KeyFigureData>
            {
                new KeyFigureData{ keyFigureInfoId = "TestKeyFigure", value = 123, period = new Period(){start = startDate, end = endDate}},
                new KeyFigureData{ keyFigureInfoId = "NumberOfEmployees", value = 456, period = new Period(){start = startDate, end = endDate}},
                new KeyFigureData{ keyFigureInfoId = "TaxRate", value = 789, period = new Period(){start = startDate, end = endDate}},
            };

            var result = companyKeyFigureDataResource.Update(year.id, newListOfKeyFigureData);
            Assert.That(result, Is.Not.Empty);


            var updatedListOfKeyFigureData = companyKeyFigureDataResource.List(year.id);
            Debug.WriteLine("--- Print Updated key figure data ---");
            Debug.WriteLine("--- Begin ---");
            foreach (var keyFigureData in updatedListOfKeyFigureData)
            {
                Debug.WriteLine(string.Format("\t{0}: {1}", keyFigureData.keyFigureInfoId, keyFigureData.value));
                Debug.WriteLine(string.Format("\t{0} - {1}\n", keyFigureData.period.start.ToShortDateString(), keyFigureData.period.end.ToShortDateString()));
            }

            Debug.WriteLine("--- End ---\n\n");

            companyKeyFigureDataResource.Delete(year.id);
            var emptyListOfKeyFigureData = companyKeyFigureDataResource.List(year.id);
            Debug.WriteLine("--- This should be an empty list of key figure data ---");
            Debug.WriteLine("--- Begin ---");
            foreach (var keyFigureData in emptyListOfKeyFigureData)
            {
                Debug.WriteLine(string.Format("\t{0}: {1}", keyFigureData.keyFigureInfoId, keyFigureData.value));
                Debug.WriteLine(string.Format("\t{0} - {1}\n", keyFigureData.period.start.ToShortDateString(), keyFigureData.period.end.ToShortDateString()));
            }

            Debug.WriteLine("--- End ---");
        }

        private string CreateAgencyCompanyId(string agencyShortName, string businessIdenityCode)
        {
            return string.Format("a-{0}-{1}", agencyShortName, businessIdenityCode);
        }

        private XmlDocument CreatePartnerSamlAssertion()
        {
            // Certificate paths
            const string privateCertificatePath = @"C:\Temp\narf\NARF-example.pfx";
            const string pathToFtgpPublicCertificate = @"C:\Temp\narf\ftgp_saml_test_cert.crt";

            var privateCertificate = new X509Certificate2(privateCertificatePath, "asd123", X509KeyStorageFlags.MachineKeySet);
            var ftgpPublicCertificate = new X509Certificate2(pathToFtgpPublicCertificate);


            var ftgpSamlAssertionService = new FtgpSamlAssertionService(privateCertificate, ftgpPublicCertificate, "http://issuer.narfekstra.no/trust");

            var partnerUserSamlAssertionInfo = new FtgpSamlAssertionInfo("Peter Partner", "info@foretagsplatsen.se", "en-US");
            partnerUserSamlAssertionInfo.AddPartnerRole("narf");

            return ftgpSamlAssertionService.CreateEncryptedAssertionDocument(partnerUserSamlAssertionInfo);
        }

    }
}