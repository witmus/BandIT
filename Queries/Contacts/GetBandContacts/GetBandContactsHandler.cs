using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;
using MediatR;

namespace BandIT.Queries.Contacts.GetBandContacts
{
    public class GetBandContactsHandler : IQueryHandler<GetBandContactsRequest, List<ContactDto>>
    {
        private readonly IContactRepository _contactsContext;

        public GetBandContactsHandler(IContactRepository contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public Task<List<ContactDto>> Handle(GetBandContactsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_contactsContext
                .GetByBandId(request.BandId)
                .OrderBy(c => c.LastName)
                .ToList()
                .Select(c => new ContactDto(c))
                .ToList());
        }
    }
}
