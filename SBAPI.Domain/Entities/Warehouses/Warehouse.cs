using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.BranchOffices;

namespace SBAPI.Domain.Entities.Warehouses
{
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public int BranchOfficeId { get; set; }
        public virtual BranchOffice BranchOffice { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
