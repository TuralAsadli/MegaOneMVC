using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Repositories;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Commands.Bookings
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly IBaseRepository<Booking> _repository;
        private readonly IMapper _mapper;
        public CreateBookingCommandHandler(IBaseRepository<Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking =  _mapper.Map<Booking>(request);
            

            await _repository.Create(booking);
            return Unit.Value;
        }
    }
}
