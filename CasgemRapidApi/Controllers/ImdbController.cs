using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {

           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "e5bf9a2c47mshed626485772a191p11ca68jsn48b69a420fb6" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ImdbMovieListWiewModel>>(body);
                return View(values);
            }
        }
    }
}
