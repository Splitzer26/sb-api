using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Company;
using SBAPI.Domain.Entities.Statuses;

namespace SBAPI.Domain.Entities.BranchOffices
{
    public class BranchOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public int CompanyId { get; set; }
        public virtual Business Company { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string ManagerName { get; set; } = string.Empty!;
        public string ManagerEmail { get; set; } = string.Empty!;
        public string Address { get; set; } = string.Empty!;
        public bool IsActive { get; set; }
    }
}
