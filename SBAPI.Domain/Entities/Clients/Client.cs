using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.ClientTypes;
using SBAPI.Domain.Entities.Cities;

namespace SBAPI.Domain.Entities.Clients
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IdentityNumber { get; set; }
        public string? TaxId { get; set; }
        public bool IsACompany { get; set; }
        public int ClientTypeId { get; set; }
        public virtual ClientType ClientType { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; } = null!;
        public string? Email { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonPhone { get; set; } 

    }
}
