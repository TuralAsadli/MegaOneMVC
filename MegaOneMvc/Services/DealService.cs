using AutoMapper;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;

namespace MegaOneMvc.Services
{
    public class DealService : IDealService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Deal> _db;

        public DealService(IMapper mapper, IBaseRepository<Deal> db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task CreateAsync(CreateDealVM dealVM)
        {
            var category = _mapper.Map<Deal>(dealVM);
            await _db.Create(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            var deal = await _db.FindAsyncById(id);
            await _db.Remove(deal);
        }

        public async Task<IEnumerable<GetDealVM>> GetAll()
        {
            var deals = await _db.GetAsync();
            var DealList = new List<GetDealVM>();
            foreach (var item in deals)
            {
                var deal = _mapper.Map<GetDealVM>(item);
                DealList.Add(deal);
            }
            return DealList;
        }

        public async Task<GetDealVM> GetById(Guid id)
        {
            var res = await _db.FindAsyncById(id);
            var deal = _mapper.Map<GetDealVM>(res);
            return deal;
        }

        public async Task UpdateAsync(Guid id, CreateDealVM city)
        {
            var res = await _db.FindAsyncById(id);
            var deal = _mapper.Map<Deal>(res);
            await _db.Update(deal);
        }
    }
}
