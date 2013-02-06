using System;
// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Documents
{
    /// <summary>
    /// Represents a document in the document archive. It can be a folder or a file
    /// </summary>
    public class Document
    {
        public string id { get; set; }        
        public string path { get; set; } 
        public DateTime created { get; set; }
        public string type { get; protected set; }
    }
}
// ReSharper restore InconsistentNaming