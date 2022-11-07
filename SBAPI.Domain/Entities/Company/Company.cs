
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SBAPI.Domain.Entities.Company
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string TaxId { get; set; } = null!;
        public string PhoneNumber1 { get; set; } = null!;
        public string PhoneNumber2 { get; set; } = null!; 
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string WebSite { get; set; } = null!;
        public string LogoType { get; set; } = null!;
    }
}
