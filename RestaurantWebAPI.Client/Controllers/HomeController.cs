using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Client.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Client.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetByIdAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:44376/");
            HttpResponseMessage response = httpClient.GetAsync("https://localhost:44302/api/takeawaymeal/1").Result;
            if (response.IsSuccessStatusCode)
            {
                TakeawayMeal takeawayMeal = await JsonSerializer.DeserializeAsync<TakeawayMeal>(await response.Content.ReadAsStreamAsync());
                return new ObjectResult(takeawayMeal);
            }
            else
            {
                return Content("An error has occurred");
            }
        }

        public async Task<IActionResult> PostAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://localhost:44376/");
            TakeawayMeal newTakeawayMeal = new TakeawayMeal { Name = "Shakshuka with Feta, Olives, and Peppers", Description = "Shakshuka is an easy-to-make recipe where eggs simmered in tomato sauce are seasoned with cumin and smoked paprika. Top it with cilantro, feta, and olives then serve it for breakfast, lunch, or dinner.", Quantity = 3, Price = 23};
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44302/api/takeawaymeal", newTakeawayMeal);
            if (response.IsSuccessStatusCode)
            {
                TakeawayMeal takeawayMeal = await JsonSerializer.DeserializeAsync<TakeawayMeal>(await response.Content.ReadAsStreamAsync());
                return new ObjectResult(takeawayMeal);
            }
            else
            {
                return Content("An error has occurred");
            }
        }
    }
}
