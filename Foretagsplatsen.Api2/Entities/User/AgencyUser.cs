using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Agency user is a user connected to an agency and have a list of customers that will show up as "My Customers"
    /// in the webapplication.
    /// </summary>
    public class AgencyUser : UserInfo
    {
        /// <summary>
        /// List of company ids.
        /// </summary>
        public IEnumerable<string> customers { get; set; }
    }
}