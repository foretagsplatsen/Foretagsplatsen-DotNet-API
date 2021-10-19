using System;
using System.Collections.Generic;

using System.Text;
using Foretagsplatsen.Api2;
using Foretagsplatsen.Api2.Entities.SieImport;

namespace Foretagsplatsen.Api.SimpleConsoleClient
{
	class Program
	{
		private static ApiClient apiClient;

		static public void UploadData(SieImportData sieImportData, int retryCount = 3)
		{
			var importResource = apiClient.GetSieImportResource();
			try
			{
				importResource.Upload(sieImportData);
			}
			catch (Exception error)
			{
				if (retryCount <= 0) throw error;
				UploadData(sieImportData, retryCount - 1);
			}
		}

		static public string EncodeBase64(string value)
		{
			var valueBytes = Encoding.UTF8.GetBytes(value);
			return Convert.ToBase64String(valueBytes);
		}

		static public SieImportData Generate(string companyId, string year)
		{
			var generate = SieGenerator.Generate(companyId, year);
			return new SieImportData
			{
				chartOfAccountsId = "EUBAS97",
				currency = "SEK",
				data = generate,
				lastLedgerDate = DateTime.Parse(string.Concat(year, "-12-31")),
				fiscalYearStart = DateTime.Parse(string.Concat(year, "-01-01")),
				fiscalYearEnd = DateTime.Parse(string.Concat(year, "-12-31")),
				dimensionObjects = new List<string>().ToArray(),
				excludeEmptyDimensions = false
			};
		}

		static void Main()
		{
			const string baseUrl = "https://finsitapp.wolterskluwer.se/Api/v2";

			// Create a client
			apiClient = new ApiClient(new BasicAuthenticationRestClient("eldirector", "muybienmuchacho", baseUrl));

			var companyId = "556677-13680";

			var sieFiles = new[]
			{
				Generate(companyId, "1996"),
				Generate(companyId, "1997"),
				Generate(companyId, "1998"),
				Generate(companyId, "1999"),
				Generate(companyId, "2000"),
				Generate(companyId, "2001"),
				Generate(companyId, "2002"),
				Generate(companyId, "2003"),
				Generate(companyId, "2004"),
				Generate(companyId, "2005"),
				Generate(companyId, "2006"),
				Generate(companyId, "2007")
			};
			foreach (var sieFile in sieFiles)
			{
				UploadData(sieFile);
			}
		}
	}
}