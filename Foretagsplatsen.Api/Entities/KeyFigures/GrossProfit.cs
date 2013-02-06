namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Information about a companys' gross margin key figures
    /// </summary>
    public class GrossProfit : KeyFigureBase<GrossProfitEntry>
    {
        public GrossProfit()
        {
            PeriodType = PeriodType.Month;
        }
    }
}