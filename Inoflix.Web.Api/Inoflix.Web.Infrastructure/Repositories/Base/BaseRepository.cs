using Inoflix.Web.Application.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Inoflix.Web.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
    {
        private readonly InoflixDbContext _dbContext;
        protected DbSet<TEntity> Entities { get; }

        public BaseRepository(InoflixDbContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();   
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await Entities.AddAsync(entity);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> condition)
        {
            var result = await _dbContext.Set<TEntity>().Where(condition).ExecuteDeleteAsync();

            return result > 0;
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> condition)
        {
            var result = await _dbContext.Set<TEntity>().Where(condition).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IList<TEntity>> ListAllAsync(Expression<Func<TEntity, bool>> condition)
        {
            var result = await _dbContext.Set<TEntity>().Where(condition).ToListAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> condition, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression)
        {
            
            var result = await _dbContext.Set<TEntity>().Where(condition).ExecuteUpdateAsync(expression);
            return result > 0;
        }
    }
}
