using BandIT.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandIT.Models.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(30)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        public UserRole Role { get; set; }

        public int BandId { get; set; }

        [ForeignKey("BandId")]
        public virtual Band Band { get; set; }
    }
}
