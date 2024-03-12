using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountRepository(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role)
        {
            var userExists = await _userManager.FindByNameAsync(user.UserName);

            if(userExists is null)
            {
                var result = await _userManager.CreateAsync(user, password);

                if(result.Succeeded)
                    await _userManager.AddToRoleAsync(user, role);

                return result;
            }

            return IdentityResult.Failed(new IdentityError
            {
                Description = "User already exisit"
            });
        }
    }
}
