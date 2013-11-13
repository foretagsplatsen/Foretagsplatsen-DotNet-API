namespace Foretagsplatsen.Api2
{
    public class LoginParameters
    {
        public string BusinessIdentityCode { get; private set; }
        public string Service { get; private set; }
        public string AgencyId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        protected LoginParameters()
        {
        }

        public static LoginParameters CreateOAuthLoginParameters(string businessIdentityCode, string service)
        {
            return new LoginParameters
            {
                BusinessIdentityCode = businessIdentityCode,
                Service = service
            };
        }

        public static LoginParameters CreateSamlLoginParameters(string agencyId, string businessIdentityCode, string service)
        {
            return new LoginParameters
            {
                AgencyId = agencyId,
                BusinessIdentityCode = businessIdentityCode,
                Service = service
            };
        }

        public static LoginParameters CreateBasicAuthenticationLoginParameters(string userName, string passowrd)
        {
            return new LoginParameters
            {
                UserName = userName,
                Password = passowrd
            };
        }
    }
}