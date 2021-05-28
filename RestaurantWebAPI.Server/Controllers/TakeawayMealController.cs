using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Server.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeawayMealController : ControllerBase
    {
        private List<TakeawayMeal> _takeawayMeals = new List<TakeawayMeal>();

        public TakeawayMealController()
        {
            _takeawayMeals.Add(new TakeawayMeal() { Id = 1, Name = "Homemade Pepperoni Pizza", Description = "This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, and tons of pepperoni. The secret to great pepperoni flavor? Hide extra under the cheese! Who needs delivery?", Quantity = 2, Price = 15});
            _takeawayMeals.Add(new TakeawayMeal() { Id = 2, Name = "Lasagna", Description = "This classic lasagna is made with an easy meat sauce as the base. Layer the sauce with noodles and cheese, then bake until bubbly! This is great for feeding a big family, and freezes well, too", Quantity = 5, Price = 32 });
        }

        [HttpGet("{id}")]
        public ActionResult<TakeawayMeal> GetById(int id)
        {
            TakeawayMeal takeawayMeal = _takeawayMeals.SingleOrDefault(p => p.Id == id);
            if (takeawayMeal == null)
            {
                return NotFound();
            }
            return takeawayMeal;
        }

        [HttpPost]
        public ActionResult<TakeawayMeal> Create(TakeawayMeal takeawayMeal)
        {
            int takeawayMealMaxId = _takeawayMeals.Max(t => t.Id);
            takeawayMeal.Id = ++takeawayMealMaxId;
            _takeawayMeals.Add(takeawayMeal);
            return CreatedAtAction(nameof(GetById), new { id = takeawayMeal.Id }, takeawayMeal);
        }
    }
}
