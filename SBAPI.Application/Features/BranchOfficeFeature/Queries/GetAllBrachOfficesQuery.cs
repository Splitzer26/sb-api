using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.BranchOffice;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.BranchOffices;

namespace SBAPI.Application.Features.BranchOfficeFeature.Queries
{
    public class GetAllBrachOfficesQuery : IRequest<Response<List<BranchOfficeDto>>>
    {
        public class GetAllBranchOfficeQueryHandler : IRequestHandler<GetAllBrachOfficesQuery, Response<List<BranchOfficeDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<BranchOffice> _repositoryAsync;
            public GetAllBranchOfficeQueryHandler(IMapper mapper, IRepositoryAsync<BranchOffice> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<BranchOfficeDto>>> Handle(GetAllBrachOfficesQuery request, CancellationToken cancellationToken)
            {
                var branchOffices = await _repositoryAsync.ListAsync();
                var dto = _mapper.Map<List<BranchOfficeDto>>(branchOffices);
                return new Response<List<BranchOfficeDto>>(dto);
            }
        }
    }
}
