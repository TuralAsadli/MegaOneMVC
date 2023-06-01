using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Queries.Categories;
using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Models.Entities.Queries.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryVM>
    {
        readonly IBaseRepository<Category> _baseRepository;
        private readonly IMapper _mapper;


        public GetCategoryQueryHandler(IBaseRepository<Category> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<GetCategoryVM> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);
            GetCategoryVM categoryVM = _mapper.Map<GetCategoryVM>(res);

            return categoryVM;
        }
    }
}
