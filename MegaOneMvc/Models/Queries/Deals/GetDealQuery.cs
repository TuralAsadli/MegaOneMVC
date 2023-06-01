using MediatR;
using MegaOneMvc.ViewModels.Deal;

namespace MegaOneMvc.Models.Queries.Deals
{
    public class GetDealQuery : IRequest<GetDealVM>
    {
        public Guid Id { get; set; }
    }
}
