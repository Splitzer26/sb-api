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
    public class GetAllCitiesQuery : IRequest<Response<List<CityDto>>>
    {
        public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, Response<List<CityDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<City> _repositoryAsync;
            public GetAllCitiesQueryHandler(IMapper mapper, IRepositoryAsync<City> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<CityDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
            {
                var cities = await _repositoryAsync.ListAsync(new CityIncludesSpecification(null));
                var dto = _mapper.Map<List<CityDto>>(cities);
                return new Response<List<CityDto>>(dto);
            }
        }
    }
}
