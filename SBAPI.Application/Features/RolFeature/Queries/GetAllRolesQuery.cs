using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Cities;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.RolFeature.Queries
{
    public class GetAllRolesQuery : IRequest<Response<List<RolDto>>>
    {
        public class GetAllRolesQueryHandler: IRequestHandler<GetAllRolesQuery, Response<List<RolDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<Rol> _repositoryAsync;
            public GetAllRolesQueryHandler(IMapper mapper, IRepositoryAsync<Rol> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<RolDto>>> Handle(GetAllRolesQuery reques, CancellationToken cancellationToken)
            {
                var roles = await _repositoryAsync.ListAsync();
                var dto = _mapper.Map<List<RolDto>>(roles);
                return new Response<List<RolDto>>(dto);
            }
        }
    }
}
