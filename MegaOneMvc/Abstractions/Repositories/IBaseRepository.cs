using System.Linq.Expressions;

namespace MegaOneMvc.Abstractions.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> FindAsyncById(Guid id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> FindAsyncById(Guid Id, params Expression<Func<TEntity, object>>[] includes);
        Task<IQueryable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
}
