namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Basic information about a company
    /// </summary>
    public class CompanyInfo
    {
        public string Name { get; set; }
        public string BusinessIdentityCode { get; set; }

        public ContactInfo ContactInfo { get; set; }
    }
}