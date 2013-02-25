using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    public class KnownGroup : IAccountGroup
    {
        public const string typeName = "SubSetAccountGroup";

        public string id { get; set; }

        /// <summary>
        /// Is "SubSetAccountGroup" for known groups.
        /// See also <see cref="AccountGroup"/> and <see cref="AccountIntervalGroup"/>.
        /// </summary>
        public string type { get { return typeName; } }
        public string name { get; set; }
        public List<IChartOfAccountChild> children { get; protected set; }

        public KnownGroup()
        {
            children = new List<IChartOfAccountChild>();
        }
    }
}