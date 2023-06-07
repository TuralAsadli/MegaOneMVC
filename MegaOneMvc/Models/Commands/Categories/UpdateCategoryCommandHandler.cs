using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Commands.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        readonly IBaseRepository<Category> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UpdateCategoryCommandHandler(IBaseRepository<Category> baseRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _env = env;
        }
        async Task<Unit> IRequestHandler<UpdateCategoryCommand, Unit>.Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);

            res = _mapper.Map<Category>(request);

            await _baseRepository.Update(res);

            return Unit.Value;
        }
    }
}
