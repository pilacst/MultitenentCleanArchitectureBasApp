﻿using Inoflix.Web.Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inoflix.Web.Infrastructure
{
    public class InoflixDbContext: IdentityDbContext<
        ApplicationUser, 
        ApplicationRoles, 
        int, 
        ApplicationUserClaim, 
        ApplicationUserRoles, 
        ApplicationUserLogin, 
        ApplicationRoleClaim, 
        ApplicationUserToken>
    {
        public InoflixDbContext()
        {
            
        }
        public InoflixDbContext(DbContextOptions<InoflixDbContext> options) :
            base(options)
        {
        }

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