using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.DAL;
using MegaOneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegaOneMvc.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseItem
    {
        AppDbContext _context;
        DbSet<TEntity> _dbSet;


        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        
        public async Task Create(TEntity item)
        {
            _dbSet.Add(item);
            await Save();
        }

        public async Task<TEntity> FindAsyncById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> FindAsyncById(Guid Id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault(e => e.Id == Id);
        }

        public async Task<IQueryable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task Remove(TEntity item)
        {
            _dbSet.Remove(item);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await Save();
        }

        
    }
}
