using Inoflix.Web.Application.Contracts.RequestResponse;

namespace Inoflix.Web.Application.Features.Users.Command
{
    public record CreateUserResponse : IBaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
