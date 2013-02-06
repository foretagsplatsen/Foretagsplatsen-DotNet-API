using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.User
{
    public class AgencyUser : UserInfo
    {
        public IEnumerable<string> customers { get; set; } 
    }
}
// ReSharper restore InconsistentNaming
