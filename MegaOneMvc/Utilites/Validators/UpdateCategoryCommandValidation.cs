using FluentValidation;
using MegaOneMvc.Models.Commands.Categories;

namespace MegaOneMvc.Utilites.Validators
{
    public class UpdateCategoryCommandValidation : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Name cannot be empty")
                .Length(2, 30).WithMessage("Category Name must be between 2 and 30 characters.");

            RuleFor(category => category.IconName).NotNull().WithMessage("Icon cannot be empty");
        }
    }
}
