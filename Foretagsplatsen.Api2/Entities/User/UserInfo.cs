// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Information about a user
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// The user name.
        /// Required field.
        /// Must be unique.
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// The password, is only used for updates of the user.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// The real name of the user.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Phone number to the user.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Cell phone number to the user.
        /// </summary>
        public string cellphone { get; set; }

        /// <summary>
        /// E-mail adress to the user
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// The type of user, for example agency consultant.
        /// </summary>
        public string type { get; protected set; }
    }
}