using ConsumingHolidaysAPI.Interfaces;
using ConsumingHolidaysAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumingHolidaysAPI.Services
{
    public class HolidaysAPIService : IHolidaysAPIService
    {
        private static readonly HttpClient client;
        static HolidaysAPIService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://date.nager.at")
            };
        }
        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<HolidayModel>();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
