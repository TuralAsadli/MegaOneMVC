using MediatR;

namespace MegaOneMvc.Models.Commands.Foods
{
    public class DeleteFoodCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
