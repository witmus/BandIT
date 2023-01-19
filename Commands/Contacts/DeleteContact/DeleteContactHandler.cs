using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Contacts.DeleteContact
{
    public class DeleteContactHandler : ICommandHandler<DeleteContactRequest, ContactDto>
    {
        private readonly IContactRepository _contactsContext;

        public DeleteContactHandler(IContactRepository contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public async Task<ContactDto> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            var contact = await _contactsContext.GetByIdAsync(request.ContactId);
            contact = _contactsContext.Delete(contact);
            await _contactsContext.CommitAsync();
            return new(contact);
        }
    }
}
