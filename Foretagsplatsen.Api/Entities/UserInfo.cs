using System.Collections;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Information about a user
    /// </summary>
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public UserType TypeOfUser { get; set; }
        public IEnumerable<CompanyRole> Companies { get; set; }
    }
}