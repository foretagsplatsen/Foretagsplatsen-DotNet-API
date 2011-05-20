using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    public class CostsForEmployees : IKeyFigure
    {
        #region Implementation of IKeyFigure

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PeriodType PeriodType { get; set; }

        #endregion

        public List<CostsForEmployeesEntry> Entries;
    }
}