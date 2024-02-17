using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Domain.User;
using MediatR;

namespace Inoflix.Web.Application.Features.Users.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _user;

        public CreateUserCommandHandler(IUserRepository user)
        {
            _user = user;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            ApplicationUser applicationUser = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.MobileNumber ?? null
            };

            var result = await _user.CreateAsync(applicationUser, request.Password, request.UserRole);

            return new CreateUserResponse
            {
                Messages = new List<string> { "Simple message temporarry" },
                IsSuccess = result.Succeeded
            };
        }
    }
}
