using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Accounts
{
    public class AccountIntervalGroup : IChartOfAccountChild
    {
        public const string typeName = "AccountIntervalGroup";
        public string id { get; set; }
        public string type { get { return typeName; } }
        public List<AccountNumberInterval> intervals { get; set; }

        public AccountIntervalGroup()
        {
            intervals = new List<AccountNumberInterval>();
        }
    }
}
// ReSharper restore InconsistentNaming