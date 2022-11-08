using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.SalesOrders;
using SBAPI.Domain.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Invoices;

namespace SBAPI.Domain.Entities.SoldProducts
{
    public class SoldProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public float Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float TaxesValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float TotalValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int TaxId { get; set; }
        public virtual Tax Tax { get; set; } = null!;
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
    }
}
