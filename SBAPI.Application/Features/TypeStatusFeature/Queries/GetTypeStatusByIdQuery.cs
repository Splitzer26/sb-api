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
    public class GetTypeStatusByIdQuery : IRequest<Response<TypeStatusDto>>
    {
        public int Id { get; set; }
    }
    public class GetTypeStatusByIdQueryHandler : IRequestHandler<GetTypeStatusByIdQuery, Response<TypeStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<TypeStatus> _repositoryAsync;
        public GetTypeStatusByIdQueryHandler(IMapper mapper, IRepositoryAsync<TypeStatus> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<TypeStatusDto>> Handle(GetTypeStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var typeStatus = await _repositoryAsync.GetByIdAsync(request.Id);
            if(typeStatus != null) 
            {
                var dto = _mapper.Map<TypeStatusDto>(typeStatus);
                return new Response<TypeStatusDto>(dto);
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }

}
