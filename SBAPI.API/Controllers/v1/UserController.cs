using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand;
using SBAPI.Application.Features.UserFeature.Commands.LoginUserCommand;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
