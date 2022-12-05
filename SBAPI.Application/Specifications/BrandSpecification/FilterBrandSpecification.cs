using Ardalis.Specification;
using SBAPI.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Specifications.BrandSpecification
{
    public class FilterBrandSpecification : Specification<Brand>
    {
        public FilterBrandSpecification(string filter, int? id)
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
