using Ardalis.Specification;
using SBAPI.Domain.Entities.Departments;
using SBAPI.Domain.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SBAPI.Application.Specifications.DepartmentSpecification
{
    public class DepartmentIncludesSpecification : Specification<Department>
    {
        public DepartmentIncludesSpecification(int? id)
        {
            if (id == null)
            {
                Query.Include(x => x.Cities);
            }
            else
            {
                Query.Include(x => x.Cities).Where(x => x.Id == id);
            }
        }
    }
}
