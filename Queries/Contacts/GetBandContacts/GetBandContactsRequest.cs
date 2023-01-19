using BandIT.Models.DTO;

namespace BandIT.Queries.Contacts.GetBandContacts
{
    public class GetBandContactsRequest : IQuery<List<ContactDto>>
    {
        public int BandId { get; init; }
    }
}
