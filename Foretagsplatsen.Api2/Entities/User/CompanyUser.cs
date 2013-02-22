using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities.Company;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Company user is a user connected to one or more company. The user can have different roles in each company, 
    /// defined in CompanyRole.
    /// </summary>
    public class CompanyUser : UserInfo
    {
        public const string companyUserTypeName = "companyUser";

        public CompanyUser()
        {
            type = companyUserTypeName;
        }

        /// <summary>
        /// List of companies the user have access to.
        /// </summary>
        public IEnumerable<CompanyRole> companies { get; set; }
    }
}