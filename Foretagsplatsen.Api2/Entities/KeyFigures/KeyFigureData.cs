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
        /// * "NumberOfEmployees" - Average number of employees during the period
        /// * "TaxRate" - Tax rate for corporate income tax
        /// * "BankOverdraftLimit" - Maximum bank overdraft allowed by the bank
        /// * "CreditSalesVATIncluded" - Credit sales VAT included
        /// * "SeparableCosts" - Expense that can be directly assigned to a specific activity or transaction
        /// * "InvestmentsInPropertyPlantAndEquipmentForTheYear" - Annual investments in utilities
        /// * "CostsForResearchAndDevelopment" - Annual costs for research and development
        /// * "InterestBearingLiabilities" - Debts that the company pays interest on
        /// </summary>
        public string keyFigureInfoId { get; set; }
        public Period period { get; set; }
        public decimal value { get; set; }
    }
}