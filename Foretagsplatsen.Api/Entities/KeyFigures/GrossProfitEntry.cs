namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Gross margin for a specific period
    /// </summary>
    public class GrossProfitEntry : KeyFigureEntryBase
    {
        public float? NetSale { get; set; }
        public float? Cost { get; set; }
    }
}