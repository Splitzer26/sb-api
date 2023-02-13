using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Roles;
using SBAPI.Domain.Entities.TypeStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Commands.DeleteTypeStatusCommand
{
    public class DeleteTypeStatusCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteTypeStatusCommandHandler:IRequestHandler<DeleteTypeStatusCommand, Response<string>>
    {
        private readonly IRepositoryAsync<TypeStatus> _repositoryAsync;
        public  DeleteTypeStatusCommandHandler(IRepositoryAsync<TypeStatus> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteTypeStatusCommand request, CancellationToken cancellationToken)
        {
            var typeStatus = await _repositoryAsync.GetByIdAsync(request.Id);
            if (typeStatus != null)
            {
                await _repositoryAsync.DeleteAsync(typeStatus);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{typeStatus.Name} eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
