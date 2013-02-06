namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Represents a turnover entry point
    /// that has a turnover key figure for a period
    /// </summary>
    public class TurnoverEntry : KeyFigureEntryBase
    {
        public float Income { get; set; }
    }
}