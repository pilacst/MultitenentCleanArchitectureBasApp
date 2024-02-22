using Inoflix.Web.Application.Contracts.Service;
using Microsoft.AspNetCore.Mvc;

namespace Inoflix.Web.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IInoflixLicenseService _inoflixLicenseService;

        public AuthController(IInoflixLicenseService inoflixLicenseService)
        {
            _inoflixLicenseService = inoflixLicenseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var licnese = await _inoflixLicenseService.GetLicenseAsync();
            return Ok();
        }
    }
}
