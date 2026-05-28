using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeMachine.Api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        // Inject HttpClient so we don't exhaust our server's sockets
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetCurrentTemperatureAsync()
        {
            // Using Open-Meteo for Baguio, Philippines as a default location (feel free to change lat/long!)
            // current_weather=true gives us a simple JSON object with the temperature
            //try dubai wheather to check the iced coffee message
            //
            //var url = "https://api.open-meteo.com/v1/forecast?latitude=25.2048&longitude=55.2708&current_weather=true";

            //try baguio weather to check the hot coffee message
            var url = "https://api.open-meteo.com/v1/forecast?latitude=16.4167&longitude=120.5833&current_weather=true";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Parse the JSON. A quick way to grab a specific value without making full C# models!
            using var jsonDocument = JsonDocument.Parse(content);
            var temperature = jsonDocument.RootElement
                .GetProperty("current_weather")
                .GetProperty("temperature")
                .GetDouble();

            return temperature;
        }
    }
}