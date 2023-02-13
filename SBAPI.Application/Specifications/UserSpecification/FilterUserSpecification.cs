using Ardalis.Specification;
using SBAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Specifications.UserSpecification
{
    public class FilterUserSpecification : Specification<User>
    {
        public FilterUserSpecification(string filter, int? id) 
        {
            if(id != null)
                Query.Where(a=>a.UserName == filter || a.FirstName + " " + a.LastName == filter && a.Id != id);
            else
                Query.Where(a => a.UserName == filter || a.FirstName + " " + a.LastName == filter||a.Email == filter);
        }
    }
}
