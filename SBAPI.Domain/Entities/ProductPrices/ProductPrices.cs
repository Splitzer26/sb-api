using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.ClientTypes;
using SBAPI.Domain.Entities.Products;

namespace SBAPI.Domain.Entities.ProductPrices
{
    public class ProductPrices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TypeClientId { get; set; }
        public virtual ClientType ClientType { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public float Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
       

    }
}
