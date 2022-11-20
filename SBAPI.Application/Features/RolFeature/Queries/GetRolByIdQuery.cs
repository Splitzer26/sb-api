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
    public class GetRolByIdQuery : IRequest<Response<RolDto>>
    {
        public int Id { get; set; }
    }
    public class GetRolByIdQueryHandler : IRequestHandler<GetRolByIdQuery, Response<RolDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Rol> _repositoryAsync;

        public GetRolByIdQueryHandler(IMapper mapper, IRepositoryAsync<Rol> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<RolDto>> Handle(GetRolByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _repositoryAsync.GetByIdAsync(request.Id);
            if (role != null)
            {
                var dto = _mapper.Map<RolDto>(role);
                return new Response<RolDto>(dto);
            }
            else
            {

                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }
}
