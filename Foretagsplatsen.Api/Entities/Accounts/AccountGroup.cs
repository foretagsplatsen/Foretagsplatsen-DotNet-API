using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public class AccountGroup : IAccountGroup
    {
        public const string TypeName = "AccountGroup";

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get { return TypeName; } }

        [JsonConverter(typeof(ChartOfAccountChildJsonConverter))]
        public List<IChartOfAccountChild> Children { get; set; }

        public AccountGroup()
        {
            Id = Guid.NewGuid().ToString();
            Children = new List<IChartOfAccountChild>();
        }
    }
}