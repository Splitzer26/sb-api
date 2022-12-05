using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.City;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.BrandSpecification;
using SBAPI.Application.Specifications.CitySpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CityFeature.Commands.CreateCityCommand
{
    public class CreateCityCommand : IRequest<Response<CityDto>>
    {
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Response<CityDto>>
    {
        public readonly IRepositoryAsync<City> _repositoryAsync;
        public readonly IMapper _mapper;
        public CreateCityCommandHandler(IRepositoryAsync<City> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellation)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterCitySpecification(request.Name, null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe una ciudad con el nombre {request.Name}");
            }
            var newRecord = _mapper.Map<City>(request);
            newRecord.Name = request.Name;
            newRecord.DepartmentId = request.DepartmentId;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<CityDto>(data);
            return new Response<CityDto>(dto, message: $"{data.Name} creado exitosamente");
        }
    }
}
