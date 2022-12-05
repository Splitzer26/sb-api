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
    public class GetClientTypeByIdQuery : IRequest<Response<ClientTypeDto>>
    {
        public int Id { get; set; }
    }
    public class GetClientTypeByIdQueryHandler : IRequestHandler<GetClientTypeByIdQuery, Response<ClientTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<ClientType> _repositoryAsync;
        public GetClientTypeByIdQueryHandler(IMapper mapper, IRepositoryAsync<ClientType> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<ClientTypeDto>> Handle(GetClientTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var clientType = await _repositoryAsync.GetByIdAsync(request.Id);
            if (clientType != null)
            {
                var dto = _mapper.Map<ClientTypeDto>(clientType);
                return new Response<ClientTypeDto>(dto);
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }
}
