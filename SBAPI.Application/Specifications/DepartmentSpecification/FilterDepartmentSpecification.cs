using Ardalis.Specification;
using SBAPI.Domain.Entities.Departments;

namespace SBAPI.Application.Specifications.DepartmentSpecification
{
    public class FilterDepartmentSpecification : Specification<Department>
    {
        public FilterDepartmentSpecification(string filter, int? id)
        {
            if (id != null)
            {
                Query.Where(x => x.Name == filter && x.Id != id);
            }
            else
            {
                Query.Where(x => x.Name == filter);
            }
        }
    }
}
