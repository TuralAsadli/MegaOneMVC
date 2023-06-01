using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class DeleteDealCommandHandler : IRequestHandler<DeleteDealCommand>
    {
        readonly IBaseRepository<Category> _baseRepository;

        public DeleteDealCommandHandler(IBaseRepository<Category> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Unit> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);
            if (res != null)
            {
                await _baseRepository.Remove(res);
            }

            return Unit.Value;
        }
    }
}
