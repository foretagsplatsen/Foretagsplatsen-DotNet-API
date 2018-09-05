using System.Collections.Generic;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    [JsonConverter(typeof (KnownGroupDictionaryJsonConverter))]
    public class KnownGroupDictionary
    {
        #region Known group identifiers
        public const string IncomeIdentifier = "Income";
        public const string CostsIdentifier = "Costs";
        public const string AssetsIdentifier = "Assets";
        public const string LiabilitiesIdentifier = "Liabilities";
        public const string AccountsReceivablesIdentifier = "AccountsReceivables";
        public const string AdministrativeExpensesIdentifier = "AdministrativeExpenses";
        public const string AllocationsAndProvisionsIdentifier = "AllocationsAndProvisions";
        public const string AppropriationsIdentifier = "Appropriations";
        public const string BankOverdraftIdentifier = "BankOverdraft";
        public const string CostsOfPremisesAndPropertyIdentifier = "CostsOfPremisesAndProperty";
        public const string CostsForEmployeesIdentifier = "CostsForEmployees";
        public const string CurrentAssetsIdentifier = "CurrentAssets";
        public const string CurrentInvestmentsAndLiquidFundsIdentifier = "CurrentInvestmentsAndLiquidFunds";
        public const string CurrentLiabilitiesIdentifier = "CurrentLiabilities";
        public const string DeprecationsAccordingToPlanIdentifier = "DeprecationsAccordingToPlan";
        public const string EquityCapitalIdentifier = "EquityCapital";
        public const string ExtraordinaryIncomeAndExpensesIdentifier = "ExtraordinaryIncomeAndExpenses";
        public const string FinancialAssetsIdentifier = "FinancialAssets";
        public const string FinancialCostsIdentifier = "FinancialCosts";
        public const string FinancialIncomeIdentifier = "FinancialIncome";
        public const string FixedAssetsIdentifier = "FixedAssets";
        public const string GoodsForResaleIdentifier = "GoodsForResale"; // Handelsvaror
        public const string ImpairmentsAndWriteBackIdentifier = "ImpairmentsAndWriteBack";
        public const string IntangibleFixedAssetsIdentifier = "IntangibleFixedAssets";
        public const string InventoryIdentifier = "Inventory";
        public const string ItemsAffectingComparabilityIdentifier = "ItemsAffectingComparability";
        public const string LandsAndBuildingsIdentifier = "LandsAndBuildings";
        public const string LongTermLiabilitiesIdentifier = "LongTermLiabilities";
        public const string MachineryAndEquipmentIdentifier = "MachineryAndEquipment";
        public const string NetSalesIdentifier = "NetSales";
        public const string NonCurrentLiabilitiesIdentifier = "NonCurrentLiabilities";
        public const string NonRestrictedEquityCapitalIdentifier = "NonRestrictedEquityCapital";
        public const string OperatingExpensesIdentifier = "OperatingExpenses";
        public const string OtherCostsForEmployeesIdentifier = "OtherCostsForEmployees";
        public const string OtherCurrentReceivablesIdentifier = "OtherCurrentReceivables";
        public const string OtherOperatingExpensesIdentifier = "OtherOperatingExpenses";
        public const string OtherOperatingIncomeIdentifier = "OtherOperatingIncome";
        public const string ProfitEntryAccountsIdentifier = "ProfitEntryAccounts";
        public const string PurchaseOfGoodsAndEquipmentIdentifier = "PurchaseOfGoodsAndEquipment";
        public const string RawMaterialIdentifier = "RawMaterial"; // Råvaror
        public const string RestrictedEquityCapitalIdentifier = "RestrictedEquityCapital";
        public const string SalariesSocialBenefitsEtcIdentifier = "SalariesSocialBenefitsEtc";
        public const string SellingExpensesIdentifier = "SellingExpenses";
        public const string TaxesIdentifier = "Taxes";
        public const string UntaxedReservesIdentifier = "UntaxedReserves";
        #endregion

        #region Known groups
        public IAccountGroup NetSales { get { return GetKnownGroup(NetSalesIdentifier); } set { SetKnownGroup(NetSalesIdentifier, value); } }
        public IAccountGroup ExtraordinaryIncomeAndExpenses { get { return GetKnownGroup(ExtraordinaryIncomeAndExpensesIdentifier); } set { SetKnownGroup(ExtraordinaryIncomeAndExpensesIdentifier, value); } }
        public IAccountGroup LongTermLiabilities { get { return GetKnownGroup(LongTermLiabilitiesIdentifier); } set { SetKnownGroup(LongTermLiabilitiesIdentifier, value); } }
        public IAccountGroup UntaxedReserves { get { return GetKnownGroup(UntaxedReservesIdentifier); } set { SetKnownGroup(UntaxedReservesIdentifier, value); } }
        public IAccountGroup CurrentLiabilities { get { return GetKnownGroup(CurrentLiabilitiesIdentifier); } set { SetKnownGroup(CurrentLiabilitiesIdentifier, value); } }
        public IAccountGroup FixedAssets { get { return GetKnownGroup(FixedAssetsIdentifier); } set { SetKnownGroup(FixedAssetsIdentifier, value); } }
        public IAccountGroup CurrentAssets { get { return GetKnownGroup(CurrentAssetsIdentifier); } set { SetKnownGroup(CurrentAssetsIdentifier, value); } }
        public IAccountGroup NonRestrictedEquityCapital { get { return GetKnownGroup(NonRestrictedEquityCapitalIdentifier); } set { SetKnownGroup(NonRestrictedEquityCapitalIdentifier, value); } }
        public IAccountGroup Inventory { get { return GetKnownGroup(InventoryIdentifier); } set { SetKnownGroup(InventoryIdentifier, value); } }
        public IAccountGroup Assets { get { return GetKnownGroup(AssetsIdentifier); } set { SetKnownGroup(AssetsIdentifier, value); } }
        public IAccountGroup Costs { get { return GetKnownGroup(CostsIdentifier); } set { SetKnownGroup(CostsIdentifier, value); } }
        public IAccountGroup ProfitEntryAccounts { get { return GetKnownGroup(ProfitEntryAccountsIdentifier); } set { SetKnownGroup(ProfitEntryAccountsIdentifier, value); } }
        public IAccountGroup RestrictedEquityCapital { get { return GetKnownGroup(RestrictedEquityCapitalIdentifier); } set { SetKnownGroup(RestrictedEquityCapitalIdentifier, value); } }
        public IAccountGroup EquityCapital { get { return GetKnownGroup(EquityCapitalIdentifier); } set { SetKnownGroup(EquityCapitalIdentifier, value); } }
        public IAccountGroup PurchaseOfGoodsAndEquipment { get { return GetKnownGroup(PurchaseOfGoodsAndEquipmentIdentifier); } set { SetKnownGroup(PurchaseOfGoodsAndEquipmentIdentifier, value); } }
        public IAccountGroup Income { get { return GetKnownGroup(IncomeIdentifier); } set { SetKnownGroup(IncomeIdentifier, value); } }
        public IAccountGroup Liabilities { get { return GetKnownGroup(LiabilitiesIdentifier); } set { SetKnownGroup(LiabilitiesIdentifier, value); } }
        public IAccountGroup Taxes { get { return GetKnownGroup(TaxesIdentifier); } set { SetKnownGroup(TaxesIdentifier, value); } }
        public IAccountGroup AllocationsAndProvisions { get { return GetKnownGroup(AllocationsAndProvisionsIdentifier); } set { SetKnownGroup(AllocationsAndProvisionsIdentifier, value); } }
        public IAccountGroup CostsForEmployees { get { return GetKnownGroup(CostsForEmployeesIdentifier); } set { SetKnownGroup(CostsForEmployeesIdentifier, value); } }
        public IAccountGroup Appropriations { get { return GetKnownGroup(AppropriationsIdentifier); } set { SetKnownGroup(AppropriationsIdentifier, value); } }
        public IAccountGroup FinancialIncome { get { return GetKnownGroup(FinancialIncomeIdentifier); } set { SetKnownGroup(FinancialIncomeIdentifier, value); } }
        public IAccountGroup FinancialCosts { get { return GetKnownGroup(FinancialCostsIdentifier); } set { SetKnownGroup(FinancialCostsIdentifier, value); } }
        public IAccountGroup ImpairmentsAndWriteBack { get { return GetKnownGroup(ImpairmentsAndWriteBackIdentifier); } set { SetKnownGroup(ImpairmentsAndWriteBackIdentifier, value); } }
        public IAccountGroup DeprecationsAccordingToPlan { get { return GetKnownGroup(DeprecationsAccordingToPlanIdentifier); } set { SetKnownGroup(DeprecationsAccordingToPlanIdentifier, value); } }
        public IAccountGroup AccountsReceivables { get { return GetKnownGroup(AccountsReceivablesIdentifier); } set { SetKnownGroup(AccountsReceivablesIdentifier, value); } }
        public IAccountGroup OtherCurrentReceivables { get { return GetKnownGroup(OtherCurrentReceivablesIdentifier); } set { SetKnownGroup(OtherCurrentReceivablesIdentifier, value); } }
        public IAccountGroup CurrentInvestmentsAndLiquidFunds { get { return GetKnownGroup(CurrentInvestmentsAndLiquidFundsIdentifier); } set { SetKnownGroup(CurrentInvestmentsAndLiquidFundsIdentifier, value); } }
        public IAccountGroup IntangibleFixedAssets { get { return GetKnownGroup(IntangibleFixedAssetsIdentifier); } set { SetKnownGroup(IntangibleFixedAssetsIdentifier, value); } }
        public IAccountGroup LandsAndBuildings { get { return GetKnownGroup(LandsAndBuildingsIdentifier); } set { SetKnownGroup(LandsAndBuildingsIdentifier, value); } }
        public IAccountGroup MachineryAndEquipment { get { return GetKnownGroup(MachineryAndEquipmentIdentifier); } set { SetKnownGroup(MachineryAndEquipmentIdentifier, value); } }
        public IAccountGroup FinancialAssets { get { return GetKnownGroup(FinancialAssetsIdentifier); } set { SetKnownGroup(FinancialAssetsIdentifier, value); } }
        public IAccountGroup BankOverdraft { get { return GetKnownGroup(BankOverdraftIdentifier); } set { SetKnownGroup(BankOverdraftIdentifier, value); } }
        public IAccountGroup NonCurrentLiabilities { get { return GetKnownGroup(NonCurrentLiabilitiesIdentifier); } set { SetKnownGroup(NonCurrentLiabilitiesIdentifier, value); } }
        public IAccountGroup OtherOperatingIncome { get { return GetKnownGroup(OtherOperatingIncomeIdentifier); } set { SetKnownGroup(OtherOperatingIncomeIdentifier, value); } }
        public IAccountGroup CostsOfPremisesAndProperty { get { return GetKnownGroup(CostsOfPremisesAndPropertyIdentifier); } set { SetKnownGroup(CostsOfPremisesAndPropertyIdentifier, value); } }
        public IAccountGroup SellingExpenses { get { return GetKnownGroup(SellingExpensesIdentifier); } set { SetKnownGroup(SellingExpensesIdentifier, value); } }
        public IAccountGroup AdministrativeExpenses { get { return GetKnownGroup(AdministrativeExpensesIdentifier); } set { SetKnownGroup(AdministrativeExpensesIdentifier, value); } }
        public IAccountGroup OtherOperatingExpenses { get { return GetKnownGroup(OtherOperatingExpensesIdentifier); } set { SetKnownGroup(OtherOperatingExpensesIdentifier, value); } }
        public IAccountGroup OperatingExpenses { get { return GetKnownGroup(OperatingExpensesIdentifier); } set { SetKnownGroup(OperatingExpensesIdentifier, value); } }
        public IAccountGroup ItemsAffectingComparability { get { return GetKnownGroup(ItemsAffectingComparabilityIdentifier); } set { SetKnownGroup(ItemsAffectingComparabilityIdentifier, value); } }
        public IAccountGroup RawMaterial { get { return GetKnownGroup(RawMaterialIdentifier); } set { SetKnownGroup(RawMaterialIdentifier, value); } }
        public IAccountGroup GoodsForResale { get { return GetKnownGroup(GoodsForResaleIdentifier); } set { SetKnownGroup(GoodsForResaleIdentifier, value); } }
        public IAccountGroup OtherCostsForEmployees { get { return GetKnownGroup(OtherCostsForEmployeesIdentifier); } set { SetKnownGroup(OtherCostsForEmployeesIdentifier, value); } }
        public IAccountGroup SalariesSocialBenefitsEtc { get { return GetKnownGroup(SalariesSocialBenefitsEtcIdentifier); } set { SetKnownGroup(SalariesSocialBenefitsEtcIdentifier, value); } }

        #endregion

        public ChartOfAccounts ChartOfAccounts { get; set; }

        private readonly Dictionary<string, IAccountGroup> dictionary = new Dictionary<string, IAccountGroup>();

        public KnownGroupDictionary(ChartOfAccounts chartOfAccounts)
        {
            
            ChartOfAccounts = chartOfAccounts;

            // Mandatory groups
            #region Mandatory groups

            // Basic
            Income = new KnownGroup();
            Costs = new KnownGroup();
            Assets = new KnownGroup();
            Liabilities = new KnownGroup();
            
            // Income children. These groups must be children to the Income group
            FinancialIncome = new KnownGroup();
            
            // Costs children. These groups must be children to the Costs group
            FinancialCosts = new KnownGroup();
            DeprecationsAccordingToPlan = new KnownGroup();
            ExtraordinaryIncomeAndExpenses = new KnownGroup();
            Appropriations = new KnownGroup();
            ProfitEntryAccounts = new KnownGroup();
            Taxes = new KnownGroup();

            // Assets children. These groups must be children to the Assets group
            CurrentAssets = new KnownGroup();
            FixedAssets = new KnownGroup();
            FinancialAssets = new KnownGroup();
            Inventory = new KnownGroup();

            // Liabilities children. These groups must be children to the Liabilities group
            CurrentLiabilities = new KnownGroup();
            LongTermLiabilities = new KnownGroup();
            EquityCapital = new KnownGroup();

            #endregion

            #region Optional groups

            // Income children. These groups must be children to the Income group
            NetSales = new KnownGroup(); // Income  
            OtherOperatingIncome = new KnownGroup();

            // Costs children. These groups must be children to the Costs group
            PurchaseOfGoodsAndEquipment = new KnownGroup();
            CostsForEmployees = new KnownGroup();
            SalariesSocialBenefitsEtc = new KnownGroup();
            OtherCostsForEmployees = new KnownGroup();
            ImpairmentsAndWriteBack = new KnownGroup();
            CostsOfPremisesAndProperty = new KnownGroup();
            SellingExpenses = new KnownGroup();
            AdministrativeExpenses = new KnownGroup();
            OtherOperatingExpenses = new KnownGroup();
            OperatingExpenses = new KnownGroup();
            ItemsAffectingComparability = new KnownGroup();
            GoodsForResale = new KnownGroup();
            RawMaterial = new KnownGroup();

            // Assets children. These groups must be children to the Assets group
            AccountsReceivables = new KnownGroup();
            OtherCurrentReceivables = new KnownGroup();
            CurrentInvestmentsAndLiquidFunds = new KnownGroup();
            IntangibleFixedAssets = new KnownGroup();
            LandsAndBuildings = new KnownGroup();
            MachineryAndEquipment = new KnownGroup();

            // Liabilities children. These groups must be children to the Liabilities group
            UntaxedReserves = new KnownGroup();
            NonRestrictedEquityCapital = new KnownGroup();
            RestrictedEquityCapital = new KnownGroup();
            AllocationsAndProvisions = new KnownGroup();
            BankOverdraft = new KnownGroup();
            NonCurrentLiabilities = new KnownGroup();

            #endregion
        }

        public void SetKnownGroup(string key, IAccountGroup value)
        {
            if (value != null)
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Remove(key);
            }
        }

        public IAccountGroup GetKnownGroup(string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return null;
        }

        public IEnumerable<KeyValuePair<string, IAccountGroup>> GetAllKnowGroupsKeyValuePair()
        {
            return new List<KeyValuePair<string, IAccountGroup>>(dictionary);
        }
    }
}