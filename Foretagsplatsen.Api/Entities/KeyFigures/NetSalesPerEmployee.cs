namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    public class NetSalesPerEmployee : KeyFigureBase<NetSalesPerEmployeeEntry>
    {
        public NetSalesPerEmployee()
        {
            PeriodType = PeriodType.Month;
        }
    }
}