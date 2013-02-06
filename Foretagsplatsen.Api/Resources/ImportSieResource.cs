using System;
using Foretagsplatsen.Api.Entities;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// SIE-import REST resource:
    /// https://web.foretagsplatsen.se/Api/SieImport/
    ///
    /// We only support SIE-4 at the moment:
    /// http://www.sie.se/download/format/SIE_filformat_ver_4B_080930.pdf
    /// </summary>
    public class ImportSieResource
    {
        public const string ProjectSeparator = "-<_?_>-";
        private readonly ApiClient client;

        public ImportSieResource(ApiClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Url for the SIE-import resource.
        /// </summary>
        /// <returns>Url for resource.</returns>
        public string GetUrl()
        {
            const string importSieUrlFormat = "{0}/Api/SieImport/";
            return String.Format(importSieUrlFormat, client.BaseUrl);
        }

        /// <summary>
        /// Upload and import a SIE-4 file. The file must conform to the 
        /// SIE-4 specification (http://www.sie.se/download/format/SIE_filformat_ver_4B_080930.pdf)
        /// </summary>
        /// <param name="importData">The data to import, see <see cref="ImportData"/> for more information.</param>
        /// <returns>A <see cref="ImportSieResult"/> with information from the import</returns>
        public ImportSieResult Upload(ImportData importData)
        {
            string sieImportUrl = GetUrl();
            return client.Put<ImportSieResult>(sieImportUrl, JObject.FromObject(importData).ToString());
        }
    }
}