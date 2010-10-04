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
        /// <see cref="ChartOfAccountsType">Chart of accounts type</see> to use.
        /// </summary>
        public ChartOfAccountsType ChartOfAccountsType { get; set; }

        /// <summary>
        /// Date for last ledger to show. All ledgers after that date will be hidden. If <c>null</c> all ledgers are visible.
        /// </summary>
        public DateTime? LastLedgerDate { get; set; }
    }
}