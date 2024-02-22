using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Domain.AppLicense;
using Microsoft.EntityFrameworkCore;

namespace Inoflix.Web.Infrastructure.Repositories.InoflixLicenseRepository
{
    public class InoflixLicenceRepository : IInoflixLicenseRepository
    {
        private readonly InoflixDbContext _dbContext;

        public InoflixLicenceRepository(
            InoflixDbContextFactory factory)
        {
            _dbContext = factory.Create();
        }

        public async Task<IEnumerable<InoflixLicense>> GetInoflixLicenseAsync(int id)
        {
            var license = await _dbContext.InoflixLicenses.ToListAsync();
            return license;
        }
    }
}
