using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.ClientTypeFeature.Commands.CreateClientTypeCommand;
using SBAPI.Application.Features.ClientTypeFeature.Commands.DeleteClientTypeCommand;
using SBAPI.Application.Features.ClientTypeFeature.Commands.UpdateClientTypeCommand;
using SBAPI.Application.Features.ClientTypeFeature.Queries;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientTypeController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateClientTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetClientTypeByIdQuery { Id = id }));
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllClientTypesQuery()));
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClientTypeCommand command)
        {
            if (id != command.Id)
                return BadRequest(new
                {
                    message = "Ocurrio un problema con el id de este regitro"
                });
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClientTypeCommand { Id = id }));
        }
    }
}
