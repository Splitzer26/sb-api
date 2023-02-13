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
    public class GetBrandByIdQuery : IRequest<Response<BrandDto>>
    {
        public int Id { get; set; }
    }
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Response<BrandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Brand> _repositoryAsync;
        public GetBrandByIdQueryHandler(IMapper mapper, IRepositoryAsync<Brand> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<BrandDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _repositoryAsync.GetByIdAsync(request.Id);
            if (brand != null)
            {
                var dto = _mapper.Map<BrandDto>(brand);
                return new Response<BrandDto>(dto);
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }
}
