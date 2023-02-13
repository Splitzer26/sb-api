using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Bank;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Banks;

namespace SBAPI.Application.Features.BankFeature.Queries
{
    public class GetAllBanksQuery : IRequest<Response<List<BankDto>>>
    {
        public class GetAllBanksQueryHandler : IRequestHandler<GetAllBanksQuery, Response<List<BankDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<Bank> _repositoryAsync;
            public GetAllBanksQueryHandler(IMapper mapper, IRepositoryAsync<Bank> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<BankDto>>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
            {
                var banks = await _repositoryAsync.ListAsync();
                var dto = _mapper.Map<List<BankDto>>(banks);
                return new Response<List<BankDto>>(dto);
            }
        }
    }
}
