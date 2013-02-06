using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api2.Saml
{
    public class FtgpSamlAssertionInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public List<string> Roles { get; set; }

        public string AssertionId { get; set; }

        public DateTime NotBefore { get; set; }
        public DateTime NotOnOrAfter { get; set; }

        public string AgencyId { get; set; }

        public FtgpSamlAssertionInfo(string name, string email, string language, string agencyId = null)
            : this(name, email, language, Guid.NewGuid().ToString(), DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1), agencyId)
        {
        }

        public FtgpSamlAssertionInfo(string name, string email, string language, string assertionId, DateTime notBefore, DateTime notOnOrAfter, string agencyId = null)
        {
            Name = name;
            Email = email;
            Language = language;
            Roles = new List<string>();

            AssertionId = assertionId;
            NotBefore = notBefore;
            NotOnOrAfter = notOnOrAfter;

            AgencyId = agencyId;
        }

        public void AddPartnerRole(string partnerId)
        {
            Roles.Add(string.Format("{0}|{1}", partnerId, "PartnerUser"));
        }

        public void AddAgencyDirectorRole(string businessIdentityCode)
        {
            Roles.Add(string.Format("{0}|{1}", businessIdentityCode, "AgencyDirector"));
        } 

        public void AddAgencyConsultantRole(string businessIdentityCode)
        {
            Roles.Add(string.Format("{0}|{1}", businessIdentityCode, "AgencyConsultant"));
        }

        public void AddCompanyNormalRole(string businessIdentityCode)
        {
            Roles.Add(string.Format("{0}|{1}", businessIdentityCode, "CompanyNormalRole"));
        }

        public void AddCompanyAdminRole(string businessIdentityCode)
        {
            Roles.Add(string.Format("{0}|{1}", businessIdentityCode, "CompanyAdminRole"));
        }

        public void AddCompanyLimitedRole(string businessIdentityCode)
        {
            Roles.Add(string.Format("{0}|{1}", businessIdentityCode, "CompanyLimitedRole"));
        }

    }
}