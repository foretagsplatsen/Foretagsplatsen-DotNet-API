using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Represents a turnover entry point
    /// that has a turnover key figure for a period
    /// </summary>
    public class TurnoverEntry : IKeyFigureEntry
    {
        #region Implementation of IKeyFigureEntry

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Value { get; set; }

        #endregion
    }
}