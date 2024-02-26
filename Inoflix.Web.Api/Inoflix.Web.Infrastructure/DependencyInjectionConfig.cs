using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Domain.User;
using Inoflix.Web.Infrastructure.Repositories;
using Inoflix.Web.Infrastructure.Repositories.Base;
using Inoflix.Web.Infrastructure.Repositories.InoflixLicenseRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Inoflix.Web.Infrastructure
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
        {
            services.Configure<List<TenantConfigOptions>>(
                config.GetSection(TenantConfigOptions.Tenants));
            services.AddDbContext<InoflixDbContext>();

            services.AddSingleton<IInoflixSingletonDbContextFactory, InoflixSingaltonDbContextFactory>();
            services.AddScoped<IInoflixScopedDbContextFactory, InoflixScopedDbContextFactory>();

            services.AddIdentity<ApplicationUser, ApplicationRoles>()
               .AddEntityFrameworkStores<InoflixDbContext>()
               .AddDefaultTokenProviders();

            //services.AddDbContext<InoflixDbContext>(
            //     options => options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            // );

            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JWT:ValidIssuer"],
                    ValidAudience = config["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddScoped<IUnitIOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInoflixLicenseRepository, InoflixLicenceRepository>();

            return services;
        }
    }
}
