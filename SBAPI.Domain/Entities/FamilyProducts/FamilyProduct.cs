using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.SectionsProduct;

namespace SBAPI.Domain.Entities.FamilyProducts
{
    public class FamilyProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public int SectionProductId { get; set; }
        public virtual SectionProduct SectionProduct { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
