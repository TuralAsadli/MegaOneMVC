using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Models.Queries.Categories
{
    public class GetAllCategoryQueryHandle : IRequestHandler<GetAllCategoryQuery, IEnumerable<GetCategoryVM>>
    {
        readonly IBaseRepository<Category> _baseRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandle(IBaseRepository<Category> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetCategoryVM>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.GetAll(c => c.Foods);
            List<GetCategoryVM> categoryVMs = new();
            foreach (var item in res)
            {
                GetCategoryVM categoryVM = _mapper.Map<GetCategoryVM>(item);
                categoryVMs.Add(categoryVM);
            }

            return categoryVMs;
        }
    }
}
