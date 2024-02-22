using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Inoflix.Web.Infrastructure
{
    public class InoflixDbContextFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly TenantConfigOptions _tenant;

        public InoflixDbContextFactory(IHttpContextAccessor httpContextAccessor, 
            IOptions<List<TenantConfigOptions>> tenants)
        {
            var tenentId = httpContextAccessor.HttpContext.Request.Headers["X-TenentId"];
            _tenant = tenants.Value.Where(tenant => tenant.Id.Equals(tenentId)).FirstOrDefault();
            connectionString = _tenant.Value;
        }

        public InoflixDbContext Create() => new(connectionString);
    }
}
