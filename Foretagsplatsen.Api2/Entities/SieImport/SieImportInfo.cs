// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.SieImport
{
    /// <summary>
    /// Holds warning/errors from a SIE-import.
    /// </summary>
    public class SieImportInfo
    {
        public string lineNo;
        public string linePos;
        public string label;
        public string line;
        public string explanation;
    }
}