namespace MegaOneMvc.ViewModels.Food
{
    public class CreateFoodVM
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile ImgPath { get; set; }
        

    }
}
