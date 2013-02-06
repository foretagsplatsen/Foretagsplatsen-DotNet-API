namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Basic company contact information 
    /// </summary>
    public class ContactInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string Phone { get; set; }           
    }
}