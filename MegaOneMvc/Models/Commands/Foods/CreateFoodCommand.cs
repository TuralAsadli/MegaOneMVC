using MediatR;
using MegaOneMvc.Models.Entities;

namespace MegaOneMvc.Models.Commands.Foods
{
    public class CreateFoodCommand : IRequest
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile ImgFile { get; set; }
        
    }
}
