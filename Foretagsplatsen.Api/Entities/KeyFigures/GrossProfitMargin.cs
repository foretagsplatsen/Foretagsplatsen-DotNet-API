using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// A list with periods and their gross profit margin key figures
    /// </summary>
    public class GrossProfitMargin : IKeyFigure
    {
        #region Implementation of IKeyFigure

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PeriodType PeriodType { get; set; }

        #endregion

        public List<GrossProfitMarginEntry> Entries { get; set; }
    }
}