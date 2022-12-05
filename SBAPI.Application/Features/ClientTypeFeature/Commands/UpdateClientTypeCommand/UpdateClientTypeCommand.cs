using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.ClientType;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.BrandSpecification;
using SBAPI.Application.Specifications.ClientTypeSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.ClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.ClientTypeFeature.Commands.UpdateClientTypeCommand
{
    public class UpdateClientTypeCommand : IRequest<Response<ClientTypeDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class UpdateClientTypeCommandHandler : IRequestHandler<UpdateClientTypeCommand, Response<ClientTypeDto>>
    {
        private readonly IRepositoryAsync<ClientType> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateClientTypeCommandHandler(IRepositoryAsync<ClientType> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<ClientTypeDto>> Handle(UpdateClientTypeCommand request, CancellationToken cancellationToken)
        {
            var clientType = await _repositoryAsync.GetByIdAsync(request.Id);
            if (clientType != null)
            {
                var filterByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterClientTypeSpecification(request.Name, request.Id));
                if (filterByName != null)
                {
                    throw new ApiException($"Ya existe una tipo de cliente con el nombre {request.Name}");
                }
                else
                {
                    clientType.Name = request.Name;
                    await _repositoryAsync.UpdateAsync(clientType);
                    await _repositoryAsync.SaveChangesAsync();
                    var dto = _mapper.Map<ClientTypeDto>(clientType);
                    return new Response<ClientTypeDto>(dto, message: $"{clientType.Name} actualizado correctamente");
                }
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id} para actualizar.");
            }
        }
    }
}
