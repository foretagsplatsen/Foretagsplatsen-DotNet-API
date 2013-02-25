using System;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Documents
{
    /// <summary>
    /// Represents a document in the document archive. It can be a folder or a file
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Unique identifier for the document.
        /// </summary>
        public string id { get; set; }
        public string path { get; set; }
        public DateTime created { get; set; }

        /// <summary>
        /// Document type, can be "File" or "Folder".
        /// </summary>
        public string type { get; protected set; }
    }
}