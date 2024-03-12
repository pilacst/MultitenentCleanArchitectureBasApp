using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Helpers;
using Inoflix.Web.Domain.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inoflix.Web.Application.Services
{
    [InoflixDIRegistyService(typeof(ITokenService), LifetimeOfService.Scoped)]
    public class TokenService : ITokenService
    {
        private readonly TokenConfigOptions _tokenConfigOptions;
        public TokenService(IOptions<TokenConfigOptions> config)
        {
            _tokenConfigOptions = config.Value;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles)
        {
            var claims = new[]
               {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("roles", string.Join(",", roles))
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigOptions.Secret));

            var token = new JwtSecurityToken(
                   _tokenConfigOptions.ValidIssuer,
                   _tokenConfigOptions.ValidAudience,
                   claims,
                   expires: DateTime.UtcNow.AddMinutes(_tokenConfigOptions.ExpirationInMin),
                   signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            // Generate a token string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
