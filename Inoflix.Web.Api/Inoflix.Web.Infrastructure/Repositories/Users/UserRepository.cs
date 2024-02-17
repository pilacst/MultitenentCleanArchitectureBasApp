using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
