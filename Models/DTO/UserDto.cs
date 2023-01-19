using BandIT.Models.Entities;
using BandIT.Models.Enums;

namespace BandIT.Models.DTO
{
    public class UserDto
    {
        public string Id { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public UserRole Role { get; init; } = UserRole.User;
        public BandDto Band { get; init; }

        public UserDto(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
            Band = new BandDto(user.Band);
        }
    }
}
