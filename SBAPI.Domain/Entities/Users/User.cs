using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Domain.Entities.Roles;
using SBAPI.Domain.Entities.Statuses;

namespace SBAPI.Domain.Entities.Users
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public byte[] MasterPasswordHash { get; set; } = null!;
        public byte[] MasterPasswordSalt { get; set; } = null!;
        public string? PorfilePhoto { get; set; }
        public int RolId { get; set; }
        public virtual Rol? Rol { get; set; } = null!;
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = null!;
    }
}
