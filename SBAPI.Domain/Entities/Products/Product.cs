﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.FamilyProducts;
using SBAPI.Domain.Entities.Suppliers;
using SBAPI.Domain.Entities.ProductStatuses;
using SBAPI.Domain.Entities.UnitOfMeasurements;
using SBAPI.Domain.Entities.Users;
using SBAPI.Domain.Entities.Taxes;

namespace SBAPI.Domain.Entities.Products
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CurrentStock{ get; set; }
        public float CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int FamilyProductId { get; set; }
        public virtual FamilyProduct FamilyProduct { get; set; } = null!;
        public int RegularSupplierId { get; set; }
        public virtual Supplier RegularSupplier { get; set; } = null!;
        public ICollection<Supplier>? OtherSuppliers { get; set; }
        public int TaxId { get; set; }
        public Tax Tax { get; set; } = null!;
        public int ProductStatusId { get; set; }
        public virtual ProductStatus ProductStatus { get; set; } = null!;
        public int UnitOfMeasurementId { get; set; }
        public virtual UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public virtual User ModifiedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }

    }
}