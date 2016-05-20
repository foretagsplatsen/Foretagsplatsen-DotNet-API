// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    /// <summary>
    /// Holds information about data used for key figure calculations. Such as the number of eployees.
    /// </summary>
    public class KeyFigureData
    {
        /// <summary>
        /// Can be one of following:
        /// <ul>
        ///     <li> "NumberOfEmployees" - Average number of employees during the period</li>
        ///     <li> "TaxRate" - Tax rate for corporate income tax</li>
        ///     <li> "BankOverdraftLimit" - Maximum bank overdraft allowed by the bank</li>
        ///     <li> "CreditSalesVATIncluded" - Credit sales VAT included</li>
        ///     <li> "SeparableCosts" - Expense that can be directly assigned to a specific activity or transaction</li>
        ///     <li> "InvestmentsInPropertyPlantAndEquipmentForTheYear" - Annual investments in utilities</li>
        ///     <li> "CostsForResearchAndDevelopment" - Annual costs for research and development</li>
        ///     <li> "InterestBearingLiabilities" - Debts that the company pays interest on</li>
        /// </ul>
        /// </summary>
        public string keyFigureInfoId { get; set; }
        public Period period { get; set; }
        public decimal? value { get; set; }
        /// <summary>
        /// Optinal dimension id for key figure data tagged with dimensions.
        /// 
        /// The dimensionId of a dimension is the concatenation of numbers of the dimension parents with its own number, separated by underscores.
        /// 
        /// For example in the following key figure, the dimension id "2_12" corresponds to the dimension #12 in the dimension #2.
        /// </summary>
        public string dimensionId { get; set; }
    }
}