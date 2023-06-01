using MediatR;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class DeleteDealCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
