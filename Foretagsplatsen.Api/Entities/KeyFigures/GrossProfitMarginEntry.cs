namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Gross profit margin for a specific period
    /// </summary>
    public class GrossProfitMarginEntry : KeyFigureEntryBase
    {
        public float NetSale { get; set; }
        public float GoodsForResale { get; set; }
    }
}