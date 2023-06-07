using FluentValidation;
using MegaOneMvc.Models.Commands.Foods;

namespace MegaOneMvc.Utilites.Validators
{
    public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
    {
        public UpdateFoodCommandValidator()
        {
            RuleFor(deal => deal.FoodName).NotEmpty().NotEmpty().WithMessage("Name cannot be empty")
                .Length(2, 30).WithMessage("Deal Name must be between 2 and 30 characters.");

            RuleFor(deal => deal.Description).NotEmpty().NotEmpty().WithMessage("Description cannot be empty")
                .Length(2, 100).WithMessage("Description must be between 2 and 100 characters.");

            RuleFor(deal => deal.Price).GreaterThanOrEqualTo(0).WithMessage("Price can't be negative");

            RuleFor(category => category.ImgFile).NotNull().WithMessage("Image cannot be empty");
        }
    }
}
