using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        string url = "http://localhost:5080/api/Room";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
