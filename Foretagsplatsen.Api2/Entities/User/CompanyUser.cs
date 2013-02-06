using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities.Company;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.User
{
    public class CompanyUser : UserInfo
    {
        public CompanyUser()
        {
            type = UserType.companyUser;
        }
        public IEnumerable<CompanyRole> companies { get; set; }
    }
}
// ReSharper restore InconsistentNaming
