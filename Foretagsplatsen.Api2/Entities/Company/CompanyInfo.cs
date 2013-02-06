// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Basic information about a company
    /// </summary>
    public class CompanyInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string businessIdentityCode { get; set; }

        public ContactInfo contactInfo { get; set; }
    }
}
// ReSharper restore InconsistentNaming
