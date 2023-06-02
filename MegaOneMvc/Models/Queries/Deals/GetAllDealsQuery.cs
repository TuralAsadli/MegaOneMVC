using MediatR;
using MegaOneMvc.ViewModels.Deal;

namespace MegaOneMvc.Models.Queries.Deals
{
    public class GetAllDealsQuery : IRequest<IEnumerable<GetDealVM>>
    {

    }
}
