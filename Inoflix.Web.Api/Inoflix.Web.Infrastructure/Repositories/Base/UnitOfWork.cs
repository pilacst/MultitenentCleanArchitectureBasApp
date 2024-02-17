using Inoflix.Web.Application.Contracts.Repository;

namespace Inoflix.Web.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitIOfWork
    {
        private readonly InoflixDbContext _dbContext;

        public UnitOfWork(InoflixDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CommitAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
