using BandIT.Models.DTO;

namespace BandIT.Queries.Contacts.GetContact
{
    public class GetContactRequest : IQuery<ContactDto>
    {
        public int ContactId { get; init; }
    }
}
