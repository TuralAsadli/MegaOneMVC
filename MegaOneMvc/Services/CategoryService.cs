using AutoMapper;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Utilites.FileExtension;
using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Services
{
    public class CategoryService : ICategoryService
    {
        IBaseRepository<Category> _db;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;

        public CategoryService(IBaseRepository<Category> db, IMapper mapper, IWebHostEnvironment env)
        {
            _db = db;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(CreateCategoryVM categoryVM)
        {
            var category = _mapper.Map<Category>(categoryVM);
            string imgName = categoryVM.ImageFile.RenameImg();
            categoryVM.ImageFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            category.ImgPath = imgName;

            await _db.Create(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _db.FindAsyncById(id);
            if (category.ImgPath != null)
            {
                ImgExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", category.ImgPath));
            }
            await _db.Remove(category);
        }

        public async Task<IEnumerable<GetCategoryVM>> GetAll()
        {
            var categories = await _db.GetAsync();
            var CategoryList = new List<GetCategoryVM>();
            foreach (var item in categories)
            {
                var cateogry = _mapper.Map<GetCategoryVM>(item);
                CategoryList.Add(cateogry);
            }
            return CategoryList;
        }

        public async Task<GetCategoryVM> GetById(Guid id)
        {
            var res = await _db.FindAsyncById(id);
            var category = _mapper.Map<GetCategoryVM>(res);
            return category;
        }

        public async Task UpdateAsync(Guid id, CreateCategoryVM categoryVM)
        {
            var res = await _db.FindAsyncById(id);

            if (res.ImgPath != null)
            {
                ImgExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", res.ImgPath));
            }


            var category = _mapper.Map<Category>(res);
            string imgName = categoryVM.ImageFile.RenameImg();
            categoryVM.ImageFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            category.ImgPath = imgName;

            await _db.Update(category);
        }
    }
}
