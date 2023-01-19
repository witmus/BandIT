using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Contacts.AddContact
{
    public class AddContactRequest : ICommand<ContactDto>
    {
        [Required(ErrorMessage = "NO_FIRST_NAME")]
        public string? FirstName { get; init; }
        public ContactType ContactType { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? EmailAddress { get; init; }
        public string? Description { get; init; }
        public int BandId { get; init; }
    }
}
