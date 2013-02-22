// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Partner user is user connected to a partner.
    /// </summary>
    public class PartnerUser : UserInfo
    {
        public const string PartnerUserTypeName = "partnerUser";

        public PartnerUser()
        {
            type = PartnerUserTypeName;
        }

        /// <summary>
        /// The id of the partner the user is connected to.
        /// </summary>
        public string partnerId { get; set; }
    }
}