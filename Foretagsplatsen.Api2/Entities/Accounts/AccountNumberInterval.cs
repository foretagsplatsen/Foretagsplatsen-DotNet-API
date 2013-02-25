// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    /// <summary>
    /// Represents an account intervall. The comparison is done by alphanumeric equiality.
    /// To repesent a singel account, set the start and end to the same value.
    /// </summary>
    public class AccountNumberInterval
    {
        public string start { get; set; }
        public string end { get; set; }
    }
}