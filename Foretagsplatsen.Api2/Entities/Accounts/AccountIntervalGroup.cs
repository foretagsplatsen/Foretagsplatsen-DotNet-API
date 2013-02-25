using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    /// <summary>
    /// Represents a leaf node in the chart of accounts tree.
    /// </summary>
    public class AccountIntervalGroup : IChartOfAccountChild
    {
        public const string typeName = "AccountIntervalGroup";
        public string id { get; set; }

        /// <summary>
        /// Is "AccountIntervalGroup" for account interval groups.
        /// See also <see cref="AccountGroup"/> and <see cref="KnownGroup"/>.
        /// </summary>
        public string type { get { return typeName; } }

        /// <summary>
        /// The list of account number intervals this leaf node contains.
        /// </summary>
        public List<AccountNumberInterval> intervals { get; set; }

        public AccountIntervalGroup()
        {
            intervals = new List<AccountNumberInterval>();
        }
    }
}