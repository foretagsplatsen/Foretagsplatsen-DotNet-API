using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    [JsonConverter(typeof(KnownGroupDictionaryJsonConverter))]
    public class KnownGroupDictionary
    {
        #region Known group identifiers

        public const string incomeIdentifier = "Income";
        public const string costsIdentifier = "Costs";
        public const string assetsIdentifier = "Assets";
        public const string liabilitiesIdentifier = "Liabilities";
        public const string accountsReceivablesIdentifier = "AccountsReceivables";
        public const string administrativeExpensesIdentifier = "AdministrativeExpenses";
        public const string allocationsAndProvisionsIdentifier = "AllocationsAndProvisions";
        public const string appropriationsIdentifier = "Appropriations";
        public const string bankOverdraftIdentifier = "BankOverdraft";
        public const string costsOfPremisesAndPropertyIdentifier = "CostsOfPremisesAndProperty";
        public const string costsForEmployeesIdentifier = "CostsForEmployees";
        public const string currentAssetsIdentifier = "CurrentAssets";
        public const string currentInvestmentsAndLiquidFundsIdentifier = "CurrentInvestmentsAndLiquidFunds";
        public const string currentLiabilitiesIdentifier = "CurrentLiabilities";
        public const string deprecationsAccordingToPlanIdentifier = "DeprecationsAccordingToPlan";
        public const string equityCapitalIdentifier = "EquityCapital";
        public const string extraordinaryIncomeAndExpensesIdentifier = "ExtraordinaryIncomeAndExpenses";
        public const string financialAssetsIdentifier = "FinancialAssets";
        public const string financialCostsIdentifier = "FinancialCosts";
        public const string financialIncomeIdentifier = "FinancialIncome";
        public const string fixedAssetsIdentifier = "FixedAssets";
        public const string goodsForResaleIdentifier = "GoodsForResale"; // Handelsvaror
        public const string impairmentsAndWriteBackIdentifier = "ImpairmentsAndWriteBack";
        public const string intangibleFixedAssetsIdentifier = "IntangibleFixedAssets";
        public const string inventoryIdentifier = "Inventory";
        public const string itemsAffectingComparabilityIdentifier = "ItemsAffectingComparability";
        public const string landsAndBuildingsIdentifier = "LandsAndBuildings";
        public const string longTermLiabilitiesIdentifier = "LongTermLiabilities";
        public const string machineryAndEquipmentIdentifier = "MachineryAndEquipment";
        public const string netSalesIdentifier = "NetSales";
        public const string nonCurrentLiabilitiesIdentifier = "NonCurrentLiabilities";
        public const string nonRestrictedEquityCapitalIdentifier = "NonRestrictedEquityCapital";
        public const string operatingExpensesIdentifier = "OperatingExpenses";
        public const string otherCostsForEmployeesIdentifier = "OtherCostsForEmployees";
        public const string otherCurrentReceivablesIdentifier = "OtherCurrentReceivables";
        public const string otherOperatingExpensesIdentifier = "OtherOperatingExpenses";
        public const string otherOperatingIncomeIdentifier = "OtherOperatingIncome";
        public const string profitEntryAccountsIdentifier = "ProfitEntryAccounts";
        public const string purchaseOfGoodsAndEquipmentIdentifier = "PurchaseOfGoodsAndEquipment";
        public const string rawMaterialIdentifier = "RawMaterial"; // Råvaror
        public const string restrictedEquityCapitalIdentifier = "RestrictedEquityCapital";
        public const string salariesSocialBenefitsEtcIdentifier = "SalariesSocialBenefitsEtc";
        public const string sellingExpensesIdentifier = "SellingExpenses";
        public const string taxesIdentifier = "Taxes";
        public const string untaxedReservesIdentifier = "UntaxedReserves";

        #endregion

        #region Known groups

        public IAccountGroup netSales { get { return getKnownGroup(netSalesIdentifier); } set { setKnownGroup(netSalesIdentifier, value); } }
        public IAccountGroup extraordinaryIncomeAndExpenses { get { return getKnownGroup(extraordinaryIncomeAndExpensesIdentifier); } set { setKnownGroup(extraordinaryIncomeAndExpensesIdentifier, value); } }
        public IAccountGroup longTermLiabilities { get { return getKnownGroup(longTermLiabilitiesIdentifier); } set { setKnownGroup(longTermLiabilitiesIdentifier, value); } }
        public IAccountGroup untaxedReserves { get { return getKnownGroup(untaxedReservesIdentifier); } set { setKnownGroup(untaxedReservesIdentifier, value); } }
        public IAccountGroup currentLiabilities { get { return getKnownGroup(currentLiabilitiesIdentifier); } set { setKnownGroup(currentLiabilitiesIdentifier, value); } }
        public IAccountGroup fixedAssets { get { return getKnownGroup(fixedAssetsIdentifier); } set { setKnownGroup(fixedAssetsIdentifier, value); } }
        public IAccountGroup currentAssets { get { return getKnownGroup(currentAssetsIdentifier); } set { setKnownGroup(currentAssetsIdentifier, value); } }
        public IAccountGroup nonRestrictedEquityCapital { get { return getKnownGroup(nonRestrictedEquityCapitalIdentifier); } set { setKnownGroup(nonRestrictedEquityCapitalIdentifier, value); } }
        public IAccountGroup inventory { get { return getKnownGroup(inventoryIdentifier); } set { setKnownGroup(inventoryIdentifier, value); } }
        public IAccountGroup assets { get { return getKnownGroup(assetsIdentifier); } set { setKnownGroup(assetsIdentifier, value); } }
        public IAccountGroup costs { get { return getKnownGroup(costsIdentifier); } set { setKnownGroup(costsIdentifier, value); } }
        public IAccountGroup profitEntryAccounts { get { return getKnownGroup(profitEntryAccountsIdentifier); } set { setKnownGroup(profitEntryAccountsIdentifier, value); } }
        public IAccountGroup restrictedEquityCapital { get { return getKnownGroup(restrictedEquityCapitalIdentifier); } set { setKnownGroup(restrictedEquityCapitalIdentifier, value); } }
        public IAccountGroup equityCapital { get { return getKnownGroup(equityCapitalIdentifier); } set { setKnownGroup(equityCapitalIdentifier, value); } }
        public IAccountGroup purchaseOfGoodsAndEquipment { get { return getKnownGroup(purchaseOfGoodsAndEquipmentIdentifier); } set { setKnownGroup(purchaseOfGoodsAndEquipmentIdentifier, value); } }
        public IAccountGroup income { get { return getKnownGroup(incomeIdentifier); } set { setKnownGroup(incomeIdentifier, value); } }
        public IAccountGroup liabilities { get { return getKnownGroup(liabilitiesIdentifier); } set { setKnownGroup(liabilitiesIdentifier, value); } }
        public IAccountGroup taxes { get { return getKnownGroup(taxesIdentifier); } set { setKnownGroup(taxesIdentifier, value); } }
        public IAccountGroup allocationsAndProvisions { get { return getKnownGroup(allocationsAndProvisionsIdentifier); } set { setKnownGroup(allocationsAndProvisionsIdentifier, value); } }
        public IAccountGroup costsForEmployees { get { return getKnownGroup(costsForEmployeesIdentifier); } set { setKnownGroup(costsForEmployeesIdentifier, value); } }
        public IAccountGroup appropriations { get { return getKnownGroup(appropriationsIdentifier); } set { setKnownGroup(appropriationsIdentifier, value); } }
        public IAccountGroup financialIncome { get { return getKnownGroup(financialIncomeIdentifier); } set { setKnownGroup(financialIncomeIdentifier, value); } }
        public IAccountGroup financialCosts { get { return getKnownGroup(financialCostsIdentifier); } set { setKnownGroup(financialCostsIdentifier, value); } }
        public IAccountGroup impairmentsAndWriteBack { get { return getKnownGroup(impairmentsAndWriteBackIdentifier); } set { setKnownGroup(impairmentsAndWriteBackIdentifier, value); } }
        public IAccountGroup deprecationsAccordingToPlan { get { return getKnownGroup(deprecationsAccordingToPlanIdentifier); } set { setKnownGroup(deprecationsAccordingToPlanIdentifier, value); } }
        public IAccountGroup accountsReceivables { get { return getKnownGroup(accountsReceivablesIdentifier); } set { setKnownGroup(accountsReceivablesIdentifier, value); } }
        public IAccountGroup otherCurrentReceivables { get { return getKnownGroup(otherCurrentReceivablesIdentifier); } set { setKnownGroup(otherCurrentReceivablesIdentifier, value); } }
        public IAccountGroup currentInvestmentsAndLiquidFunds { get { return getKnownGroup(currentInvestmentsAndLiquidFundsIdentifier); } set { setKnownGroup(currentInvestmentsAndLiquidFundsIdentifier, value); } }
        public IAccountGroup intangibleFixedAssets { get { return getKnownGroup(intangibleFixedAssetsIdentifier); } set { setKnownGroup(intangibleFixedAssetsIdentifier, value); } }
        public IAccountGroup landsAndBuildings { get { return getKnownGroup(landsAndBuildingsIdentifier); } set { setKnownGroup(landsAndBuildingsIdentifier, value); } }
        public IAccountGroup machineryAndEquipment { get { return getKnownGroup(machineryAndEquipmentIdentifier); } set { setKnownGroup(machineryAndEquipmentIdentifier, value); } }
        public IAccountGroup financialAssets { get { return getKnownGroup(financialAssetsIdentifier); } set { setKnownGroup(financialAssetsIdentifier, value); } }
        public IAccountGroup bankOverdraft { get { return getKnownGroup(bankOverdraftIdentifier); } set { setKnownGroup(bankOverdraftIdentifier, value); } }
        public IAccountGroup nonCurrentLiabilities { get { return getKnownGroup(nonCurrentLiabilitiesIdentifier); } set { setKnownGroup(nonCurrentLiabilitiesIdentifier, value); } }
        public IAccountGroup otherOperatingIncome { get { return getKnownGroup(otherOperatingIncomeIdentifier); } set { setKnownGroup(otherOperatingIncomeIdentifier, value); } }
        public IAccountGroup costsOfPremisesAndProperty { get { return getKnownGroup(costsOfPremisesAndPropertyIdentifier); } set { setKnownGroup(costsOfPremisesAndPropertyIdentifier, value); } }
        public IAccountGroup sellingExpenses { get { return getKnownGroup(sellingExpensesIdentifier); } set { setKnownGroup(sellingExpensesIdentifier, value); } }
        public IAccountGroup administrativeExpenses { get { return getKnownGroup(administrativeExpensesIdentifier); } set { setKnownGroup(administrativeExpensesIdentifier, value); } }
        public IAccountGroup otherOperatingExpenses { get { return getKnownGroup(otherOperatingExpensesIdentifier); } set { setKnownGroup(otherOperatingExpensesIdentifier, value); } }
        public IAccountGroup operatingExpenses { get { return getKnownGroup(operatingExpensesIdentifier); } set { setKnownGroup(operatingExpensesIdentifier, value); } }
        public IAccountGroup itemsAffectingComparability { get { return getKnownGroup(itemsAffectingComparabilityIdentifier); } set { setKnownGroup(itemsAffectingComparabilityIdentifier, value); } }
        public IAccountGroup rawMaterial { get { return getKnownGroup(rawMaterialIdentifier); } set { setKnownGroup(rawMaterialIdentifier, value); } }
        public IAccountGroup goodsForResale { get { return getKnownGroup(goodsForResaleIdentifier); } set { setKnownGroup(goodsForResaleIdentifier, value); } }
        public IAccountGroup otherCostsForEmployees { get { return getKnownGroup(otherCostsForEmployeesIdentifier); } set { setKnownGroup(otherCostsForEmployeesIdentifier, value); } }
        public IAccountGroup salariesSocialBenefitsEtc { get { return getKnownGroup(salariesSocialBenefitsEtcIdentifier); } set { setKnownGroup(salariesSocialBenefitsEtcIdentifier, value); } }

        #endregion

        private readonly Dictionary<string, IAccountGroup> dictionary = new Dictionary<string, IAccountGroup>();

        [JsonIgnore]
        public ChartOfAccounts chartOfAccounts { get; private set; }

        public KnownGroupDictionary(ChartOfAccounts chartOfAccounts)
        {
            this.chartOfAccounts = chartOfAccounts;

            // Mandatory groups

            #region Mandatory groups

            // Basic
            income = new KnownGroup();
            costs = new KnownGroup();
            assets = new KnownGroup();
            liabilities = new KnownGroup();

            // Income children. These groups must be children to the Income group
            financialIncome = new KnownGroup();

            // Costs children. These groups must be children to the Costs group
            financialCosts = new KnownGroup();
            deprecationsAccordingToPlan = new KnownGroup();
            extraordinaryIncomeAndExpenses = new KnownGroup();
            appropriations = new KnownGroup();
            profitEntryAccounts = new KnownGroup();
            taxes = new KnownGroup();

            // Assets children. These groups must be children to the Assets group
            currentAssets = new KnownGroup();
            fixedAssets = new KnownGroup();
            financialAssets = new KnownGroup();
            inventory = new KnownGroup();

            // Liabilities children. These groups must be children to the Liabilities group
            currentLiabilities = new KnownGroup();
            longTermLiabilities = new KnownGroup();
            equityCapital = new KnownGroup();

            #endregion

            #region Optional groups

            // Income children. These groups must be children to the Income group
            netSales = new KnownGroup(); // Income  
            otherOperatingIncome = new KnownGroup();

            // Costs children. These groups must be children to the Costs group
            purchaseOfGoodsAndEquipment = new KnownGroup();
            costsForEmployees = new KnownGroup();
            salariesSocialBenefitsEtc = new KnownGroup();
            otherCostsForEmployees = new KnownGroup();
            impairmentsAndWriteBack = new KnownGroup();
            costsOfPremisesAndProperty = new KnownGroup();
            sellingExpenses = new KnownGroup();
            administrativeExpenses = new KnownGroup();
            otherOperatingExpenses = new KnownGroup();
            operatingExpenses = new KnownGroup();
            itemsAffectingComparability = new KnownGroup();
            goodsForResale = new KnownGroup();
            rawMaterial = new KnownGroup();

            // Assets children. These groups must be children to the Assets group
            accountsReceivables = new KnownGroup();
            otherCurrentReceivables = new KnownGroup();
            currentInvestmentsAndLiquidFunds = new KnownGroup();
            intangibleFixedAssets = new KnownGroup();
            landsAndBuildings = new KnownGroup();
            machineryAndEquipment = new KnownGroup();

            // Liabilities children. These groups must be children to the Liabilities group
            untaxedReserves = new KnownGroup();
            nonRestrictedEquityCapital = new KnownGroup();
            restrictedEquityCapital = new KnownGroup();
            allocationsAndProvisions = new KnownGroup();
            bankOverdraft = new KnownGroup();
            nonCurrentLiabilities = new KnownGroup();

            #endregion
        }

        public void setKnownGroup(string key, IAccountGroup value)
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

        public IAccountGroup getKnownGroup(string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return null;
        }

        public IEnumerable<KeyValuePair<string, IAccountGroup>> getAllKnowGroupsKeyValuePair()
        {
            return new List<KeyValuePair<string, IAccountGroup>>(dictionary);
        }
    }
}