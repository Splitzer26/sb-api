using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Department;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.DepartmentSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Departments;

namespace SBAPI.Application.Features.DepartmentFeature.Commands.CreateDepartmentCommand
{
    public class CreateDepartmentCommand : IRequest<Response<DepartmentDto>>
    {
        public string Name { get; set; } = null!;
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Response<DepartmentDto>>
    {
        public readonly IRepositoryAsync<Department> _repositoryAsync;
        public readonly IMapper _mapper;
        public CreateDepartmentCommandHandler(IRepositoryAsync<Department> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<DepartmentDto>> Handle(CreateDepartmentCommand request, CancellationToken cancellation)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterDepartmentSpecification(request.Name, null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe un departamento con el nombre {request.Name}");
            }
            var newRecord = _mapper.Map<Department>(request);
            newRecord.Name = request.Name;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<DepartmentDto>(data);
            return new Response<DepartmentDto>(dto, message: $"{data.Name} creado exitosamente");
        }
    }
}
