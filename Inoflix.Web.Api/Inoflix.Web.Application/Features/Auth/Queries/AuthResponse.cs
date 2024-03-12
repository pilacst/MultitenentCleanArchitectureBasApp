using Inoflix.Web.Application.Contracts.RequestResponse;
using Inoflix.Web.Domain.Account;

namespace Inoflix.Web.Application.Features.Auth.Queries
{
    public class AuthResponse : IBaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
        public ApplicationUser user { get; set; }
        public IList<string> Role { get; set; }
    }
}
