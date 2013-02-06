// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Information about a user
    /// </summary>
    public class UserInfo
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public UserType type { get; protected set; }
    }
}
// ReSharper restore InconsistentNaming