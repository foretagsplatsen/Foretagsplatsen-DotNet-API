using System;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// A period of time with XXX precision. The start and end date is included in the period so to cover for exampel
    /// a month, januari 2000, the start date will be 2000-01-01 and end date 2000-01-31
    /// </summary>
    public class Period
    {
        /// <summary>
        /// Start date of the period with XXX precision. The start date is included in the interval
        /// </summary>
        public DateTime start { get; set; }

        /// <summary>
        /// End date of the period with XXX precision. The end date is included in the interval
        /// </summary>
        public DateTime end { get; set; }
    }
}