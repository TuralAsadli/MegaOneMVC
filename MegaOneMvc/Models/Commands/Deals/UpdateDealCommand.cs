using MediatR;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class UpdateDealCommand : IRequest
    {
        public Guid Id { get; set; }
        public string DealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
