using MediatR;
using MegaOneMvc.ViewModels.Booking;

namespace MegaOneMvc.Models.Queries.Bookings
{
    public class GetAllBookingQuery : IRequest<IEnumerable<GetBookingVM>>
    {
    }
}
