using Inoflix.Web.Application.Features.Users.Command;
using Inoflix.Web.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Application.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role);
    }
}
