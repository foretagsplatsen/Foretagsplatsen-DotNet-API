﻿using System.Collections.Generic;
using Newtonsoft.Json;

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

        [JsonConverter(typeof(ChartOfAccountChildJsonConverter))]
        public List<IChartOfAccountChild> children { get; set; }


        public KnownGroupDictionary knownGroups { get; set; }

        /// <summary>
        /// Language in culture name format, eg: se-SV or nb-NO
        /// </summary>
        public string language { get; set; }


        public ChartOfAccounts()
        {
            knownGroups = new KnownGroupDictionary(this);
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