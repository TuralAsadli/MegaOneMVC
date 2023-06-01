using MegaOneMvc.ViewModels.Food;

namespace MegaOneMvc.Abstractions.Services
{
    public interface IFoodService
    {
        Task<GetFoodVM> GetById(Guid id);
        Task<IEnumerable<GetFoodVM>> GetAll();
        Task CreateAsync(CreateFoodVM city);
        Task UpdateAsync(Guid id, CreateFoodVM city);
        Task DeleteAsync(Guid id);
    }
}
