using Ardalis.Specification;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.ClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SBAPI.Application.Specifications.ClientTypeSpecification
{
    public class FilterClientTypeSpecification : Specification<ClientType>
    {
        public FilterClientTypeSpecification(string filter, int? id)
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
