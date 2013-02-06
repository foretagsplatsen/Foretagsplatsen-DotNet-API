// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.User
{
    public class PartnerUser : UserInfo
    {
        public PartnerUser()
        {
            type = UserType.partnerUser;
        }

        public string partnerId { get; set; }
    }
}
// ReSharper restore InconsistentNaming
