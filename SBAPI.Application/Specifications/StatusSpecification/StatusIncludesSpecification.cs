using Ardalis.Specification;
using SBAPI.Domain.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Specifications.StatusSpecification
{
    public class StatusIncludesSpecification : Specification<Status>
    {
        public StatusIncludesSpecification(int? id) {
            if (id == null)
            {
                Query.Include(x => x.TypeStatus);
            }
            else
            {
                Query.Include(x => x.TypeStatus).Where(x=> x.Id == id);
            }
        }
    }
}
