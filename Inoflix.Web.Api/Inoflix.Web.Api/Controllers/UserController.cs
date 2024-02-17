using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Features.Users.Command;
using Microsoft.AspNetCore.Mvc;

namespace Inoflix.Web.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateUserCommand request)
        {

            var result = await _accountService.CreateUserAsync(request);

            return Ok(result);
      
        }
    }
}
