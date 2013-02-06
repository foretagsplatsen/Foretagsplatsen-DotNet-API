using System.Collections.Generic;
// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Accounts
{
    public interface IAccountGroup : IChartOfAccountChild
    {
        string name { get; set; }
        List<IChartOfAccountChild> children { get; }
    }
}
// ReSharper restore InconsistentNaming