using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public class AccountIntervalGroup : IChartOfAccountChild
    {
        public const string TypeName = "AccountIntervalGroup";

        public string Id { get; set; }
        public string Type { get { return TypeName; } }

        public List<AccountNumberInterval> Intervals { get; set; }

        public AccountIntervalGroup()
        {
            Id = Guid.NewGuid().ToString();
            Intervals = new List<AccountNumberInterval>();
        }
    }
}