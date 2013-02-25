// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Basic information about an agency.
    /// </summary>
    public class Agency
    {
        /// <summary>
        /// Is a uniqe identifier for the agency, alse refered to as the agency id.
        /// </summary>
        public string shortName { get; set; }
        public string name { get; set; }
        public int? numberOfLicences { get; set; }
        public ContactInfo contactInfo { get; set; }
    }
}