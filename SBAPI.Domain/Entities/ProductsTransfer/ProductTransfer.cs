using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.Warehouses;
using SBAPI.Domain.Entities.Users;
using SBAPI.Domain.Entities.Statuses;

namespace SBAPI.Domain.Entities.ProductsTransfer
{
    public class ProductTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int WarehouseFromId { get; set; }
        public virtual Warehouse WarehouseFrom { get; set; } = null!;
        public int WarehouseToId { get; set; }
        public virtual Warehouse WarehouseTo { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = null!;
    }
}
