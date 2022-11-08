using SBAPI.Domain.Entities.Origins;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.ProductsTransfer;
using SBAPI.Domain.Entities.PurchaseOrders;
using SBAPI.Domain.Entities.Warehouses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBAPI.Domain.Entities.ProductsInputs
{
    public class ProductInput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int OriginId { get; set; }
        public virtual Origin Origin { get; set; } = null!;
        public int? TransferId { get; set; }
        public virtual ProductTransfer?  Transfer { get; set; }
        public int? PurchaseOrderId { get; set; }
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public int WarehouseDestinyId { get; set; }
        public virtual Warehouse WarehouseDestiny { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
    }
}
