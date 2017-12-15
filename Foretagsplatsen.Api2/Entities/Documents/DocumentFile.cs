// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Documents
{
    /// <summary>
    /// Represents a file in the document archive. 
    /// </summary>
    public class DocumentFile : Document
    {
        public const string documentType = "File";

        /// <summary>
        /// Base64 encoded file content.
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// Content type.
        /// </summary>
        public string contentType { get; set; }

        public DocumentFile()
        {
            type = documentType;
        }
    }
}