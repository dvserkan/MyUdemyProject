using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBookings()
        {
            return PartialView();
        }

        string url = "http://localhost:5080/api/Booking";

        [HttpPost]
        public async Task<IActionResult> AddBookings(CreateBookingDto createBookingDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{url}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return RedirectToAction("Index", "Booking");


        }
    }
}
