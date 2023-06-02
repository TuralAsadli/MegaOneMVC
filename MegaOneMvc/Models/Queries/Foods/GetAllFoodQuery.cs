using MediatR;
using MegaOneMvc.ViewModels.Food;

namespace MegaOneMvc.Models.Queries.Foods
{
    public class GetAllFoodQuery : IRequest<IEnumerable<GetFoodVM>>
    {
    }
}
