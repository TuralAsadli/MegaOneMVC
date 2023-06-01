using FluentValidation;
using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Utilites.Validators
{
    public class CategoryValidator : AbstractValidator<CreateCategoryVM>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Name cannot be empty")
                .Length(2, 30).WithMessage("Category Name must be between 2 and 30 characters.");

            RuleFor(category => category.ImageFile).NotNull().WithMessage("Image cannot be empty")
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type is larger than allowed");
        }
    }
}
