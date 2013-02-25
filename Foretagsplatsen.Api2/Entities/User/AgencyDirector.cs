// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Agency director is a user connected to an agency with director permissions. It can administrate the whole agency,
    /// all companies, company users and all the other agency users for the agency.
    /// </summary>
    public class AgencyDirector : AgencyUser
    {
        public const string agencyDirectorTypeName = "AgencyDirector";

        public AgencyDirector()
        {
            type = agencyDirectorTypeName;
        }
    }
}