using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Documents
{
    /// <summary>
    /// Represents a folder in the document archive. 
    /// </summary>
    public class DocumentFolder : Document
    {
        public const string documentType = "Folder";

        /// <summary>
        /// The content of the folder.
        /// </summary>
        public List<Document> children { get; set; }

        public DocumentFolder()
        {
            type = documentType;
            children = new List<Document>();
        }
    }
}