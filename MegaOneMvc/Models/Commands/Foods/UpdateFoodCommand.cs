using MediatR;

namespace MegaOneMvc.Models.Commands.Foods
{
    public class UpdateFoodCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
