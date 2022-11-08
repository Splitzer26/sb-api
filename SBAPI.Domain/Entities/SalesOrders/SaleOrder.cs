using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SBAPI.Domain.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Clients;
using SBAPI.Domain.Entities.ProductsToSale;

namespace SBAPI.Domain.Entities.SalesOrders
{
    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Serie { get; set; } = null!;
        public int ClientId { get; set; }
        public virtual Client Supplier { get; set; } = null!;
        public ICollection<ProductToSell> ProductsToSale { get; set; } = null!;
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
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
    }
}
