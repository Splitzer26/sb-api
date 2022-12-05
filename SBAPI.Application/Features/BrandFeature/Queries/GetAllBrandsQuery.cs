using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Bank;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Banks;
using SBAPI.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BrandFeature.Queries
{
    public class GetAllBrandsQuery : IRequest<Response<List<BrandDto>>>
    {
        public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, Response<List<BrandDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<Brand> _repositoryAsync;
            public GetAllBrandsQueryHandler(IMapper mapper, IRepositoryAsync<Brand> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
            {
                var brands = await _repositoryAsync.ListAsync();
                var dto = _mapper.Map<List<BrandDto>>(brands);
                return new Response<List<BrandDto>>(dto);
            }
        }
    }
}
