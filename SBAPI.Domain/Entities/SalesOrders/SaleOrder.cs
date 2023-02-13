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
using SBAPI.Domain.Entities.Users;
using SBAPI.Domain.Entities.Statuses;

namespace SBAPI.Domain.Entities.SalesOrders
{
    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Serie { get; set; } = null!;
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; } = null!;
        public List<ProductToSell> ProductsToSale { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public float Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float ExcentValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float TaxesValue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float TotalCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        [ForeignKey("ModifiedById")]
        public virtual User ModifiedBy { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOn { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = null!;
    }
}
