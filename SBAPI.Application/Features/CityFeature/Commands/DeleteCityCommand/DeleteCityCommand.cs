using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CityFeature.Commands.DeleteCityCommand
{
    public class DeleteCityCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Response<string>>
    {
        private readonly IRepositoryAsync<City> _repositoryAsync;
        public DeleteCityCommandHandler(IRepositoryAsync<City> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repositoryAsync.GetByIdAsync(request.Id);
            if (city != null)
            {
                await _repositoryAsync.DeleteAsync(city);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{city.Name} eliminada correctamente", "Eliminada correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
