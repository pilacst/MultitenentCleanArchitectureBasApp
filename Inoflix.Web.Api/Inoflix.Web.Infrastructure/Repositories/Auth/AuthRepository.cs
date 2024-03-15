using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Application.Features.Auth.Queries;
using Inoflix.Web.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Infrastructure.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthResponse> Login(AuthQuery auth)
        {
            var user = await _userManager.FindByNameAsync(auth.UserName);
            var isValidPassword = await _userManager.CheckPasswordAsync(user, auth.Password);

            if (user is null)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Messages = new List<string> { "Username or the pasword entered in incorrect." }
                };

            if(!isValidPassword)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Messages = new List<string> { "Username or the pasword entered in incorrect." }
                };

            var userRoles = await _userManager.GetRolesAsync(user);

            return new AuthResponse
            {
                IsSuccess = true,
                Messages = new List<string> { "User login successfull." },
                user = user,
                Role = userRoles
            };
        }
    }
}
