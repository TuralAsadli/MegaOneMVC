using FluentValidation;
using MegaOneMvc.Models;
using MegaOneMvc.ViewModels.Deal;

namespace MegaOneMvc.Utilites.Validators
{
    public class DealValidator : AbstractValidator<CreateDealVM>
    {
        public DealValidator()
        {
            RuleFor(deal => deal.DealName).NotEmpty().NotEmpty().WithMessage("Name cannot be empty")
                .Length(2, 30).WithMessage("Deal Name must be between 2 and 30 characters.");

            RuleFor(deal => deal.Description).NotEmpty().NotEmpty().WithMessage("Description cannot be empty")
                .Length(2, 100).WithMessage("Description must be between 2 and 100 characters.");

            RuleFor(deal => deal.Price).GreaterThanOrEqualTo(0).WithMessage("Price can't be negative");

            RuleFor(category => category.ImgFile).NotNull().WithMessage("Image cannot be empty")
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type is larger than allowed");
        }
    }
}
