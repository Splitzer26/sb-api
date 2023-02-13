
using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.BrandSpecification;
using SBAPI.Application.Specifications.RolSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BrandFeature.Commands.CreateBrandCommand
{
    public class CreateBrandCommand : IRequest<Response<BrandDto>>
    {
        public string Name { get; set; } = null!;
    }

    public class CreateBrandCommandHandler: IRequestHandler<CreateBrandCommand, Response<BrandDto>>
    {
        public readonly IRepositoryAsync<Brand> _repositoryAsync;
        public readonly IMapper _mapper;
        public CreateBrandCommandHandler(IRepositoryAsync<Brand> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<BrandDto>> Handle(CreateBrandCommand request, CancellationToken cancellation)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterBrandSpecification(request.Name, null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe una marca con el nombre {request.Name}");
            }
            var newRecord = _mapper.Map<Brand>(request);
            newRecord.Name = request.Name;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<BrandDto>(data);
            return new Response<BrandDto>(dto, message: $"{data.Name} creado exitosamente");
        }
    }
}
