using MediatR;

namespace Inoflix.Web.Application.Features.Auth.Queries
{
    public class AuthQuery: IRequest<AuthResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
