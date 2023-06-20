using MediatR;
using MegaOneMvc.ViewModels.Booking;

namespace MegaOneMvc.Models.Queries.Bookings
{
    public class GetBookingQuery : IRequest<GetBookingVM>
    {
        public Guid Id { get; set; }
    }
}
