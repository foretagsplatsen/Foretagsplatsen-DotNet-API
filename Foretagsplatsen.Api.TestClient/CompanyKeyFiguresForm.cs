using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Entities.KeyFigures;
using Foretagsplatsen.Api.Exceptions;

namespace Foretagsplatsen.Api.TestClient
{
    public partial class CompanyKeyFiguresForm : Form
    {
        private CompanyInfo companyInfo;

        private const string StartDateKey = "startdate";
        private const string EndDateKey = "enddate";

        public CompanyKeyFiguresForm()
        {
            InitializeComponent();
        }
        
        public void SetCurrentBusinessIdentityCode(CompanyInfo company)
        {
            companyInfo = company;
            tbBusinessIdentityCode.Text = company.BusinessIdentityCode;

            // Init everything in the form for the company
            // Find years for the company
            List<FiscalYear> years = CurrentApiClient.Instance.GetFiscalYearResource(company).List();

            // And the start and end date for over all years
            var startDate = years.Min(y => y.Start);
            var endDate = years.Min(y => y.End);

            tbCompantStartDate.Text = startDate.ToShortDateString();
            tbCompantEndDate.Text = endDate.ToShortDateString();

            // Init date selectors
            mcStartDate.MinDate = startDate;
            mcStartDate.MaxDate = endDate;
            mcStartDate.SetDate(endDate);

            mcEndDate.MinDate = startDate;
            mcEndDate.MaxDate = endDate;
            mcEndDate.SetDate(endDate);
        }
        
