using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.ClientType;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.ClientTypeSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.ClientTypes;

namespace SBAPI.Application.Features.ClientTypeFeature.Commands.CreateClientTypeCommand
{
    public class CreateClientTypeCommand : IRequest<Response<ClientTypeDto>>
    {
        public string Name { get; set; } = null!;
    }

    public class CreateClientTypeCommandHandler : IRequestHandler<CreateClientTypeCommand, Response<ClientTypeDto>>
    {
        public readonly IRepositoryAsync<ClientType> _repositoryAsync;
        public readonly IMapper _mapper;
        public CreateClientTypeCommandHandler(IRepositoryAsync<ClientType> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<ClientTypeDto>> Handle(CreateClientTypeCommand request, CancellationToken cancellation)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterClientTypeSpecification(request.Name, null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe un tipo de cliente con el nombre {request.Name}");
            }
            var newRecord = _mapper.Map<ClientType>(request);
            newRecord.Name = request.Name;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<ClientTypeDto>(data);
            return new Response<ClientTypeDto>(dto, message: $"{data.Name} creado exitosamente");
        }
    }
}
