using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Queries.Deals
{
    public class GetDealQueryHandler : IRequestHandler<GetDealQuery, GetDealVM>
    {
        readonly IBaseRepository<Deal> _baseRepository;
        private readonly IMapper _mapper;

        public GetDealQueryHandler(IBaseRepository<Deal> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<GetDealVM> Handle(GetDealQuery request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);
            GetDealVM categoryVM = _mapper.Map<GetDealVM>(res);

            return categoryVM;
        }
    }
}
