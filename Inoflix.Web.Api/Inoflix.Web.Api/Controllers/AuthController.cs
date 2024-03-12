using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Features.Auth.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Inoflix.Web.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IInoflixLicenseService _inoflixLicenseService;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IInoflixLicenseService inoflixLicenseService,
            IAuthService authService,
            ITokenService tokenService)
        {
            _inoflixLicenseService = inoflixLicenseService;
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var licnese = await _inoflixLicenseService.GetLicenseAsync();
            return Ok(licnese);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthQuery user)
        {
            var authResult = await _authService.Login(user);
            if (authResult.IsSuccess)
            {
                var token = await _tokenService.GenerateTokenAsync(authResult.user, authResult.Role);
                return Ok(token);
            }
            return Ok(authResult);
        }
    }
}
