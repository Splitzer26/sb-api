using Ardalis.Specification;
using SBAPI.Domain.Entities.Cities;
using SBAPI.Domain.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SBAPI.Application.Specifications.CitySpecification
{
    public class CityIncludesSpecification : Specification<City>
    {
        public CityIncludesSpecification(int? id)
        {
            if (id == null)
            {
                Query.Include(x => x.Department);
            }
            else
            {
                Query.Include(x => x.Department).Where(x => x.Id == id);
            }
        }
    }
}
