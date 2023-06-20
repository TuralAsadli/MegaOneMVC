using MediatR;

namespace MegaOneMvc.Models.Commands.Bookings
{
    public class UpdateBookingCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }
}
