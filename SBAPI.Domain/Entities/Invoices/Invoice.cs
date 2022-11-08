using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SBAPI.Domain.Entities.ProductsToBuy;
using SBAPI.Domain.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Clients;
using SBAPI.Domain.Entities.SoldProducts;
using SBAPI.Domain.Entities.CashRegisters;

namespace SBAPI.Domain.Entities.Invoices
{
    public class Invoice
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CashRegistrerId { get; set; }
        public virtual CashRegister CashRegister { get; set; } = null!;
        public string Serie { get; set; } = null!;
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
        public ICollection<SoldProduct> SoldProducts { get; set; } = null!;
        public float Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float ExcentValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float TaxesValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float TotalCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public DateTime Date { get; set; }
        [Column(TypeName ="datetime")]
        public int CreatedById { get; set; }
        [Column(TypeName = "int")]
        public virtual User CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
    }
}
