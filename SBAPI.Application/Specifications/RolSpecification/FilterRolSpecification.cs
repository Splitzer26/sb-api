using Ardalis.Specification;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Specifications.RolSpecification
{
    public class FilterRolSpecification : Specification<Rol>
    {
        public FilterRolSpecification(string filter, int? id) 
        {
            if(id != null)
            {
                Query.Where(x => x.Name == filter && x.Id != id);
            }
            else
            {
                Query.Where(x=>x.Name == filter);
            }
        }
    }
}
