using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RapidApiConsume.Models;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {

       
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&locale=en-gb&children_ages=5%2C0&filter_by_currency=AED&checkin_date=2024-09-14&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&dest_type=city&dest_id=-553173&adults_number=2&checkout_date=2024-09-15&order_by=popularity&include_adjacency=true&room_number=1&page_number=0&units=metric"),
                Headers =
    {
        { "x-rapidapi-key", "1d67c6e122msh2230c6baee64e7ep13fd08jsncecf114d3848" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values);
            }
          
        }
    }
}
