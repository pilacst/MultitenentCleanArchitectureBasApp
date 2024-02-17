using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Inoflix.Web.Application.Contracts.Repository
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> condition);
        Task<IList<TEntity>> ListAllAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> condition, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> condition);
    }
}
