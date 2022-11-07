using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Suppliers;

namespace SBAPI.Domain.Entities.PurchaseOrders
{
    public class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Serie { get; set; } = null!;
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;
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
