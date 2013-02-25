using System;
using Foretagsplatsen.Api2.Entities.Accounts;
using Foretagsplatsen.Api2.Entities.Company;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Represents a Fiscal Year in a <see cref="CompanyInfo"/>.
    /// </summary>
    public class FiscalYear
    {
        /// <summary>
        /// Uniqe identifier of the fiscal year. Is created by the server.
        /// </summary>
        public string id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        /// <summary>
        /// Id of the chart of account used in this fiscal year. See also <see cref="ChartOfAccounts"/>.
        /// </summary>
        public string chartOfAccountsId { get; set; }
        public DateTime lastLedgerDate { get; set; }

        /// <summary>
        /// Currency in ISO 4217, example SEK, NOK, USD
        /// </summary>
        public string currency { get; set; }
    }
}