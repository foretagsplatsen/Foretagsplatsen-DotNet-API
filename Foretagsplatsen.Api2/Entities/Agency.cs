// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Basic information about an agency
    /// </summary>
    public class Agency
    {
        public string shortName { get; set; }
        public string name { get; set; }
        public int? numberOfLicences { get; set; }
        public ContactInfo contactInfo { get; set; }
    }
}
// ReSharper restore InconsistentNaming
