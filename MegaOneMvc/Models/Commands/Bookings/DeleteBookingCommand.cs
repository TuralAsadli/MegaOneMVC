using MediatR;

namespace MegaOneMvc.Models.Commands.Bookings
{
    public class DeleteBookingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
