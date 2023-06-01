using MegaOneMvc.ViewModels.Deal;
using MegaOneMvc.ViewModels.Food;

namespace MegaOneMvc.Abstractions.Services
{
    public interface IDealService
    {
        Task<GetDealVM> GetById(Guid id);
        Task<IEnumerable<GetDealVM>> GetAll();
        Task CreateAsync(CreateDealVM city);
        Task UpdateAsync(Guid id, CreateDealVM city);
        Task DeleteAsync(Guid id);
    }
}
