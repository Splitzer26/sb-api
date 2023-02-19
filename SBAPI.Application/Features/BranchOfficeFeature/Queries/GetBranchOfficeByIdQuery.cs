using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.BranchOffice;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.BranchOffices;

namespace SBAPI.Application.Features.BranchOfficeFeature.Queries
{
    public class GetBranchOfficeByIdQuery:IRequest<Response<BranchOfficeDto>>
    {
        public int Id { get; set; }
    }
    public class GetBranchOfficeByIdQueryHandler : IRequestHandler<GetBranchOfficeByIdQuery, Response<BranchOfficeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<BranchOffice> _repositoryAsync;
        public GetBranchOfficeByIdQueryHandler(IMapper mapper, IRepositoryAsync<BranchOffice> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<BranchOfficeDto>> Handle(GetBranchOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            var branchOffice = await _repositoryAsync.GetByIdAsync(request.Id);
            if (branchOffice == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            var dto = _mapper.Map<BranchOfficeDto>(branchOffice);
            return new Response<BranchOfficeDto>(dto);
        }
    }
}
