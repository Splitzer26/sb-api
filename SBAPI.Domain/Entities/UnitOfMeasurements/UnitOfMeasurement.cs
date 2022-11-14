using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.TypesUnitOfMeasurements;

namespace SBAPI.Domain.Entities.UnitOfMeasurements
{
    public class UnitOfMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abreviature { get; set; } = null!;

        public int TypeUnitOfMeasurementId { get; set; }
        public virtual TypeUnitOfMeasurement TypeUnitOfMeasurement { get; set; } = null!;
    }
}
