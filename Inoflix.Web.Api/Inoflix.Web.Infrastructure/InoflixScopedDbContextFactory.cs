using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Inoflix.Web.Infrastructure
{
    public class InoflixScopedDbContextFactory: IInoflixScopedDbContextFactory
    {
        private readonly string connectionString;
        private readonly TenantConfigOptions _tenant;

        public InoflixScopedDbContextFactory(IHttpContextAccessor httpContextAccessor,
            IOptions<List<TenantConfigOptions>> tenants)
        {
            var tenentId = httpContextAccessor?.HttpContext?.Request.Headers["X-TenentId"];
            _tenant = tenants.Value.Where(tenant => tenant.Id.Equals(tenentId)).FirstOrDefault();
            connectionString = _tenant.Value;
        }

        public InoflixDbContext Create()
        {
            InoflixDbContext _context = new(connectionString);
            return _context;
        }
    }
}
