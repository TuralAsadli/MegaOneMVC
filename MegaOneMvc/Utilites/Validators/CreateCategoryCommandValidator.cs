using FluentValidation;
using MegaOneMvc.Models.Commands.Categories;

namespace MegaOneMvc.Utilites.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Name cannot be empty")
                .Length(2, 30).WithMessage("Category Name must be between 2 and 30 characters.");

            RuleFor(category => category.ImageFile).NotNull().WithMessage("Image cannot be empty");
                
        }
    }
}
