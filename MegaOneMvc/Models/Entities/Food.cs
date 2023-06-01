namespace MegaOneMvc.Models.Entities
{
    public class Food : BaseItem
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
