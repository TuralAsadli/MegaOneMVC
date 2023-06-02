using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Queries.Deals
{
    public class GetAllQueryHandler : IRequestHandler<GetAllDealsQuery, IEnumerable<GetDealVM>>
    {
        readonly IBaseRepository<Deal> _baseRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IBaseRepository<Deal> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDealVM>> Handle(GetAllDealsQuery request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.GetAll();
            List<GetDealVM> deals = new();
            foreach (var item in res)
            {
                GetDealVM deal = _mapper.Map<GetDealVM>(item);
                deals.Add(deal);
            }

            return deals;
        }
    }
}
