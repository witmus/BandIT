using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Contacts.GetContact
{
    public class GetContactHandler : IQueryHandler<GetContactRequest, ContactDto>
    {
        private readonly IContactRepository _contactsContext;

        public GetContactHandler(IContactRepository contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public async Task<ContactDto> Handle(GetContactRequest request, CancellationToken cancellationToken)
        {
            return new(await _contactsContext.GetByIdAsync(request.ContactId));
        }
    }
}
