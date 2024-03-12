using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Features.Auth.Queries;
using Inoflix.Web.Application.Helpers;
using MediatR;

namespace Inoflix.Web.Application.Services
{
    [InoflixDIRegistyService(typeof(IAuthService), LifetimeOfService.Scoped)]
    public class AuthService : IAuthService
    {
        private readonly IMediator _mediator;

        public AuthService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<AuthResponse> Login(AuthQuery auth)
        {
            return _mediator.Send(auth);
        }
    }
}
