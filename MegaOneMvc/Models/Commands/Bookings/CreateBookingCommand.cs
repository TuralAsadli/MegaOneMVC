using MediatR;

namespace MegaOneMvc.Models.Commands.Bookings
{
    public class CreateBookingCommand : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }
}
