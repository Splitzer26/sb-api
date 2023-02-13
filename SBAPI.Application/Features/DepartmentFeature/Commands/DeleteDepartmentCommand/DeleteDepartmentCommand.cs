using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.DepartmentFeature.Commands.DeleteDepartmentCommand
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Response<string>>
    {
        private readonly IRepositoryAsync<Department> _repositoryAsync;
        public DeleteDepartmentCommandHandler(IRepositoryAsync<Department> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repositoryAsync.GetByIdAsync(request.Id);
            if (department != null)
            {
                await _repositoryAsync.DeleteAsync(department);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"{department.Name} eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
