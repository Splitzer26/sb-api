using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.TypeStatus;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.TypeStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Queries
{
    public class GetAllTypeStatusQuery : IRequest<Response<List<TypeStatusDto>>>
    {
        public class GetAllTypeStatusQueryHandler : IRequestHandler<GetAllTypeStatusQuery, Response<List<TypeStatusDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<TypeStatus> _repositoryAsync;
            public GetAllTypeStatusQueryHandler(IMapper mapper, IRepositoryAsync<TypeStatus> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<TypeStatusDto>>> Handle(GetAllTypeStatusQuery request, CancellationToken cancellationToken)
            {
                var roles = await _repositoryAsync.ListAsync();
                var dto = _mapper.Map<List<TypeStatusDto>>(roles);
                return new Response<List<TypeStatusDto>>(dto);
            }
        }
    }
}
