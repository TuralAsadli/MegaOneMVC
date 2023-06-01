using AutoMapper;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Deal;
using MegaOneMvc.ViewModels.Food;

namespace MegaOneMvc.Services
{
    public class FoodService : IFoodService
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<Deal> _db;

        public FoodService(IMapper mapper, IBaseRepository<Deal> db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task CreateAsync(CreateFoodVM foodVM)
        {
            var food = _mapper.Map<Deal>(foodVM);
            await _db.Create(food);
        }

        public async Task DeleteAsync(Guid id)
        {
            var food = await _db.FindAsyncById(id);
            await _db.Remove(food);
        }

        public async Task<IEnumerable<GetFoodVM>> GetAll()
        {
            var Foods = await _db.GetAsync();
            var FoodList = new List<GetFoodVM>();
            foreach (var item in Foods)
            {
                var food = _mapper.Map<GetFoodVM>(item);
                FoodList.Add(food);
            }
            return FoodList;
        }

        public async Task<GetFoodVM> GetById(Guid id)
        {
            var res = await _db.FindAsyncById(id);
            var food = _mapper.Map<GetFoodVM>(res);
            return food;
        }

        public async Task UpdateAsync(Guid id, CreateFoodVM city)
        {
            var res = await _db.FindAsyncById(id);
            var food = _mapper.Map<Deal>(res);
            await _db.Update(food);
        }
    }
}
