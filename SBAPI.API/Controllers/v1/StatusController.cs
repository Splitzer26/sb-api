using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Features.StatusFeature.Commands.CreateStatusCommand;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StatusController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
