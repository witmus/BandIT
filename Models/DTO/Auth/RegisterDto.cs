using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Models.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "NO_USERNAME")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "NO_FIRSTNAME")]
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }

        [Required(ErrorMessage = "NO_EMAIL")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "NO_PASSWORD")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "NO_ROLE")]
        public UserRole? Role { get; init; }

        public string? AccessCode { get; init; }
        public string? BandName { get; init; }
        public string? BandTIN { get; init; }
    }
}
