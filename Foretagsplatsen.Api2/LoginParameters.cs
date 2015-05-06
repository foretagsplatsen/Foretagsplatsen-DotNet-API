namespace Foretagsplatsen.Api2
{
    /// <summary>
    /// Valid Login parameters. 
    /// </summary>
    public class LoginParameters
    {
        public const string MyCompaniesServiceName = "MyCompanies";
        public const string DocumentServiceName = "document";
        public const string FinancialServiceName = "financial";
        public const string AccountingServiceName = "accounting";

        /// <summary>
        /// Company and agency users are not required to provide an agency id 
        /// since the company id is enough to uniqly identify a company.
        /// </summary>
        public string AgencyId { get; set; }
        
        /// <summary>
        /// Business Identity code for company to login to.
        /// </summary>
        public string BusinessIdentityCode { get; set; }
        
        /// <summary>
        /// Service to redirect to after login.
        /// </summary>
        public string Service { get; set; }
    }
}