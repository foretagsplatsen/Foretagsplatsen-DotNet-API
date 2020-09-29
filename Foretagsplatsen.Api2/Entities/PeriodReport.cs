using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Represents a period report.
    /// </summary>
    public class PeriodReport
    {
        public string id { get; set; }

        public string title { get; set; }

        public string name { get; set; }

        public string comment { get; set; }

        public string author { get; set; }

        public DateTime created { get; set; }

        public Period period { get; set; }  

        public DateTime? lastUpdated { get; set; }

        public bool isPublished { get; set; }
    }
}