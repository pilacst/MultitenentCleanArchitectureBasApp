using Inoflix.Web.Domain.AppLicense;
using Inoflix.Web.Domain.Teanant;
using Microsoft.EntityFrameworkCore;

namespace Inoflix.Web.Infrastructure
{
    public class InoflixDbContext: DbContext
    {
        private readonly string _connectionString;

        public InoflixDbContext()
        {
        }

        public InoflixDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<InoflixLicense> InoflixLicenses { get; set; }
        public DbSet<TenantDetails> TenantDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

    }
}