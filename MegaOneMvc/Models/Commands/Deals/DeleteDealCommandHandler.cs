using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class DeleteDealCommandHandler : IRequestHandler<DeleteDealCommand>
    {
        readonly IBaseRepository<Category> _baseRepository;
        private readonly IWebHostEnvironment _env;

        public DeleteDealCommandHandler(IBaseRepository<Category> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Unit> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);
            if (res != null)
            {
                ImgExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "img", "HoverImg", res.ImgPath));
                await _baseRepository.Remove(res);
            }

            return Unit.Value;
        }
    }
}
