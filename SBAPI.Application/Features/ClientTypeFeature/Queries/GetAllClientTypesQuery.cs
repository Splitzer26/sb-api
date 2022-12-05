using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.ClientType;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.ClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.ClientTypeFeature.Queries
{
    public class GetAllClientTypesQuery : IRequest<Response<List<ClientTypeDto>>>
    {
        public class GetAllClientTypesQueryHandler : IRequestHandler<GetAllClientTypesQuery, Response<List<ClientTypeDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<ClientType> _repositoryAsync;
            public GetAllClientTypesQueryHandler(IMapper mapper, IRepositoryAsync<ClientType> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<ClientTypeDto>>> Handle(GetAllClientTypesQuery request, CancellationToken cancellationToken)
            {
                var clientTypes = await _repositoryAsync.ListAsync();
                var dto = _mapper.Map<List<ClientTypeDto>>(clientTypes);
                return new Response<List<ClientTypeDto>>(dto);
            }
        }
    }
}
