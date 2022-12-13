
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SBAPI.Domain.Entities.Company
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string TaxId { get; set; } = null!;
        public string? PhoneNumber1 { get; set; } 
        public string? PhoneNumber2 { get; set; } 
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? WebSite { get; set; } 
        public string? LogoType { get; set; } = null!;
    }
}
