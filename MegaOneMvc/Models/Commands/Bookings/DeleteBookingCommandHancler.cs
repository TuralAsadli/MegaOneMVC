using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Repositories;

namespace MegaOneMvc.Models.Commands.Bookings
{
    public class DeleteBookingCommandHancler : IRequestHandler<DeleteBookingCommand>
    {
        private readonly IBaseRepository<Booking> _repository;

        public DeleteBookingCommandHancler(IBaseRepository<Booking> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var res = await _repository.FindAsyncById(request.Id);
            if (res != null)
            {
                await _repository.Remove(res);
            }

            return Unit.Value;
        }
    }
}
