using Inoflix.Web.Application.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Inoflix.Web.Domain.AppLicense;

namespace Inoflix.Web.Infrastructure.Repositories.InoflixLicenseRepository
{
    public class InoflixLicenceRepository : IInoflixLicenseRepository
    {
        private readonly InoflixDbContext _dbContext;

        public InoflixLicenceRepository(InoflixDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<InoflixLicense>> GetInoflixLicenseAsync(int id)
        {
            return await _dbContext.InoflixLicenses.ToListAsync();
        }
    }
}
