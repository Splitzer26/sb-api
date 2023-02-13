using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.ClientTypes;

namespace SBAPI.Application.Features.ClientTypeFeature.Commands.DeleteClientTypeCommand
{
    public class DeleteClientTypeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteClientTypeCommandHandler : IRequestHandler<DeleteClientTypeCommand, Response<string>>
    {
        private readonly IRepositoryAsync<ClientType> _repositoryAsync;
        public DeleteClientTypeCommandHandler(IRepositoryAsync<ClientType> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteClientTypeCommand request, CancellationToken cancellationToken)
        {
            var clientType = await _repositoryAsync.GetByIdAsync(request.Id);
            if (clientType != null)
            {
                await _repositoryAsync.DeleteAsync(clientType);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{clientType.Name} eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
