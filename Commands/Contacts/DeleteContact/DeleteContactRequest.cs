using BandIT.Models.DTO;

namespace BandIT.Commands.Contacts.DeleteContact
{
    public class DeleteContactRequest : ICommand<ContactDto>
    {
        public int ContactId { get; init; }
    }
}
