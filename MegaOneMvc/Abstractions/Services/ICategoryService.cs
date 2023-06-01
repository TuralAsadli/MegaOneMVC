using MegaOneMvc.ViewModels.Category;

namespace MegaOneMvc.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryVM> GetById(Guid id);
        Task<IEnumerable<GetCategoryVM>> GetAll();
        Task CreateAsync(CreateCategoryVM Category);
        Task UpdateAsync(Guid id, CreateCategoryVM Category);
        Task DeleteAsync(Guid id);
    }
}
