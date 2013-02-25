using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    /// <summary>
    /// A chart of accounts holds information on how accounts are grouped and classified.
    /// </summary>
    public class ChartOfAccounts
    {

        public string id { get; set; }
        public string name { get; set; }
        public List<IChartOfAccountChild> children { get; set; }
        public KnownGroupDictionary knownGroups { get; set; }

        public ChartOfAccounts()
        {
            knownGroups = new KnownGroupDictionary();
            children = new List<IChartOfAccountChild>();
        }

        public IChartOfAccountChild getChildById(string childId)
        {
            foreach (var child in children)
            {
                var childGroup = findChildById(child, childId);
                if (childGroup != null)
                {
                    return childGroup;
                }
            }

            return null;
        }

        private IChartOfAccountChild findChildById(IChartOfAccountChild group, string childId)
        {
            if (group == null)
            {
                return null;
            }

            if (group.id == childId)
            {
                return group;
            }

            var accountGroup = group as AccountGroup;
            if (accountGroup != null)
            {
                foreach (var child in accountGroup.children)
                {
                    var childGroup = findChildById(child, childId);
                    if (childGroup != null)
                    {
                        return childGroup;
                    }
                }
            }

            return null;
        }
    }
}