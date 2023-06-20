using FluentValidation;
using MegaOneMvc.Models.Commands.Bookings;
using MegaOneMvc.Models.Commands.Categories;

namespace MegaOneMvc.Utilites.Validators
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
        {
            RuleFor(book => book.Email).NotEmpty().WithMessage("Email can't be empty").EmailAddress().WithMessage("Incorrect Email");
            RuleFor(book => book.Name).NotEmpty().WithMessage("Name can't be empty").MinimumLength(3).WithMessage("Name must be longer than 2 characters");
            RuleFor(book => book.Date).NotEmpty().WithMessage("Date can't be empty").Must(date => date >= DateTime.Now.Date).WithMessage("Incorrect Time");
            RuleFor(book => book.Hour).NotEmpty().WithMessage("Chose hour");
        }
    }
}
