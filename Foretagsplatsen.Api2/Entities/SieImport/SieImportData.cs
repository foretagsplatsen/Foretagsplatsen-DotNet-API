using System;
using Foretagsplatsen.Api2.Entities.Accounts;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.SieImport
{
    /// <summary>
    /// Encapsulate the data needed for a SIE import
    /// </summary>
    public class SieImportData
    {
        /// <summary>
        /// Required field.
        /// Content from a SIE-4 file. Use IBM PC 8-bits extended ASCII (Code page 437) encoding.
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// Required field.
        /// Currency to use. ISO 4217 (SEK, NOK, EUR)
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// List of object/project identifiers. If a project is not in the list it will be hidden. 
        /// If null all projects are visible.
        /// If set to an empty list, none of the projects will be visible.
        /// NB! Both having a list of dimensionObjects(even empty) and setting excludeEmptyDimensions to true is not supported and will result in an exception.
        /// </summary>
        public string[] dimensionObjects { get; set; }

        /// <summary>
        /// If set to true, dimensions without transactions will be filtered out. 
        /// NB! Both having a list of dimensionObjects((even empty) and setting excludeEmptyDimensions to true is not supported and will result in an exception.
        /// </summary>
        public bool excludeEmptyDimensions { get; set; }

        /// <summary>
        /// Required field.
        /// Chart of accounts id to use. <see cref="ChartOfAccounts"/>
        /// </summary>
        public string chartOfAccountsId { get; set; }

        /// <summary>
        /// Date for last ledger to show. All ledgers after that date will be hidden. If null all ledgers are visible.
        /// </summary>
        public DateTime? lastLedgerDate { get; set; }

        /// <summary>
        /// Overrides the fiscal year start date from the import data, if not null.
        /// </summary>
        public DateTime? fiscalYearStart { get; set; }

        /// <summary>
        /// Overrides the fiscal year end date from the import data, if not null.
        /// </summary>
        public DateTime? fiscalYearEnd { get; set; }
    }
}