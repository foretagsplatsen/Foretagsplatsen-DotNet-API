// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    /// <summary>
    /// Holds basic information of a key figure.
    /// </summary>
    public class KeyFigure
    {
        public string id { get; set; }
        public string name { get; set; }

        /// <summary>
        /// Can be one of following:
        /// * "Percent"
        /// * "Amount"
        /// * "Count"
        /// * "Ratio"
        /// </summary>
        public string valueType { get; set; }
        public string description { get; set; }
        public string comment { get; set; }
        public string basId { get; set; }
    }
}