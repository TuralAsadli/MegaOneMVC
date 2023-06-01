using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.ViewModels.Category;


namespace MegaOneMvc.Models.Queries.Categories
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<GetCategoryVM>>
    {
        
    }
}
