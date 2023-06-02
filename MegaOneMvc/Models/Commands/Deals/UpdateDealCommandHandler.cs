using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;
using NuGet.Protocol.Plugins;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class UpdateDealCommandHandler : IRequestHandler<UpdateDealCommand>
    {
        readonly IBaseRepository<Deal> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UpdateDealCommandHandler(IBaseRepository<Deal> baseRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<Unit> Handle(UpdateDealCommand request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.FindAsyncById(request.Id);

            if (res.ImgPath != null)
            {
                ImgExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "img", "FoodHoverImg", res.ImgPath));
            }
            res = _mapper.Map<Deal>(request);

            string imgName = request.ImgFile.RenameImg();
            request.ImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "img", "FoodHoverImg", imgName));
            res.ImgPath = imgName;

            await _baseRepository.Update(res);

            return Unit.Value;
        }
    }
}
