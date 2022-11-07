using SBAPI.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Suppliers;
using SBAPI.Domain.Entities.Products;

namespace SBAPI.Domain.Entities.ListSuppliers
{
    public class ListSuppliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Department { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
