// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Information about a user
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// The user name. Is a required field, must be unique.
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// The password, is only used when updating the user.
        /// </summary>
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        /// <summary>
        /// Language in culture name format, eg: se-SV or nb-NO
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// The type of user:
        /// * "AgencyConsultant"
        /// * "AgencyDirector"
        /// * "CompanyUser"
        /// </summary>
        public string type { get; protected set; }
    }
}
