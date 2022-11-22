using SBAPI.Domain.Entities.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Domain.Entities.TypeStatuses
{
    public class TypeStatus
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public virtual List<Status>? Status { get; set; }
    }
}
