using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.BrandSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;


namespace SBAPI.Application.Features.BrandFeature.Commands.UpdateBrandCommand
{
    public class UpdateBrandCommand : IRequest<Response<BrandDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Response<BrandDto>>
    {
        private readonly IRepositoryAsync<Brand> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateBrandCommandHandler(IRepositoryAsync<Brand> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<BrandDto>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _repositoryAsync.GetByIdAsync(request.Id);
            if (brand != null)
            {
                var filterByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterBrandSpecification(request.Name, request.Id));
                if (filterByName != null)
                {
                    throw new ApiException($"Ya existe una marca con el nombre {request.Name}");
                }
                else
                {
                    brand.Name = request.Name;
                    await _repositoryAsync.UpdateAsync(brand);
                    await _repositoryAsync.SaveChangesAsync();
                    var dto = _mapper.Map<BrandDto>(brand);
                    return new Response<BrandDto>(dto, message: $"{brand.Name} actualizado correctamente");
                }
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id} para actualizar.");
            }
        }
    }
}
