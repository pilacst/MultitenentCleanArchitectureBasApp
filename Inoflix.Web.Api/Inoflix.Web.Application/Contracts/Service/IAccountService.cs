using Inoflix.Web.Application.Features.Users.Command;

namespace Inoflix.Web.Application.Contracts.Service
{
    public interface IAccountService: IBaseService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserCommand request);
        bool TestMethod();
    }
}
