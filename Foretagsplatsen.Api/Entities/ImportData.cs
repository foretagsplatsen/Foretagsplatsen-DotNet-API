using System;

namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Encapsulate the data needed for a SIE import
    /// </summary>
    public class ImportData
    {
        /// <summary>
        /// >Content from a SIE-4 file. Use IBM PC 8-bits extended ASCII (Code page 437) encoding.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Currency to use. ISO 4217 (SEK, NOK, EUR)
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// List of object/project identifiers. If a project is not in the list it will be hidden. 
        /// If <c>null</c> all projects are visible.
        /// </summary>
        public string[] DimensionObjects { get; set; }

        /// <summary>
        /// Chart of accounts id to use.
        /// </summary>
        public string ChartOfAccountsId { get; set; }

        /// <summary>
        /// Date for last ledger to show. All ledgers after that date will be hidden. If <c>null</c> all ledgers are visible.
        /// </summary>
        public DateTime? LastLedgerDate { get; set; }

        /// <summary>
        /// Overrides the fiscal year start date from the import data, if not null.
        /// </summary>
        public DateTime? FiscalYearStart { get; set; }

        /// <summary>
        /// Overrides the fiscal year end date from the import data, if not null.
        /// </summary>
        public DateTime? FiscalYearEnd { get; set; }
    }
}