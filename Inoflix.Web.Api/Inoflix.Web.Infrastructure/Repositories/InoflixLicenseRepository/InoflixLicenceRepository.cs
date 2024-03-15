using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Domain.AppLicense;
using Microsoft.EntityFrameworkCore;

namespace Inoflix.Web.Infrastructure.Repositories.InoflixLicenseRepository
{
    public class InoflixLicenceRepository : IInoflixLicenseRepository
    {
        private readonly IInoflixScopedDbContextFactory _factory;
        //private readonly InoflixDbContext _context;

        public InoflixLicenceRepository(
            IInoflixScopedDbContextFactory factory)
        {
            _factory = factory;
            //_context = factory.Create();
        }

        public async Task<IEnumerable<InoflixLicense>> GetInoflixLicenseAsync(int id)
        {
            var _context = _factory.Create();
            var license = await _context.InoflixLicenses.ToListAsync();
            return license;
        }
    }
}

