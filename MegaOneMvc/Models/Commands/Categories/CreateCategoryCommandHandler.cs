using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Commands.Categories;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Entities.Commands.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        readonly IBaseRepository<Category> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CreateCategoryCommandHandler(IBaseRepository<Category> baseRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<Unit> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(command);
            string imgName = command.ImageFile.RenameImg();
            command.ImageFile.CreateImgFile(Path.Combine(_env.WebRootPath, "img", "HoverImgs", imgName));
            category.ImgPath = imgName;

            await _baseRepository.Create(category);

            return Unit.Value;
        }
    }
}
