// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Documents
{
    /// <summary>
    /// Represents a file in the document archive. 
    /// </summary>
    public class DocumentFile : Document
    {
        public const string documentType = "File";
        public string data { get; set; } // Base64 encoded contents
        public DocumentFile()
        {
            type = documentType;
        }
    }
}
// ReSharper restore InconsistentNaming