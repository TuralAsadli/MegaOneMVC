using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Commands.Foods
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand>
    {
        readonly IBaseRepository<Food> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CreateFoodCommandHandler(IBaseRepository<Food> baseRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<Unit> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = _mapper.Map<Food>(request);
            string imgName = request.ImgFile.RenameImg();
            request.ImgFile.CropImgAndSave(Path.Combine(_env.WebRootPath, "img", "FoodHoverImgs", imgName));
            food.ImgPath = imgName;

            await _baseRepository.Create(food);

            return Unit.Value;
        }
    }
}
