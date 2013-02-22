using System;
using Foretagsplatsen.Api2.Entities.Accounts;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Represents a Fiscal Year in a <see cref="CompanyInfo"/>
    /// </summary>
    public class FiscalYear
    {
        /// <summary>
        /// Uniqe identifier of the fiscal year
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Start date of the fiscal year
        /// </summary>
        public DateTime start { get; set; }

        /// <summary>
        /// End date of the fiscal year
        /// </summary>
        public DateTime end { get; set; }

        /// <summary>
        /// Id of the chart of account used in this  fiscal year. <seealso cref="ChartOfAccounts"/>
        /// </summary>
        public string chartOfAccountsId { get; set; }

        /// <summary>
        /// Date of the latest ledger in the fiscal year.
        /// </summary>
        public DateTime lastLedgerDate { get; set; }

        /// <summary>
        /// Currency in ISO-XXX, example SEK, NOK, USD
        /// </summary>
        public string currency { get; set; }
    }
}