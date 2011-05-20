using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Profit key figure for a specific period
    /// </summary>
    public class ProfitEntry : IKeyFigureEntry
    {
        #region Implementation of IKeyFigureEntry

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Value { get; set; }
        
        #endregion

        public float Income { get; set; }
        public float Cost { get; set; }
        public float FinancialEntry { get; set; }
    }
}