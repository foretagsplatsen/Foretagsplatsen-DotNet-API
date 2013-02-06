using System;
// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Represents a Fiscal Year in a <seealso cref="CompanyInfo"/>
    /// </summary>
    public class FiscalYear
    {
        public string id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string chartOfAccountsId { get; set; }
        public DateTime lastLedgerDate { get; set; }
        public string currency { get; set; }
    }
}
// ReSharper restore InconsistentNaming