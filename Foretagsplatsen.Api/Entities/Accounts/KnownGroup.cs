using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public class KnownGroup : IAccountGroup
    {
        public const string TypeName = "SubSetAccountGroup";

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get { return TypeName; } }

        public List<IChartOfAccountChild> Children { get; protected set; }

        public KnownGroup()
        {
            Children = new List<IChartOfAccountChild>();
        }
    }
}