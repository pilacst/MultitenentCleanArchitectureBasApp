using Inoflix.Web.Application.Features.Auth.Queries;

namespace Inoflix.Web.Application.Contracts.Service
{
    public interface IAuthService : IBaseService
    {
        Task<AuthResponse> Login(AuthQuery auth);
    }
}
