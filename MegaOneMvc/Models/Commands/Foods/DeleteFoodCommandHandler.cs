using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Commands.Foods
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
    {
        readonly IBaseRepository<Food> _baseRepository;
        private readonly IWebHostEnvironment _env;

        public DeleteFoodCommandHandler(IBaseRepository<Food> baseRepository, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _env = env;
        }

        public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);
            if (res != null)
            {
                ImgExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "img", "FoodHoverImg", res.ImgPath));
                await _baseRepository.Remove(res);
            }

            return Unit.Value;
        }
    }
}
