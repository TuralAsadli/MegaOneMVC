using MediatR;
using MegaOneMvc.Models;

namespace MegaOneMvc.Models.Commands.Categories
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }
        public string IconName { get; set; }
    }
}
