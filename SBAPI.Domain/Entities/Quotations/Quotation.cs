using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SBAPI.Domain.Entities.ProductsToBuy;
using SBAPI.Domain.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Clients;
using SBAPI.Domain.Entities.ListedProducts;
using SBAPI.Domain.Entities.Users;

namespace SBAPI.Domain.Entities.Quotations
{
    public class Quotation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Serie { get; set; } = null!;
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
        public ICollection<ListedProduct> ListedProducts { get; set; } = null!;
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
        public virtual User CreatedBy { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime ModifiedOn { get; set; }
    }
}
