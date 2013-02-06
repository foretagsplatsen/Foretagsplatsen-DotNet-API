namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Basic information about an agency
    /// </summary>
    public class Agency
    {
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int NumberOfLicences { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}