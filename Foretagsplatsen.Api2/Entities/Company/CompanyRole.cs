// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Company
{
    public class CompanyRole
    {
        public const string adminCompanyRoleType = "Admin";
        public const string normalCompanyRoleType = "Normal";
        public const string limitedCompanyRoleType = "Limited";

        /// <summary>
        /// The id of the company the role applies to. See also <see cref="CompanyInfo"/>.
        /// </summary>
        public string companyId { get; set; }

        /// <summary>
        /// Can be "Admin", "Normal" or "Limited"
        /// </summary>
        public string typeOfRole { get; set; }
    }
}