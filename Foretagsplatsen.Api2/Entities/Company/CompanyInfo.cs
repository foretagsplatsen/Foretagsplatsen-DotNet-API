// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Company
{
    /// <summary>
    /// Basic information about a company
    /// </summary>
    public class CompanyInfo
    {
        /// <summary>
        /// Is unique. See the overview documentation for more information.
        /// </summary>
        public string id { get; set; }
        public string name { get; set; }
        public string businessIdentityCode { get; set; }
        public ContactInfo contactInfo { get; set; }
    }
}