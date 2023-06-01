using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;
using NuGet.Protocol.Plugins;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MegaOneMvc.Models.Commands.Deals
{
    public class CreateDealCommandHandler : IRequestHandler<CreateDealCommand>
    {
        readonly IBaseRepository<Deal> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CreateDealCommandHandler(IBaseRepository<Deal> baseRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<Unit> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            var deal = _mapper.Map<Deal>(request);
            string imgName = request.ImgFile.RenameImg();
            request.ImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "img", "HoverImgs", imgName));
            deal.ImgPath = imgName;

            await _baseRepository.Create(deal);

            return Unit.Value;
        }
    }
}
