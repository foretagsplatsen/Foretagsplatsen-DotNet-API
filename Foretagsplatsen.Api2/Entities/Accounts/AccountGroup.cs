using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Accounts
{
    public class AccountGroup : IAccountGroup
    {
        public const string typeName = "AccountGroup";

        public string id { get; set; }
        public string name { get; set; }
        public string type { get { return typeName; } }

        public List<IChartOfAccountChild> children { get; set; }

        public AccountGroup()
        {
            id = Guid.NewGuid().ToString();
            children = new List<IChartOfAccountChild>();
        }
    }
}
// ReSharper restore InconsistentNaming