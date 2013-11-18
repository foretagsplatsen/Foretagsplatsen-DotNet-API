using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    /// <summary>
    /// Represents a node in a chart of account tree.
    /// </summary>
    public class AccountGroup : IAccountGroup
    {
        public const string typeName = "AccountGroup";

        public string id { get; set; }
        public string name { get; set; }

        /// <summary>
        /// Is "AccountGroup" for account groups.
        /// See also <see cref="KnownGroup"/> and <see cref="AccountIntervalGroup"/>.
        /// </summary>
        public string type { get { return typeName; } }

        /// <summary>
        /// Can be other <see cref="AccountGroup"/> or <see cref="AccountIntervalGroup"/>.
        /// </summary>
        [JsonConverter(typeof(ChartOfAccountChildJsonConverter))]
        public List<IChartOfAccountChild> children { get; set; }

        public AccountGroup()
        {
            id = Guid.NewGuid().ToString();
            children = new List<IChartOfAccountChild>();
        }
    }
}