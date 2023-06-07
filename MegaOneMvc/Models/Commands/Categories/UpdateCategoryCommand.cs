using MediatR;
using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Models.Commands.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }
        public string IconName { get; set; }
    }
}
