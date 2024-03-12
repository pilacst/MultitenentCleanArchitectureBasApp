using Inoflix.Web.Domain.Account;

namespace Inoflix.Web.Application.Contracts.Service
{
    public interface ITokenService : IBaseService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles);
    }
}
