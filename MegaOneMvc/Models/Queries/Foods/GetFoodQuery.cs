using MediatR;
using MegaOneMvc.ViewModels.Food;

namespace MegaOneMvc.Models.Queries.Foods
{
    public class GetFoodQuery : IRequest<GetFoodVM>
    {
        public Guid Id { get; set; }
    }
}
