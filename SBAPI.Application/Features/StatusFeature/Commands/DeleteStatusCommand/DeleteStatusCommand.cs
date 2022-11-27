using AutoMapper;
using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.StatusFeature.Commands.DeleteStatusCommand
{
    public class DeleteStatusCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteStatusCommandHandler: IRequestHandler<DeleteStatusCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Status> _repositoryAsync;
        public DeleteStatusCommandHandler(IMapper mapper, IRepositoryAsync<Status> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _repositoryAsync.GetByIdAsync(request.Id);
            if(status != null)
            {
                await _repositoryAsync.DeleteAsync(status);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{status.Name} eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
