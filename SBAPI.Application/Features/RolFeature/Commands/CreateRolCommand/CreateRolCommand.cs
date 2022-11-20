using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.RolSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Roles;


namespace SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand
{
    public class CreateRolCommand : IRequest<Response<RolDto>>
    {
        public string Name { get; set; } = null!;
    }

    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, Response<RolDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        public CreateRolCommandHandler(IMapper mapper, IRepositoryAsync<Rol> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<RolDto>> Handle(CreateRolCommand request, CancellationToken cancellation)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterRolSpecification(request.Name,null));
            if(findByName != null)
            {
                throw new ApiException($"Ya existe un rol con el nombre {request.Name}");
            }
            var newRecord = _mapper.Map<Rol>(request);
            newRecord.Name = request.Name;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<RolDto>(data);
            return new Response<RolDto>(dto, message: $"{data.Name} creado exitosamente");
        }

    }
}
