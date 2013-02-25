using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Company;
using Foretagsplatsen.Api2.Entities.Documents;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyDocumentResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyDocumentResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public CompanyDocumentResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }

        public DocumentFolder Get()
        {
            var url = GetUrl();
            var json = client.Get(url);
            var jsonDocument = JObject.Parse(json);
            return (DocumentFolder)CreateDocument(jsonDocument);
        }

        public Document Get(Document document)
        {
            return Get(document.id);
        }

        public Document Get(string documentId) 
        {
            var url = GetUrl(documentId);
            var json = client.Get(url);
            var jsonDocument = JObject.Parse(json);
            return CreateDocument(jsonDocument);
        }

        public Document Create(Document document)
        {
            var url = GetUrl();
            var json = client.Post(url, JObject.FromObject(document).ToString());
            var jsonDocument = JObject.Parse(json);
            return CreateDocument(jsonDocument);

        }

        public Document Update(Document document)
        {
            var url = GetUrl();
            var json = client.Put(url, JObject.FromObject(document).ToString());
            var jsonDocument = JObject.Parse(json);
            return CreateDocument(jsonDocument);
        }

        public void Delete(Document document)
        {
            Delete(document.id);
        }

        public void Delete(string documentId)
        {
            var url = GetUrl(documentId);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl(string documentId = "")
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/Document/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, documentId);
        }

        private static Document CreateDocument(JToken obj)
        {

            if (obj["type"] == null)
            {
                throw new ApiException("Invalid json. No document type found.", ApiErrorType.Unknown);
            }

            var type = obj["type"].Value<string>();

            try
            {
                switch (type)
                {
                    case DocumentFile.documentType:
                        return JsonConvert.DeserializeObject<DocumentFile>(obj.ToString());
                    case DocumentFolder.documentType:
                        var folder = JsonConvert.DeserializeObject<DocumentFolder>(obj.ToString());
                        var children = (JArray) obj["children"];
                        folder.children = children.Select(CreateDocument).ToList();
                        return folder;
                    default:
                        throw new ApiException("Document type not implemented.", ApiErrorType.Unknown);
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Could not parse document type: {0}", type), ApiErrorType.Unknown, ex.InnerException);
            }
        }

        #endregion
    }
}
