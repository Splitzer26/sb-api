using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBAPI.Application.Features.BrandFeature.Commands.CreateBrandCommand;
using SBAPI.Application.Features.BrandFeature.Commands.DeleteBrandCommand;
using SBAPI.Application.Features.BrandFeature.Commands.UpdateBrandCommand;
using SBAPI.Application.Features.BrandFeature.Queries;
using SBAPI.Application.Features.CityFeature.Commands.CreateCityCommand;
using SBAPI.Application.Features.CityFeature.Commands.DeleteCityCommand;
using SBAPI.Application.Features.CityFeature.Commands.UpdateCityCommand;
using SBAPI.Application.Features.CityFeature.Queries;

namespace SBAPI.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CityController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCityByIdQuery { Id = id }));
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCitiesQuery()));
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCityCommand command)
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
            return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }));
        }
    }
}