        private void btnTurnover_Click(object sender, System.EventArgs e)
        {
            try
            {
                tbKeyFigureResult.Text = string.Empty;

                // Parse dates to use from argument string
                DateTime endDate;
                DateTime startDate;
                GetStartAndEndDate(out startDate, out endDate);

                Turnover turnover = CurrentApiClient.Instance.GetKeyFigureResource(companyInfo).GetTurnover(startDate, endDate);
                
                tbKeyFigureResult.Text = GetTurnoverReport(turnover);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
        
        private void btnProfit_Click(object sender, System.EventArgs e)
        {
            try
            {
                tbKeyFigureResult.Text = string.Empty;

                // Parse dates to use from argument string
                DateTime endDate;
                DateTime startDate;
                GetStartAndEndDate(out startDate, out endDate);

                Profit profit = CurrentApiClient.Instance.GetKeyFigureResource(companyInfo).GetProfit(startDate, endDate);
                
                tbKeyFigureResult.Text = GetProfitReport(profit);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
        
        private void btnGrossProfitMargin_Click(object sender, System.EventArgs e)
        {
            try
            {
                tbKeyFigureResult.Text = string.Empty;

                // Parse dates to use from argument string
                DateTime endDate;
                DateTime startDate;
                GetStartAndEndDate(out startDate, out endDate);

                GrossProfitMargin grossProfitMargin = CurrentApiClient.Instance.GetKeyFigureResource(companyInfo).GetGrossProfitMargin(startDate, endDate);

                tbKeyFigureResult.Text = GetGrossProfitMarginReport(grossProfitMargin);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
        
        private void btnGrossMargin_Click(object sender, System.EventArgs e)
        {
            try
            {
                tbKeyFigureResult.Text = string.Empty;

                // Parse dates to use from argument string
                DateTime endDate;
                DateTime startDate;
                GetStartAndEndDate(out startDate, out endDate);

                GrossMargin grossMargin = CurrentApiClient.Instance.GetKeyFigureResource(companyInfo).GetGrossMargin(startDate, endDate);

                tbKeyFigureResult.Text = GetGrossMarginReport(grossMargin);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }

        private void btnCostsForEmployees_Click(object sender, System.EventArgs e)
        {
            try
            {
                tbKeyFigureResult.Text = string.Empty;

                // Parse dates to use from argument string
                DateTime endDate;
                DateTime startDate;
                GetStartAndEndDate(out startDate, out endDate);

                CostsForEmployees costsForEmployees = CurrentApiClient.Instance.GetKeyFigureResource(companyInfo).GetCostsForEmployees(startDate, endDate);

                tbKeyFigureResult.Text = GetCostsForEmployeesReport(costsForEmployees);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
        
        private void btnAllKeyFigures_Click(object sender, EventArgs e)
        {
            try
            {
                tbKeyFigureResult.Text = string.Empty;

                // Parse dates to use from argument string
                DateTime endDate;
                DateTime startDate;
                GetStartAndEndDate(out startDate, out endDate);

                List<IKeyFigure> listWithKeyFigures = CurrentApiClient.Instance.GetKeyFigureResource(companyInfo).GetAllKeyFigures(startDate, endDate);

                tbKeyFigureResult.Text = GetAllKeyFiguresReport(listWithKeyFigures);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, MessageBoxHeaderText.Failure);
            }
        }
        
        private void btnClearStartDate_Click(object sender, System.EventArgs e)
        {
            RemoveArgument(StartDateKey);
        }

        private void btnClearEndDate_Click(object sender, System.EventArgs e)
        {
            RemoveArgument(EndDateKey);
        }

        private void mcStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            SetDateArgument(StartDateKey, mcStartDate.SelectionStart);
        }

        private void mcEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            SetDateArgument(EndDateKey, mcEndDate.SelectionStart);
        }
        
        private void SetDateArgument(string argumentKey, DateTime dateTime)
        {
            IEnumerable<string> arguments = tbArgumentString.Text.Split('&').Where(s => !string.IsNullOrEmpty(s));

            bool hasAddedArgumentKey = false;
            var newArgumentList = new StringBuilder();
            foreach (string argument in arguments)
            {
                if (argument.Contains(argumentKey))
                {
                    newArgumentList.Append("&" + argumentKey + "=" + dateTime.ToShortDateString());
                    hasAddedArgumentKey = true;
                }
                else
                {
                    newArgumentList.Append("&" + argument);
                }
            }

            if (!hasAddedArgumentKey)
            {
                newArgumentList.Append("&" + argumentKey + "=" + dateTime.ToShortDateString());
            }
            
            tbArgumentString.Text = newArgumentList.ToString();

            // Remove first char if it is a &
            if (tbArgumentString.Text.StartsWith("&"))
            {
                tbArgumentString.Text = tbArgumentString.Text.Remove(0, 1);
            }
        }

        private void RemoveArgument(string argumentKey)
        {
            IEnumerable<string> arguments = tbArgumentString.Text.Split('&').Where(s => !string.IsNullOrEmpty(s));
            
            var newArgumentList = new StringBuilder();
            foreach (string argument in arguments)
            {
                if (argument.Contains(argumentKey))
                {
                    continue;
                }
                
                newArgumentList.Append("&" + argument);
            }
            
            tbArgumentString.Text = newArgumentList.ToString().Remove(0, 1);
        }

        private static string GetTurnoverReport(Turnover turnover)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Turnover successfully fetched.");
            builder.AppendLine("Name:\t\t" + turnover.Name);
            builder.AppendLine("Description:\t\t" + turnover.Description);
            builder.AppendLine("Start:\t\t" + turnover.Start);
            builder.AppendLine("End:\t\t" + turnover.End);
            builder.AppendLine("Entries:\t\t");
            foreach (TurnoverEntry entry in turnover.Entries)
            {
                builder.AppendLine("\tTurnover:\t\t" + entry.Value);
            }

            return builder.ToString();
        }

        private static string GetProfitReport(Profit profit)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Profit successfully fetched.");
            builder.AppendLine("Name:\t\t" + profit.Name);
            builder.AppendLine("Description:\t\t" + profit.Description);
            builder.AppendLine("Start:\t\t" + profit.Start);
            builder.AppendLine("End:\t\t" + profit.End);
            builder.AppendLine("Entries:\t\t");
            foreach (ProfitEntry entry in profit.Entries)
            {
                builder.AppendLine("\tIncome:\t\t" + entry.Income);
                builder.AppendLine("\tCost:\t\t" + entry.Cost);
                builder.AppendLine("\tFinancial entry:\t\t" + entry.FinancialEntry);
                builder.AppendLine("\tProfit:\t\t" + entry.Value);
            }

            return builder.ToString();
        }

        private static string GetGrossProfitMarginReport(GrossProfitMargin grossProfitMargin)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Gross profit margin successfully fetched.");
            builder.AppendLine("Name:\t\t" + grossProfitMargin.Name);
            builder.AppendLine("Description:\t\t" + grossProfitMargin.Description);
            builder.AppendLine("Start:\t\t" + grossProfitMargin.Start);
            builder.AppendLine("End:\t\t" + grossProfitMargin.End);
            builder.AppendLine("Entries:\t\t");
            foreach (GrossProfitMarginEntry entry in grossProfitMargin.Entries)
            {
                builder.AppendLine("\tGoods for resale:\t\t" + entry.GoodsForResale);
                builder.AppendLine("\tIncome:\t\t" + entry.Income);
                builder.AppendLine("\tNet sale:\t\t" + entry.NetSale);
                builder.AppendLine("\tGross profit margin:\t\t" + entry.Value);
            }

            return builder.ToString();
        }

        private static string GetGrossMarginReport(GrossMargin grossMargin)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Gross margin successfully fetched.");
            builder.AppendLine("Name:\t\t" + grossMargin.Name);
            builder.AppendLine("Description:\t\t" + grossMargin.Description);
            builder.AppendLine("Start:\t\t" + grossMargin.Start);
            builder.AppendLine("End:\t\t" + grossMargin.End);
            builder.AppendLine("Entries:\t\t");
            foreach (GrossMarginEntry entry in grossMargin.Entries)
            {
                builder.AppendLine("\tCost:\t\t" + entry.Cost);
                builder.AppendLine("\tIncome:\t\t" + entry.Cost);
                builder.AppendLine("\tGrossMargin:\t\t" + entry.Value);
            }

            return builder.ToString();
        }

        private static string GetCostsForEmployeesReport(CostsForEmployees costsForEmployees)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Costs for employees successfully fetched.");
            builder.AppendLine("Name:\t\t" + costsForEmployees.Name);
            builder.AppendLine("Description:\t\t" + costsForEmployees.Description);
            builder.AppendLine("Start:\t\t" + costsForEmployees.Start);
            builder.AppendLine("End:\t\t" + costsForEmployees.End);
            builder.AppendLine("Entries:\t\t");
            foreach (CostsForEmployeesEntry entry in costsForEmployees.Entries)
            {
                builder.AppendLine("\tEmployee benefits and expense:\t\t" + entry.EmployeeBenefitsAndExpense);
                builder.AppendLine("\tIncome:\t\t" + entry.Income);
                builder.AppendLine("\tCost for employees:\t\t" + entry.Value);
            }

            return builder.ToString();
        }

        private static string GetAllKeyFiguresReport(List<IKeyFigure> listWithKeyFigures)
        {
            var builder = new StringBuilder();

            foreach (IKeyFigure keyFigure in listWithKeyFigures)
            {
                switch (keyFigure.Type)
                {
                    case KeyFigureType.CostForEmployees:
                        builder.Append(GetCostsForEmployeesReport((CostsForEmployees)keyFigure));
                        break;
                    case KeyFigureType.GrossMargin:
                        builder.Append(GetGrossMarginReport((GrossMargin)keyFigure));
                        break;
                    case KeyFigureType.GrossProfitMargin:
                        builder.Append(GetGrossProfitMarginReport((GrossProfitMargin)keyFigure));
                        break;
                    case KeyFigureType.Profit:
                        builder.Append(GetProfitReport((Profit)keyFigure));
                        break;
                    case KeyFigureType.Turnover:
                        builder.Append(GetTurnoverReport((Turnover)keyFigure));
                        break;
                    default:
                        throw new ApiException("Unknown key figure type found.", ApiErrorType.NotImplemented);
                }
            }
            return builder.ToString();
        }

        private void GetStartAndEndDate(out DateTime startDate, out DateTime endDate)
        {
            IEnumerable<string> arguments = tbArgumentString.Text.Split('&').Where(s => !string.IsNullOrEmpty(s));

            startDate = mcStartDate.MinDate;
            endDate = mcEndDate.MaxDate;

            foreach (string argument in arguments)
            {
                if (argument.Contains(StartDateKey))
                {
                    string value = argument.Split('=')[1];
                    startDate = DateTime.Parse(value);
                }

                if (argument.Contains(EndDateKey))
                {
                    string value = argument.Split('=')[1];
                    endDate = DateTime.Parse(value);
                }
            }
        }
    }
}
