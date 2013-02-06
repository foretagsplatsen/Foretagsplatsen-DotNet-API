// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    /// <summary>
    /// Result from Api-client for key figure data
    /// </summary>
    public class KeyFigureData
    {
        public string keyFigureInfoId { get; set; }
        public Period period { get; set; }
        public decimal value { get; set; }
    }
}
// ReSharper restore InconsistentNaming