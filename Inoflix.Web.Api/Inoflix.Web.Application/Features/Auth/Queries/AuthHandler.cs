using Inoflix.Web.Application.Contracts.Repository;
using MediatR;

namespace Inoflix.Web.Application.Features.Auth.Queries
{
    public record AuthHandler : IRequestHandler<AuthQuery, AuthResponse>
    {
        private readonly IAuthRepository _authRepository;
        public AuthHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<AuthResponse> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            return _authRepository.Login(request);
        }
    }
}
