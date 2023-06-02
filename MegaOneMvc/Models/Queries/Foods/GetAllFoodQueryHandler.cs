using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;
using MegaOneMvc.ViewModels.Food;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Queries.Foods
{
    public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery,IEnumerable<GetFoodVM>>
    {
        readonly IBaseRepository<Food> _baseRepository;
        private readonly IMapper _mapper;

        public GetAllFoodQueryHandler(IBaseRepository<Food> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFoodVM>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.GetAll();
            List<GetFoodVM> categoryVMs = new();
            foreach (var item in res)
            {
                GetFoodVM categoryVM = _mapper.Map<GetFoodVM>(item);
                categoryVMs.Add(categoryVM);
            }

            return categoryVMs;
        }
    }
}
