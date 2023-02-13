using Ardalis.Specification;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SBAPI.Application.Specifications.CitySpecification
{
    public class FilterCitySpecification : Specification<City>
    {
        public FilterCitySpecification(string filter, int? id)
        {
            if (id != null)
            {
                Query.Where(x => x.Name == filter && x.Id != id).Include(x => x.Department);
            }
            else
            {
                Query.Where(x => x.Name == filter).Include(x => x.Department);
            }
        }
    }
}
