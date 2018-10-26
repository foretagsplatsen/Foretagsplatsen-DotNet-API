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
            Roles.Add(CreateAgencyDirectorRole(businessIdentityCode));
        } 

        public void AddAgencyConsultantRole(string businessIdentityCode)
        {
            Roles.Add(CreateAgencyConsultantRole(businessIdentityCode));
        }

        public void AddCompanyNormalRole(string businessIdentityCode)
        {
            Roles.Add(CreateCompanyNormalRole(businessIdentityCode));
        }

        public void AddCompanyAdminRole(string businessIdentityCode)
        {
            Roles.Add(CreateCompanyAdminRole(businessIdentityCode));
        }

        public void AddCompanyLimitedRole(string businessIdentityCode)
        {
            Roles.Add(CreateCompanyLimitedRole(businessIdentityCode));
        }

        public static string CreateAgencyDirectorRole(string businessIdentityCode)
        {
            return CreateRole(businessIdentityCode, "AgencyDirector");
        }

        public static string CreateAgencyConsultantRole(string businessIdentityCode)
        {
            return CreateRole(businessIdentityCode, "AgencyConsultant");
        }

        public static string CreateCompanyNormalRole(string businessIdentityCode)
        {
            return CreateRole(businessIdentityCode, "CompanyNormalRole");
        }

        public static string CreateCompanyAdminRole(string businessIdentityCode)
        {
            return CreateRole(businessIdentityCode, "CompanyAdminRole");
        }

        public static string CreateCompanyLimitedRole(string businessIdentityCode)
        {
            return CreateRole(businessIdentityCode, "CompanyLimitedRole");
        }

        private static string CreateRole(string businessIdentityCode, string role)
        {
            return string.Format("{0}|{1}", businessIdentityCode, role);
        }
    }
}
