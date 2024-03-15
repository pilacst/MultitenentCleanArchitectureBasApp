
using Microsoft.AspNetCore.Identity;

namespace Inoflix.Web.Domain.Account
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string TenantId { get; set; } = null!;
    }
}
