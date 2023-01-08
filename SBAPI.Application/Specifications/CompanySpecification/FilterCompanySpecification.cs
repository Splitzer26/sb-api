using SBAPI.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using System.Threading.Tasks;

namespace SBAPI.Application.Specifications.CompanySpecification
{
    public class FilterCompanySpecification : Specification<Business>
    {
        public FilterCompanySpecification(string? name, string? taxId)
        {
            if (taxId != null)
            {
                Query.Where(x => x.TaxId == taxId);
            }
            else
            {
                Query.Where(x => x.Name == name);
            }
        }
    }
}
