﻿using AutoMapper;
using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;

namespace MegaOneMvc.Models.Commands.Foods
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand>
    {
        readonly IBaseRepository<Deal> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
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