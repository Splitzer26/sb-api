using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Banks;
using SBAPI.Domain.Entities.AccountType;
using SBAPI.Domain.Entities.Suppliers;

namespace SBAPI.Domain.Entities.SupplierBankAccounts
{
    public class SupplierBankAccount
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; } = null!;
        public int AccountTypeId { get; set; }
        public virtual TypeBankAccount AccountType { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } =null!;
    }
}
