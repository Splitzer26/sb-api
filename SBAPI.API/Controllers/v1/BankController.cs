using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.BankFeature.Commands.CreateBankCommand;
using SBAPI.Application.Features.BankFeature.Commands.DeleteBankCommand;
using SBAPI.Application.Features.BankFeature.Commands.UpdateBankCommand;
using SBAPI.Application.Features.BankFeature.Queries;


namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BankController : BaseApiController
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateBankCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBankByIdQuery { Id = id }));
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBanksQuery()));
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBankCommand command)
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
            return Ok(await Mediator.Send(new DeleteBankCommand { Id = id }));
        }
    }
}
