using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Booking;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Queries.Bookings
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, GetBookingVM>
    {
        readonly IBaseRepository<Booking> _baseRepository;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(IBaseRepository<Booking> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<GetBookingVM> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await _baseRepository.FindAsyncById(request.Id);
            GetBookingVM getBookingVM = _mapper.Map<GetBookingVM>(booking);

            return getBookingVM;
        }
    }
}
