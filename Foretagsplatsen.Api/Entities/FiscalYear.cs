using System;

namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Represents a Fiscal Year in a <seealso cref="CompanyInfo"/>
    /// </summary>
    public class FiscalYear
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ChartOfAccountsType ChartOfAccountsType { get; set; }
        public DateTime LastLedgerDate { get; set; }
        public string Currency { get; set; }
    }
}