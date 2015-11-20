using System;

namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Defines a period with a start and end date.
    /// </summary>
    public class Period
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Period()
        {
        }

        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}