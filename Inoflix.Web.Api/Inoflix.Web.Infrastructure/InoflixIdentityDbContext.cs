using Inoflix.Web.Domain.Account;
using Inoflix.Web.Domain.AppLicense;
using Inoflix.Web.Domain.Teanant;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inoflix.Web.Infrastructure
{
    public class InoflixIdentityDbContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRoles,
        int,
        ApplicationUserClaim,
        ApplicationUserRoles,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {

        public InoflixIdentityDbContext()
        {
        }

        public InoflixIdentityDbContext(DbContextOptions<InoflixIdentityDbContext> options) :
            base(options)
        {

        }

        public DbSet<InoflixLicense> InoflixLicenses { get; set; }
        public DbSet<TenantDetails> TenantDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationRoles>().HasData(
               new ApplicationRoles()
               {
                   Id = 1,
                   Name = "Super-Admin",
                   ConcurrencyStamp = "1",
                   NormalizedName = "SUPER-ADMIN"
               },
               new ApplicationRoles()
               {
                   Id = 2,
                   Name = "Tenant-Admin",
                   ConcurrencyStamp = "2",
                   NormalizedName = "TENANT-ADMIN"
               });
        }

    }
}