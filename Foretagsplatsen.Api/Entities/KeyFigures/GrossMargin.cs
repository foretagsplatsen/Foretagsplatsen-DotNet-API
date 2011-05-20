using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Information about a companys' gross margin key figures
    /// </summary>
    public class GrossMargin : IKeyFigure
    {
        public GrossMargin()
        {
            PeriodType = PeriodType.Month;
        }

        #region Implementation of IKeyFigure

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PeriodType PeriodType { get; set; }

        #endregion
        
        public List<GrossMarginEntry> Entries { get; set; }
    }
}