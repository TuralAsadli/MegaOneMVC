using MediatR;
using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Models.Queries.Categories
{
    public class GetCategoryQuery : IRequest<GetCategoryVM>
    {
        public Guid Id { get; set; }

    }
}
