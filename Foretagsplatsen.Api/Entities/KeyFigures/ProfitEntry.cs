namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Profit key figure for a specific period
    /// </summary>
    public class ProfitEntry : KeyFigureEntryBase
    {
        public float? Income { get; set; }
        public float? Cost { get; set; }
        public float? FinancialEntry { get; set; }
    }
}