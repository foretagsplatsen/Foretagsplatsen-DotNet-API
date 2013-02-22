// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Agency consultant is a user connected to an agency with consult permissions. It can only administrate the companies
    /// is is connected to.
    /// </summary>
    public class AgencyConsultant : AgencyUser
    {
        public const string agencyConsultantTypeName = "agencyConsultant";

        public AgencyConsultant()
        {
            type = agencyConsultantTypeName;
        }
    }
}