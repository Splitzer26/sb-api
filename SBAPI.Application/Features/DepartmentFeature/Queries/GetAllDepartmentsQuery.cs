using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Department;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.DepartmentSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Departments;


namespace SBAPI.Application.Features.DepartmentFeature.Queries
{
    public class GetAllDepartmentsQuery : IRequest<Response<List<DepartmentDto>>>
    {
        public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, Response<List<DepartmentDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<Department> _repositoryAsync;
            public GetAllDepartmentsQueryHandler(IMapper mapper, IRepositoryAsync<Department> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<List<DepartmentDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
            {
                var departments = await _repositoryAsync.ListAsync(new DepartmentIncludesSpecification(null));
                var dto = _mapper.Map<List<DepartmentDto>>(departments);
                return new Response<List<DepartmentDto>>(dto);
            }
        }
    }
}
