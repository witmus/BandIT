using BandIT.Models.Entities;
using BandIT.Models.Enums;

namespace BandIT.Models.DTO
{
    public class ContactDto : BandEntityDto<Contact>
    {
        public string FirstName { get; init; } = string.Empty;
        public ContactType ContactType { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? EmailAddress { get; init; }
        public string? Description { get; init; }

        public ContactDto(Contact entity) : base(entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            PhoneNumber = entity.PhoneNumber;
            EmailAddress = entity.EmailAddress;
            Description = entity.Description;
            ContactType = entity.ContactType;
        }
    }
}
