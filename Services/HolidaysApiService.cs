using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using ConsumeThirdPartyAPIs.Exceptions;

namespace ConsumeThirdPartyAPIs.Services
{
    public class HolidaysApiService : IHolidaysApiService 
    {

        private readonly HttpClient client;

        public HolidaysApiService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("PublicHolidaysApi");
        }

        public async Task<List<HolidayModel>> GetHolidays(int year, string countryCode) 
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<HolidayModel>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse, new JsonSerializerOptions() {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
            else
            {
                throw new ServiceException(response.StatusCode);
            }

            return result;
        }
    }
}
