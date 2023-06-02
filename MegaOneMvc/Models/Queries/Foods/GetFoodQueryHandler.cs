using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Food;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Queries.Foods
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, GetFoodVM>
    {
        readonly IBaseRepository<Deal> _baseRepository;
        private readonly IMapper _mapper;

        public GetFoodQueryHandler(IBaseRepository<Deal> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<GetFoodVM> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var item = await _baseRepository.FindAsyncById(request.Id);
            GetFoodVM foodVM = _mapper.Map<GetFoodVM>(item);

            return foodVM;
        }
    }
}
