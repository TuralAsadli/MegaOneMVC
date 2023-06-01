using MediatR;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class CreateDealCommand : IRequest
    {
        public string DealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
