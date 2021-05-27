using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Server.Models;

namespace RestaurantWebAPI.Server.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}



