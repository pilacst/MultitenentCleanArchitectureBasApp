using Inoflix.Web.Application.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Inoflix.Web.Domain.AppLicense;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

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
            try
            {
                return await _dbContext.InoflixLicenses.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
