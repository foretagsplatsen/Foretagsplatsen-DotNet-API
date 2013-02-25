using System.Collections.Generic;
using Foretagsplatsen.Api2.Entities.Company;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.User
{
    /// <summary>
    /// Company user is a user connected to one or more company. The user can have different roles in each company, 
    /// defined in <see cref="CompanyRole"/>.
    /// </summary>
    public class CompanyUser : UserInfo
    {
        public const string companyUserTypeName = "CompanyUser";

        public CompanyUser()
        {
            type = companyUserTypeName;
        }

        public IEnumerable<CompanyRole> companies { get; set; }
    }
}