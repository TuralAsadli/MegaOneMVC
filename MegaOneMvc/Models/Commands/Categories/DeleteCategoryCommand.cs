using MediatR;

namespace MegaOneMvc.Models.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
