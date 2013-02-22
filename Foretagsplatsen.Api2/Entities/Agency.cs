// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Basic information about an agency
    /// </summary>
    public class Agency
    {
        /// <summary>
        /// Is a uniqe identifier for the agency
        /// </summary>
        public string shortName { get; set; }

        /// <summary>
        /// The real name of the agency
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The number of company licences the agency have
        /// </summary>
        public int? numberOfLicences { get; set; }

        /// <summary>
        /// The contact information for the agency <seealso cref="ContactInfo"/>
        /// </summary>
        public ContactInfo contactInfo { get; set; }
    }
}