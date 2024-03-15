using Inoflix.Web.Application.Features.Users.Command;
using Inoflix.Web.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Application.Contracts.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role);
    }
}
