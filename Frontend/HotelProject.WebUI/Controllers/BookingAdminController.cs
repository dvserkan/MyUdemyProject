using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        string url = "http://localhost:5080/api/Booking";
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);

            }


            return View();
        }

        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            return View();
        }
    }
}
