using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BrandFeature.Commands.DeleteBrandCommand
{
    public class DeleteBrandCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Brand> _repositoryAsync;
        public DeleteBrandCommandHandler(IRepositoryAsync<Brand> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _repositoryAsync.GetByIdAsync(request.Id);
            if (brand != null)
            {
                await _repositoryAsync.DeleteAsync(brand);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{brand.Name} eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
