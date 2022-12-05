using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Department;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.DepartmentSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Departments;

namespace SBAPI.Application.Features.DepartmentFeature.Commands.UpdateDepartmentCommand
{
    public class UpdateDepartmentCommand : IRequest<Response<DepartmentDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Response<DepartmentDto>>
    {
        private readonly IRepositoryAsync<Department> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateDepartmentCommandHandler(IRepositoryAsync<Department> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<DepartmentDto>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repositoryAsync.GetByIdAsync(request.Id);
            if (department != null)
            {
                var filterByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterDepartmentSpecification(request.Name, request.Id));
                if (filterByName != null)
                {
                    throw new ApiException($"Ya existe un departamento con el nombre {request.Name}");
                }
                else
                {
                    department.Name = request.Name;
                    await _repositoryAsync.UpdateAsync(department);
                    await _repositoryAsync.SaveChangesAsync();
                    var dto = _mapper.Map<DepartmentDto>(department);
                    return new Response<DepartmentDto>(dto, message: $"{department.Name} actualizado correctamente");
                }
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id} para actualizar.");
            }
        }
    }
}
