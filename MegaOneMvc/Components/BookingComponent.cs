using MediatR;
using MegaOneMvc.DAL;
using MegaOneMvc.Models.Commands.Bookings;
using Microsoft.AspNetCore.Mvc;

namespace MegaOneMvc.Components
{
    public class BookingComponent : ViewComponent
    {
        private IMediator _mediator;

        public BookingComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
        


    }
}
