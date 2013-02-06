using System;
using Foretagsplatsen.Api2.Entities.User;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class UserBaseResource
    {
        protected readonly ApiClient Client;

        public UserBaseResource(ApiClient client)
        {
            this.Client = client;
        }

        #region Private methods

        protected UserInfo CreateUser(JToken obj)
        {

            if (obj["type"] == null)
            {
                throw new ApiException("Invalid json. No user type found.", ApiErrorType.Unknown);
            }

            var type = (UserType) obj["type"].Value<int>();

            try
            {
                switch (type)
                {
                    case UserType.partnerUser:
                        return JsonConvert.DeserializeObject<PartnerUser>(obj.ToString());
                    case UserType.agencyDirector:
                        return JsonConvert.DeserializeObject<AgencyDirector>(obj.ToString());
                    case UserType.agencyConsultant:
                        return JsonConvert.DeserializeObject<AgencyConsultant>(obj.ToString());
                    case UserType.companyUser:
                        return JsonConvert.DeserializeObject<CompanyUser>(obj.ToString());

                    default:
                        throw new ApiException("User type not implemented.", ApiErrorType.Unknown);
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Could not parse user type: {0}", type), ApiErrorType.Unknown, ex.InnerException);
            }
        }

        #endregion
    }
}