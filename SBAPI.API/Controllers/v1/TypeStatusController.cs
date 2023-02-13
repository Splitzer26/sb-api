using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Features.RolFeature.Commands.DeleteRolCommand;
using SBAPI.Application.Features.RolFeature.Queries;
using SBAPI.Application.Features.TypeStatusFeature.Commands.CreateTypeStatusCommand;
using SBAPI.Application.Features.TypeStatusFeature.Commands.DeleteTypeStatusCommand;
using SBAPI.Application.Features.TypeStatusFeature.Queries;

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
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetTypeStatusByIdQuery { Id = id }));
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTypeStatusQuery()));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTypeStatusCommand { Id = id }));
        }
    }
}
