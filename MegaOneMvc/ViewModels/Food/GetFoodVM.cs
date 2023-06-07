namespace MegaOneMvc.ViewModels.Food
{
    public class GetFoodVM
    {
        public Guid Id { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public string ImgPath { get; set; }
        public Models.Entities.Category Category { get; set; }
    }
}
