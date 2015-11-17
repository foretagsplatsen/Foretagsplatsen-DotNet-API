// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Company
{
    /// <summary>
    /// Basic information about a company
    /// </summary>
    public class CompanyInfo
    {
        /// <summary>
        /// Can be "Company" or "FortnoxCompany", default value if left out is "Company"
        /// </summary>
        public string typeOfCompany { get; set; }
        /// <summary>
        /// Is unique. See the overview documentation for more information.
        /// </summary>
        public string id { get; set; }
        public string name { get; set; }
        public string businessIdentityCode { get; set; }
        public ContactInfo contactInfo { get; set; }
        /// <summary>
        /// Fortnox API authorization code. Only used when creating or updating a Fortnox company.
        /// </summary>
        public string fortnoxAuthorizationCode { get; set; }
    }
}