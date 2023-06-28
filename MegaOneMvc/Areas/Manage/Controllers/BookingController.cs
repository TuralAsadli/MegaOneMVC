using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Commands.Bookings;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Models.Queries.Bookings;
using MegaOneMvc.Utilites.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaOneMvc.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBaseRepository<Booking> _repository;
        private readonly IMediator _mediator;

        public BookingController(IBaseRepository<Booking> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new GetAllBookingQuery());
            return View(res);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var res = await _mediator.Send(new GetBookingQuery() { Id = id });
            UpdateBookingCommand updateBooking = new UpdateBookingCommand()
            {
                Date = res.Date,
                Email = res.Email,
                Hour = res.Hour,
                Id = id,
                Name = res.Name
            };
            return View(updateBooking);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateBookingCommand updateBooking)
        {
            UpdateBookingCommandValidator validator = new UpdateBookingCommandValidator();
            var res = validator.Validate(updateBooking);
            if (!res.IsValid)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(updateBooking);
            }

            updateBooking.Id = id;

            await _mediator.Send(updateBooking);

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            var res = await _mediator.Send(new DeleteBookingCommand() { Id = id});
            return RedirectToAction(nameof(Index));
        }
    }
}
