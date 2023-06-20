using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Repositories;
using MegaOneMvc.ViewModels.Booking;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Queries.Bookings
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookingQuery,IEnumerable<GetBookingVM>>
    {
        private readonly IBaseRepository<Booking> _repository;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IBaseRepository<Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBookingVM>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetAll();
            List<GetBookingVM> bookingVMs = new List<GetBookingVM>();
            foreach (var item in booking)
            {
                GetBookingVM getBookingVM = _mapper.Map<GetBookingVM>(item);
                bookingVMs.Add(getBookingVM);
            }
            return bookingVMs;
        }
    }
}
