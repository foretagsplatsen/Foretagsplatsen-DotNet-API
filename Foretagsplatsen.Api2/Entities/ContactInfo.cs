// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities
{
    /// <summary>
    /// Basic company contact information 
    /// </summary>
    public class ContactInfo
    {
        public string name { get; set; }
        public string address { get; set; }
        public string postalAddress { get; set; }
        public string phone { get; set; }
    }
}