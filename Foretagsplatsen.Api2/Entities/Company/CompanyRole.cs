// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Company
{
    public class CompanyRole
    {
        public const string adminCompanyRoleType = "Admin";
        public const string normalCompanyRoleType = "Normal";
        public const string limitedCompanyRoleType = "Limited";

        public string companyId { get; set; }
        public string typeOfRole { get; set; }
    }
}