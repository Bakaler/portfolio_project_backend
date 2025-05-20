// using System.Net.Http;
// using System.Text.Json;
// using System.Threading.Tasks;
// using PortfolioBackend.Interfaces.Services;
// using PortfolioBackend.Models;
// using Microsoft.Extensions.Configuration;

// namespace PortfolioBackend.Services.Weather
// {
//     public class WeatherService : IWeatherService
//     {
//         private readonly HttpClient _httpClient;
//         private readonly string _apiKey;

//         public WeatherService(HttpClient httpClient, IConfiguration configuration)
//         {
//             _httpClient = httpClient;
//             _apiKey = configuration["OpenWeatherMap:ApiKey"];
//         }

//         public async Task<WeatherForecast> GetForecastAsync(string city)
//         {
//             var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
//             var response = await _httpClient.GetAsync(url);

//             if (!response.IsSuccessStatusCode)
//                 return null;

//             var json = await response.Content.ReadAsStringAsync();
//             var raw = JsonSerializer.Deserialize<OpenWeatherResponse>(json);

//             return new WeatherForecast
//             {
//                 City = raw.Name,
//                 Temperature = raw.Main.Temp,
//                 Description = raw.Weather[0].Description
//             };
//         }
//     }
// }
