using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;

namespace MegaOneMvc.Models.Commands.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        readonly IBaseRepository<Category> _baseRepository;
        

        public DeleteCategoryCommandHandler(IBaseRepository<Category> baseRepository)
        {
            _baseRepository = baseRepository;
            
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
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
