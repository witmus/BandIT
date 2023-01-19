using System.ComponentModel.DataAnnotations;

namespace BandIT.Models.DTO
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "NO_OLD_PASSWORD")]
        public string? OldPassword { get; init; }

        [Required(ErrorMessage = "NO_NEW_PASSWORD")]
        public string? NewPassword { get; init; }
    }
}
