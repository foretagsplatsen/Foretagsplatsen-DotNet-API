using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    /// <summary>
    /// Represents a leaf node in the chart of accounts tree, which contains a list of accounts.
    /// </summary>
    public class AccountListGroup : IChartOfAccountChild
    {
        public const string typeName = "AccountListGroup";
        public string id { get; set; }

        /// <summary>
        /// Is "AccountListGroup" for list of accounts.
        /// See also <see cref="AccountGroup"/> and <see cref="KnownGroup"/>.
        /// </summary>
        public string type { get { return typeName; } }

        /// <summary>
        /// The list of account numbers this leaf node contains.
        /// </summary>
        public List<string> accounts { get; set; }

        public AccountListGroup()
        {
            accounts = new List<string>();
        }
    }
}