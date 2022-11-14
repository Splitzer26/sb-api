using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.Warehouses;

namespace SBAPI.Domain.Entities.DistributionProducts
{
    public class DistributionProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
