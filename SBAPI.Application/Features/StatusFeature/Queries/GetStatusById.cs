using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Status;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.StatusSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Statuses;


namespace SBAPI.Application.Features.StatusFeature.Queries
{
    public class GetStatusByIdQuery : IRequest<Response<StatusDto>>
    {
        public int Id { get; set; }
    }
    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, Response<StatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Status> _repositoryAsync;
        public GetStatusByIdQueryHandler(IMapper mapper, IRepositoryAsync<Status> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<StatusDto>> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await _repositoryAsync.FirstOrDefaultAsync(new StatusIncludesSpecification(id: request.Id));
            if(status != null)
            {
                var dto = _mapper.Map<StatusDto>(status);
                return new Response<StatusDto>(dto);
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }

    }
}
