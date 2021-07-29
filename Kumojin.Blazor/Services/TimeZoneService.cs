using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kumojin.Blazor.Data;
using Newtonsoft.Json;

namespace Kumojin.Blazor.Services
{
    public class TimeZoneService : ITimeZoneService
    {
        private HttpClient _httpClient;
        public TimeZoneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DateTimeDTO> GetTimeZone(string timezoneId)
        {
            var urlApi = $"/timezone?timezoneid={timezoneId}";
            var response =  await _httpClient.GetAsync(urlApi);
            string content = await response.Content.ReadAsStringAsync();

            var timezone = JsonConvert.DeserializeObject<DateTimeDTO>(content);
            return timezone;
        }

        public TimeZoneViewModel GetViewModel() => new();
    }
}