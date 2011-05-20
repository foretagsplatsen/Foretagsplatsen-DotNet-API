using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Foretagsplatsen.Api.Entities.KeyFigures;
using Foretagsplatsen.Api.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Rest resource for key figures
    /// https://web.foretagsplatsen.se/Api/Company/x/KeyFigures/y
    /// where x = business identity code and y is the key figure wanted
    /// </summary>
    public class KeyFigureResource
    {
        private readonly ApiClient apiClient;
        private readonly string businessIdentityCode;

        public KeyFigureResource(ApiClient client, string businessIdentityCode)
        {
            apiClient = client;
            this.businessIdentityCode = businessIdentityCode;
        }

        private string BaseUrl
        {
            get
            {
                return apiClient.BaseUrl + "/Api/Company/{0}/KeyFigures/{1}";
            }
        }

        /// <summary>
        /// Return data for Cross margin key figure
        /// </summary>
        /// <returns><see cref="GrossMargin"/></returns>
        public GrossMargin GetGrossMargin()
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "GrossMargin");
            return apiClient.Get<GrossMargin>(url);
        }

        /// <summary>
        /// Return data for Cross margin key figure with limits for start and end date
        /// </summary>
        /// <param name="startDate">Date to start fetch data from</param>
        /// <param name="endDate">Date to stop fetch data from</param>
        /// <returns><see cref="GrossMargin"/></returns>
        public GrossMargin GetGrossMargin(DateTime startDate, DateTime endDate)
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "GrossMargin");

            string urlWithDateArguments = string.Format("{0}?startdate={1}&enddate={2}", url, startDate.ToShortDateString(), endDate.ToShortDateString());

            return apiClient.Get<GrossMargin>(urlWithDateArguments);
        }
        
        /// <summary>
        /// Return key figures for turnover
        /// </summary>
        /// <returns><see cref="Turnover"/></returns>
        public Turnover GetTurnover()
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "Turnover");
            return apiClient.Get<Turnover>(url);
        }

        /// <summary>
        /// Return data for turnover key figure with limits for start and end date
        /// </summary>
        /// <param name="startDate">Date to start fetch data from</param>
        /// <param name="endDate">Date to stop fetch data from</param>
        /// <returns><see cref="Turnover"/></returns>
        public Turnover GetTurnover(DateTime startDate, DateTime endDate)
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "Turnover");

            string urlWithDateArguments = string.Format("{0}?startdate={1}&enddate={2}", url, startDate.ToShortDateString(), endDate.ToShortDateString());

            return apiClient.Get<Turnover>(urlWithDateArguments);
        }

        /// <summary>
        /// Return key figures for profit
        /// </summary>
        /// <returns><see cref="Profit"/></returns>
        public Profit GetProfit()
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "Profit");
            return apiClient.Get<Profit>(url);
        }

        /// <summary>
        /// Return data for profit key figure with limits for start and end date
        /// </summary>
        /// <param name="startDate">Date to start fetch data from</param>
        /// <param name="endDate">Date to stop fetch data from</param>
        /// <returns><see cref="Profit"/></returns>
        public Profit GetProfit(DateTime startDate, DateTime endDate)
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "Profit");

            string urlWithDateArguments = string.Format("{0}?startdate={1}&enddate={2}", url, startDate.ToShortDateString(), endDate.ToShortDateString());

            return apiClient.Get<Profit>(urlWithDateArguments);
        }

        /// <summary>
        /// Return key figures for gross profit margin
        /// </summary>
        /// <returns><see cref="GrossProfitMargin"/></returns>
        public GrossProfitMargin GetGrossProfitMargin()
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "GrossProfitMargin");
            return apiClient.Get<GrossProfitMargin>(url);
        }

        /// <summary>
        /// Return data for gross profit margin key figure with limits for start and end date
        /// </summary>
        /// <param name="startDate">Date to start fetch data from</param>
        /// <param name="endDate">Date to stop fetch data from</param>
        /// <returns><see cref="GrossProfitMargin"/></returns>
        public GrossProfitMargin GetGrossProfitMargin(DateTime startDate, DateTime endDate)
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "GrossProfitMargin");

            string urlWithDateArguments = string.Format("{0}?startdate={1}&enddate={2}", url, startDate.ToShortDateString(), endDate.ToShortDateString());

            return apiClient.Get<GrossProfitMargin>(urlWithDateArguments);
        }

        /// <summary>
        /// Return key figures for costs for employees
        /// </summary>
        /// <returns><see cref="CostsForEmployees"/></returns>
        public CostsForEmployees GetCostsForEmployees()
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "CostsForEmployees");
            return apiClient.Get<CostsForEmployees>(url);
        }

        /// <summary>
        /// Return data for costs for employees key figure with limits for start and end date
        /// </summary>
        /// <param name="startDate">Date to start fetch data from</param>
        /// <param name="endDate">Date to stop fetch data from</param>
        /// <returns><see cref="CostsForEmployees"/></returns>
        public CostsForEmployees GetCostsForEmployees(DateTime startDate, DateTime endDate)
        {
            string url = string.Format(BaseUrl, businessIdentityCode, "CostsForEmployees");

            string urlWithDateArguments = string.Format("{0}?startdate={1}&enddate={2}", url, startDate.ToShortDateString(), endDate.ToShortDateString());

            return apiClient.Get<CostsForEmployees>(urlWithDateArguments);
        }

        /// <summary>
        /// Return a list with all key figures 
        /// </summary>
        /// <returns>List of <see cref="IKeyFigure"/>s</returns>
        public List<IKeyFigure> GetAllKeyFigures()
        {
            string url = string.Format(BaseUrl, businessIdentityCode, string.Empty);

            // Execute GET
            WebResponse response = apiClient.Get(url);
            string body = ApiClient.TryReadResponseBody(response);

            // Get all figures
            JArray figures = JArray.Parse(body);

            // Create key figures, add to a list and return
            return figures.Select(CreateKeyFigure).ToList();
        }

        /// <summary>
        /// Return a list with all key figures 
        /// </summary>
        /// <param name="startDate">Date to start fetch data from</param>
        /// <param name="endDate">Date to stop fetch data from</param>
        /// <returns>List of <see cref="IKeyFigure"/>s</returns>
        public List<IKeyFigure> GetAllKeyFigures(DateTime startDate, DateTime endDate)
        {
            string url = string.Format(BaseUrl, businessIdentityCode, string.Empty);
            
            string urlWithDateArguments = string.Format("{0}?startdate={1}&enddate={2}", url, startDate.ToShortDateString(), endDate.ToShortDateString());
            
            // Execute GET
            WebResponse response = apiClient.Get(urlWithDateArguments);
            string body = ApiClient.TryReadResponseBody(response);

            // Get all figures
            JArray figures = JArray.Parse(body);

            // Create key figures, add to a list and return
            return figures.Select(CreateKeyFigure).ToList();
        }

        /// <summary>
        /// Create and return a key figure from a JToken json data
        /// </summary>
        /// <param name="keyFigureData">Json data to parse to a keyfigure</param>
        /// <returns><see cref="IKeyFigure"/></returns>
        private static IKeyFigure CreateKeyFigure(JToken keyFigureData)
        {
            var type = keyFigureData["Type"].Value<string>();

            try
            {
                switch (type)
                {
                    case KeyFigureType.CostForEmployees:
                        return JsonConvert.DeserializeObject<CostsForEmployees>(keyFigureData.ToString());
                    case KeyFigureType.GrossMargin:
                        return JsonConvert.DeserializeObject<GrossMargin>(keyFigureData.ToString());
                    case KeyFigureType.GrossProfitMargin:
                        return JsonConvert.DeserializeObject<GrossProfitMargin>(keyFigureData.ToString());
                    case KeyFigureType.Profit:
                        return JsonConvert.DeserializeObject<Profit>(keyFigureData.ToString());
                    case KeyFigureType.Turnover:
                        return JsonConvert.DeserializeObject<Turnover>(keyFigureData.ToString());
                    default:
                        throw new ApiException("Key figure type not implemented.");
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Could not parse key figure type: {0}", type), ex.InnerException);
            }
        }
    }
}