using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.Department;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.CitySpecification;
using SBAPI.Application.Specifications.DepartmentSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.DepartmentFeature.Queries
{
    public class GetDepartmentByIdQuery : IRequest<Response<DepartmentDto>>
    {
        public int Id { get; set; }
    }
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Department> _repositoryAsync;
        public GetDepartmentByIdQueryHandler(IMapper mapper, IRepositoryAsync<Department> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<DepartmentDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _repositoryAsync.FirstOrDefaultAsync(new DepartmentIncludesSpecification(id: request.Id));
            if (department != null)
            {
                var dto = _mapper.Map<DepartmentDto>(department);
                return new Response<DepartmentDto>(dto);
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }
}
