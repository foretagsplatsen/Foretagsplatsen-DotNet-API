using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public interface IAccountGroup : IChartOfAccountChild
    {
        string Name { get; set; }
        List<IChartOfAccountChild> Children { get; }
    }
}