using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        string url = "http://localhost:5080/api/Staff";
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{url}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);

                return View(values);
            }

            return View();
        }


        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var reponseMessage = await client.PostAsync($"{url}", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{url}/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{url}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PutAsync(url, stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
