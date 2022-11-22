using SBAPI.Domain.Entities.TypeStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Domain.Entities.Statuses
{
    public class Status
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public int TypeStatusId { get; set; }
        public virtual TypeStatus TypeStatus { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
