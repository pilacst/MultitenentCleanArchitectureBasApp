using Inoflix.Web.Application.Features.Auth.Queries;
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Application.Contracts.Repository
{
    public interface IAuthRepository
    {
        Task<AuthResponse> Login(AuthQuery auth);
    }
}
