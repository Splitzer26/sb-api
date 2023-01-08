using MediatR;
using Microsoft.AspNetCore.Mvc;

using SBAPI.Application.Features.CompanyFeature.Commands.UpdateCompanyCommand;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CompanyController : BaseApiController
    {
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyCommand command)
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
