using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.BranchOffices;

namespace SBAPI.Domain.Entities.CashRegisters
{
    public class CashRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BranchOfficeId { get; set; }
        public virtual BranchOffice BranchOffice { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? PrefixSeries { get; set; }
        public int? StartingSeries { get; set; }
        public int? EndingSeries { get; set; }
        public int? CurrentSeries { get; set; }
        public int? AvalibleSeries { get; set; }
        public string? CAI { get; set; }

    }
}
