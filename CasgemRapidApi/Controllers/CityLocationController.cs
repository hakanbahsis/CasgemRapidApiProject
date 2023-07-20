using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task< IActionResult> Index(string cityName="London")
        {
            ViewBag.CityName = cityName;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "e5bf9a2c47mshed626485772a191p11ca68jsn48b69a420fb6" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);
                return View(values.Take(1).ToList());
               // return View(body);
            }
        }
    }
}
