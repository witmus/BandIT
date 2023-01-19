using System.ComponentModel.DataAnnotations;

namespace BandIT.Models.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "NO_USERNAME")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "NO_PASSWORD")]
        public string? Password { get; init; }
    }
}
