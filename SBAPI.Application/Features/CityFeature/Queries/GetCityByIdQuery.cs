using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.City;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.CitySpecification;
using SBAPI.Application.Specifications.StatusSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CityFeature.Queries
{
    public class GetCityByIdQuery : IRequest<Response<CityDto>>
    {
        public int Id { get; set; }
    }
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, Response<CityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<City> _repositoryAsync;
        public GetCityByIdQueryHandler(IMapper mapper, IRepositoryAsync<City> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<CityDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _repositoryAsync.GetByIdAsync(new CityIncludesSpecification(id: request.Id));
            if (city != null)
            {
                var dto = _mapper.Map<CityDto>(city);
                return new Response<CityDto>(dto);
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }
}
