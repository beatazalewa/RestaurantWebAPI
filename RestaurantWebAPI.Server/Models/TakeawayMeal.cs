namespace RestaurantWebAPI.Server.Models
{
    public class TakeawayMeal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
