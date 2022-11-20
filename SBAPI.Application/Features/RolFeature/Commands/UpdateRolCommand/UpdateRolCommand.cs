using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.RolSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.RolFeature.Commands.UpdateRolCommand
{
    public class UpdateRolCommand : IRequest<Response<RolDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, Response<RolDto>>
    {
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateRolCommandHandler(IRepositoryAsync<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<RolDto>> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _repositoryAsync.GetByIdAsync(request.Id);
            if(rol != null) {
                var filterByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterRolSpecification(request.Name,request.Id));
                if(filterByName != null)
                {
                    throw new ApiException($"Ya existe un rol con el nombre {request.Name}");
                }
                else
                {
                    rol.Name = request.Name;
                    await _repositoryAsync.UpdateAsync(rol);
                    await _repositoryAsync.SaveChangesAsync();
                    var dto = _mapper.Map<RolDto>(rol);
                    return new Response<RolDto>(dto,message: $"{rol.Name} actualizado correctamente");
                }
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id} para actualizar.");
            }
        }
    }
}
