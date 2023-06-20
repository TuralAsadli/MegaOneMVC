using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Repositories;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Commands.Bookings
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
    {
        private readonly IBaseRepository<Booking> _repository;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IBaseRepository<Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var res = await _repository.FindAsyncById(request.Id);

            res = _mapper.Map<Booking>(request);

            await _repository.Update(res);

            return Unit.Value;
        }
    }
}
