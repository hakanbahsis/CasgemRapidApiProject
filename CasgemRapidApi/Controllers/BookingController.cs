using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task< IActionResult> Index(string adult="1", string child = "1",string checkindate = "2023-09-27",string checkoutdate = "2023-09-30", string roomnumber = "1",string cityId = "-553173")
        {
         
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                //RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date={checkindate}&dest_type={cityId}&units=metric&checkout_date={checkoutdate}& adults_number={adult}&order_by=popularity&dest_id=-553173&filter_by_currency=AED&locale=en-gb&room_number={roomnumber}&children_number={child}&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&include_adjacency=true"),
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkindate}&filter_by_currency=USD&dest_id={cityId}&locale=en-gb&checkout_date={checkoutdate}&units=metric&room_number={roomnumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
                var values = JsonConvert.DeserializeObject<HotelListViewModel>(body);
                return View(values.results.ToList());
            }
            
        }
    }
}
