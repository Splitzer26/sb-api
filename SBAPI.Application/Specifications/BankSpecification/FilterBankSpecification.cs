using Ardalis.Specification;
using SBAPI.Domain.Entities.Banks;

namespace SBAPI.Application.Specifications.BankSpecification
{
    internal class FilterBankSpecification : Specification<Bank>
    {
        public FilterBankSpecification(string filter, int? id)
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
