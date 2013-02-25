using System;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Represents a period of time with second precision. The start and end date is included in the period so to cover for exampel
    /// a month, januari 2000, the start date will be 2000-01-01T00:00 and end date 2000-01-31T23:59:59
    /// </summary>
    public class Period
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}