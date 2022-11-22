
using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.RolFeature.Commands.DeleteRolCommand
{
    public class DeleteRolCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteRolCommandHandler : IRequestHandler<DeleteRolCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        public DeleteRolCommandHandler(IRepositoryAsync<Rol> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _repositoryAsync.GetByIdAsync(request.Id);
            if (rol != null)
            {
                await _repositoryAsync.DeleteAsync(rol);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{rol.Name} eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
