using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Commands.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        readonly IBaseRepository<Category> _baseRepository;
        private readonly IWebHostEnvironment _env;

        public DeleteCategoryCommandHandler(IBaseRepository<Category> baseRepository, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _env = env;
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
