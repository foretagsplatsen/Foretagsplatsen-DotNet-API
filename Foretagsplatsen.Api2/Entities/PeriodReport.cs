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

        public string name { get; set; }

        public DateTime timeStamp { get; set; }

        public Period period { get; set; }  

    }
}