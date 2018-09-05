using System.Collections.Generic;
using Newtonsoft.Json;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public class ChartOfAccounts
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(ChartOfAccountChildJsonConverter))]
        public List<IChartOfAccountChild> Children { get; set; }

        public KnownGroupDictionary KnownGroups { get; set; }

        public ChartOfAccounts()
        {
            KnownGroups = new KnownGroupDictionary(this);
            Children = new List<IChartOfAccountChild>();
        }

        public IChartOfAccountChild GetChildById(string id)
        {
            foreach (var child in Children)
            {
                var childGroup = FindChildById(child, id);
                if (childGroup != null)
                {
                    return childGroup;
                }
            }

            return null;
        }

        private IChartOfAccountChild FindChildById(IChartOfAccountChild group, string id)
        {
            if (group.Id == id)
            {
                return group;
            }

            var accountGroup = group as AccountGroup;
            if (accountGroup != null)
            {
                foreach (var child in accountGroup.Children)
                {
                    var childGroup = FindChildById(child, id);
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