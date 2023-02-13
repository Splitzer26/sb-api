using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.City;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.CitySpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Cities;


namespace SBAPI.Application.Features.CityFeature.Commands.UpdateCityCommand
{
    public class UpdateCityCommand : IRequest<Response<CityDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
    }
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Response<CityDto>>
    {
        private readonly IRepositoryAsync<City> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateCityCommandHandler(IRepositoryAsync<City> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<CityDto>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repositoryAsync.GetByIdAsync(request.Id);
            if (city != null)
            {
                var filterByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterCitySpecification(request.Name, request.Id));
                if (filterByName != null)
                {
                    throw new ApiException($"Ya existe una ciudad con el nombre {request.Name}");
                }
                else
                {
                    city.Name = request.Name;
                    city.DepartmentId = request.DepartmentId;
                    await _repositoryAsync.UpdateAsync(city);
                    await _repositoryAsync.SaveChangesAsync();
                    var dto = _mapper.Map<CityDto>(city);
                    return new Response<CityDto>(dto, message: $"{city.Name} actualizado correctamente");
                }
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id} para actualizar.");
            }
        }
    }
}
