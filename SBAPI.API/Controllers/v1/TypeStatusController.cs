using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Features.TypeStatusFeature.Commands.CreateTypeStatusCommand;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TypeStatusController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTypeStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
