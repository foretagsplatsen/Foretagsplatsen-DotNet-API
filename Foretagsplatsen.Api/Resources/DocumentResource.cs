using System;
using System.IO;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Document archive REST resource:
    /// https://web.foretagsplatsen.se/Api/Company/{businessIdentityCode}/Document/{path}
    /// 
    /// Notes: 
    /// * A path that ends with a forward slash '/' denotes a folder, otherwise it is a file
    /// </summary>
    public class DocumentResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        /// <summary>
        /// Instantiates a new <see cref="DocumentResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="company">Company</param>
        public DocumentResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="DocumentResource"/> object.
        /// </summary>
        /// <param name="client">REST client</param>
        /// <param name="businessIdentityCode">Business identity code for company.</param>

        public DocumentResource(ApiClient client, string businessIdentityCode)
        {
            this.client = client;
            this.businessIdentityCode = businessIdentityCode;
        }


        /// <summary>
        /// Url for the document archive resource.
        /// </summary>
        /// <returns>Url for the resource</returns>
        public string GetUrl(string path)
        {
            const string urlFormat = "{0}/Api/Company/{1}/Document/{2}";
            return string.Format(urlFormat, client.BaseUrl, businessIdentityCode, path);
        }

        /// <summary>
        /// Get the file or folder info for the path.
        /// </summary>
        /// <param name="path">The path to the file or folder</param>
        /// <returns>A <see cref="Document"/> containing the information</returns>
        public Document Get(string path)
        {
            string url = GetUrl(path);

            return client.Get<Document>(url);
        }


        /// <summary>
        /// Download a file from the document archive. Be aware of the path convention that says a file path cannot 
        /// end with a slash.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A byte array with the file content</returns>
        public byte[] DownloadFile(string path)
        {
            if (path.EndsWith("/"))
            {
                throw new ApiException("Invalid path. A file path cannot end with a '/'");
            }

            string url = GetUrl(path);

            var webResponse = client.GetResponse("GET", url, new { download = true });

            using (Stream responseStream = webResponse.GetResponseStream())
            {
                if (responseStream == null)
                {
                    return null;
                }

                var content = new byte[webResponse.ContentLength];
                
                responseStream.Read(content, 0, (int) webResponse.ContentLength);

                var textContent = System.Text.Encoding.Default.GetString(content);

                return Convert.FromBase64String(textContent);
            }
        }

        /// <summary>
        /// Delete a file or folder. If the path is a folder all folder content will be deleted too.
        /// </summary>
        /// <param name="path">The path to the file or folder</param>
        public void Delete(string path)
        {
            string url = GetUrl(path);

            client.Delete(url);
        }


        /// <summary>
        /// Create a folder path. It is possible to supply a path with subfolders that will be created simultaneous. 
        /// Be aware of the path convention that says if a paths ends with a slash it denotes a folder. Hence the path
        /// must end with a slash.
        /// If the path already exists an ApiException with ApiErrorType Exists will be thrown.
        /// </summary>
        /// <param name="path">The path to create.</param>
        public void CreatePath(string path)
        {
            if (!path.EndsWith("/"))
            {
                throw new ApiException("Invalid path. A folder path must end with a '/'");
            }

            string url = GetUrl(path);

            client.Post(url, " ");
        }

        /// <summary>
        /// Update a folder path. It is possible to supply a path with subfolders that will be created simultaneous. 
        /// Be aware of the path convention that says if a paths ends with a slash it denotes a folder. Hence the path
        /// must end with a slash.
        /// </summary>
        /// <param name="path">The path to create.</param>
        public void UpdatePath(string path)
        {
            if (!path.EndsWith("/"))
            {
                throw new ApiException("Invalid path. A folder path must end with a '/'");
            }

            string url = GetUrl(path);

            client.Put(url, " ");
        }


        /// <summary>
        /// Creates a file to the document archive. Be aware of the path convention that says a file path cannot end with
        /// a slash.
        /// If the file already exists an ApiException with ApiErrorType Exists will be thrown.
        /// </summary>
        /// <param name="path">The path to the file to create</param>
        /// <param name="file">The binary data to upload</param>
        public void Create(string path, byte[] file)
        {
            if (path.EndsWith("/"))
            {
                throw new ApiException("Invalid path. A file path cannot end with a '/'");
            }

            string url = GetUrl(path);

            client.Post(url, Convert.ToBase64String(file));
        }

        /// <summary>
        /// Save a file to the document archive. Be aware of the path convention that says a file path cannot end with
        /// a slash.
        /// If the file already exists it will be replaced by the new one.
        /// </summary>
        /// <param name="path">The path to the file to create</param>
        /// <param name="file">The binary data to upload</param>
        public void Update(string path, byte[] file)
        {
            if (path.EndsWith("/"))
            {
                throw new ApiException("Invalid path. A file path cannot end with a '/'");
            }

            string url = GetUrl(path);

            client.Put(url, Convert.ToBase64String(file));
        }

    }
}