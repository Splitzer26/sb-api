using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Status;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.StatusSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Statuses;

namespace SBAPI.Application.Features.StatusFeature.Queries
{
    public class GetAllStatutesQuery : IRequest<Response<List<StatusDto>>>
    {
        public class GetAllStatutesQueryHandler : IRequestHandler<GetAllStatutesQuery, Response<List<StatusDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<Status> _repositoryAsync;
            public GetAllStatutesQueryHandler(IMapper mapper, IRepositoryAsync<Status> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<StatusDto>>> Handle(GetAllStatutesQuery request, CancellationToken cancellationToken)
            {
                var statuses = await _repositoryAsync.ListAsync(new StatusIncludesSpecification(null));
                var dto = _mapper.Map<List<StatusDto>>(statuses);
                return new Response<List<StatusDto>>(dto);
            }
        }
    }
}
