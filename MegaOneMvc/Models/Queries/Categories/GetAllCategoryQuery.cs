using MediatR;
using MegaOneMvc.ViewModels.Category;


namespace MegaOneMvc.Models.Queries.Categories
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<GetCategoryVM>>
    {

    }
}
