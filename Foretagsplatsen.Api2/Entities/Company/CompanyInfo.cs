// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Company
{
    /// <summary>
    /// Basic information about a company
    /// </summary>
    public class CompanyInfo
    {
        public const string FortnoxCompanyType = "FortnoxCompany";
        public const string CompanyType = "Company";

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
        /// Cannot be used together with fortnoxExtendedAuthorizationCode in the same request.
        /// </summary>
        public string fortnoxAuthorizationCode { get; set; }
        /// <summary>
        /// Fortnox Extended API authorization code. Only used when creating or updating a Fortnox company with extended API support for accounts receivables and liquidity support.
        /// Cannot be used together with fortnoxAuthorizationCode in the same request.
        /// </summary>
        public string fortnoxExtendedAuthorizationCode { get; set; }

        public bool? isVirtualFarmerCompany { get; set; }

        public bool isFortnoxCompany => typeOfCompany == FortnoxCompanyType;
        public bool hasFortnoxAuthorizationCode => !string.IsNullOrEmpty(fortnoxAuthorizationCode);
        public bool hasFortnoxExtendedAuthorizationCode => !string.IsNullOrEmpty(fortnoxExtendedAuthorizationCode);
        /// <summary>
        /// Id of the company type.
        /// null means "use agency's default company type"
        /// </summary>
        public string CompanyTypeId { get; set; }
    }
}