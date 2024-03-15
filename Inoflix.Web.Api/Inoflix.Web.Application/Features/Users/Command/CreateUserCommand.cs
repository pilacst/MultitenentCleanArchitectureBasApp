using MediatR;

namespace Inoflix.Web.Application.Features.Users.Command
{
    public record CreateUserCommand: IRequest<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string UserRole { get; set; }
        public string TenantId { get; set; }
    }
}
