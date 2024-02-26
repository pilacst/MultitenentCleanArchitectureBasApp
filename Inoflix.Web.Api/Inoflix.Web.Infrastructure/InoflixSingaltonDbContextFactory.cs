using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Inoflix.Web.Infrastructure
{
    public class InoflixSingaltonDbContextFactory: IInoflixSingletonDbContextFactory
    {
        private readonly string connectionString;
        private readonly TenantConfigOptions _tenant;
        private InoflixDbContext _context;
        private static readonly object contextLock = new();

        public InoflixSingaltonDbContextFactory(IHttpContextAccessor httpContextAccessor,
            IOptions<List<TenantConfigOptions>> tenants)
        {
            var tenentId = httpContextAccessor?.HttpContext?.Request.Headers["X-TenentId"];
            _tenant = tenants.Value.Where(tenant => tenant.Id.Equals(tenentId)).FirstOrDefault();
            connectionString = _tenant.Value;
        }

        public InoflixDbContext Create()
        {
            if (_context == null)
            {
                lock(contextLock)
                {
                    _context ??= new InoflixDbContext(connectionString);
                }
            }
            return _context;
        }
    }
}
