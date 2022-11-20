using SBAPI.Domain.Entities.Origins;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.ProductsTransfer;
using SBAPI.Domain.Entities.PurchaseOrders;
using SBAPI.Domain.Entities.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Invoices;
using SBAPI.Domain.Entities.Users;

namespace SBAPI.Domain.Entities.ProductsOutputs
{
    public class ProductOutput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
        public int OriginId { get; set; }
        [ForeignKey("OriginId")]
        public virtual Origin Origin { get; set; } = null!;
        public int? TransferId { get; set; }
        [ForeignKey("TransferId")]
        public virtual ProductTransfer? Transfer { get; set; }
        public int? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice? Invoice { get; set; } 
        public int WarehouseFromId { get; set; }
        [ForeignKey("WarehouseDestinyId")]
        public virtual Warehouse WarehouseFrom { get; set; } = null!;
        public int Quantity { get; set; }
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
    }
}
