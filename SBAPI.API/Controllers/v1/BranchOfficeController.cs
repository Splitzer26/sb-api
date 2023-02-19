using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.BankFeature.Commands.UpdateBankCommand;
using SBAPI.Application.Features.BranchOfficeFeature.Commands.CreateBranchOfficeCommand;
using SBAPI.Application.Features.BranchOfficeFeature.Commands.UpdateBranchOfficeCommand;
using SBAPI.Application.Features.BranchOfficeFeature.Queries;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BranchOfficeController : BaseApiController
	{
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateBranchOfficeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBranchOfficeByIdQuery { Id = id }));
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBrachOfficesQuery()));
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBranchOfficeCommand command)
        {
            if (id != command.Id)
                return BadRequest(new
                {
                    message = "Ocurrio un problema con el id de este regitro"
                });
            return Ok(await Mediator.Send(command));
        }
    }
}

